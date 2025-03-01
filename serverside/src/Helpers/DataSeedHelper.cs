/*
 * @bot-written
 *
 * WARNING AND NOTICE
 * Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
 * Full Software Licence as accepted by you before being granted access to this source code and other materials,
 * the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
 * commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
 * licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
 * including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
 * access, download, storage, and/or use of this source code.
 *
 * BOT WARNING
 * This file is bot-written.
 * Any changes out side of "protected regions" will be lost next time the bot makes any changes.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cis.Exceptions;
using Cis.Models;
using Cis.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Helpers
{
	public class SeedGroup
	{
		public string Name { get; set; }
		public bool HasBackendAccess { get; set; }
	}

	/// <summary>
	/// Seeds groups for all environments and users for development environments
	/// </summary>
	public class DataSeedHelper
	{
		private readonly RoleManager<Group> _roleManager;
		private readonly IUserService _userService;
		private readonly ILogger<DataSeedHelper> _logger;
		private readonly IWebHostEnvironment _environment;
		// % protected region % [Add any extra properties here] off begin
		// % protected region % [Add any extra properties here] end

		public static readonly List<SeedGroup> Roles = new List<SeedGroup>
		{
			// % protected region % [Configure the modelled groups here] off begin
			// Super administrators has no special access but just allows the super dev account to open to the admin
			// pages without there being a modelled admin group.
			new SeedGroup {Name = "Super Administrators", HasBackendAccess = true},
			new SeedGroup {Name = "Visitors", HasBackendAccess = false},
			new SeedGroup {Name = "ServiceCommissioningBody", HasBackendAccess = false},
			new SeedGroup {Name = "Admin", HasBackendAccess = true},
			// % protected region % [Configure the modelled groups here] end

			// % protected region % [Add any extra seeded groups here] off begin
			// % protected region % [Add any extra seeded groups here] end
		};

		// % protected region % [Add any extra core seed data here] off begin
		// % protected region % [Add any extra core seed data here] end

		public DataSeedHelper(
			RoleManager<Group> roleManager,
			IUserService userService,
			ILogger<DataSeedHelper> logger,
			IWebHostEnvironment environment
			// % protected region % [Add any extra dependencies here] off begin
			// % protected region % [Add any extra dependencies here] end
			)
		{
			_roleManager = roleManager;
			_userService = userService;
			_logger = logger;
			_environment = environment;
			// % protected region % [Add any extra dependency assignments here] off begin
			// % protected region % [Add any extra dependency assignments here] end
		}

		public async Task Initialize(CancellationToken cancellationToken = default)
		{
			// % protected region % [Do tasks before initialisation here] off begin
			// % protected region % [Do tasks before initialisation here] end

			await CreateObjects(cancellationToken);

			// % protected region % [Add any extra initialisation methods here] off begin
			// % protected region % [Add any extra initialisation methods here] end
		}

		private async Task CreateObjects(CancellationToken cancellationToken = default)
		{
			// Create the roles first since we need them to assign users to afterwards
			foreach (var role in Roles)
			{
				await CreateRole(role);
			}

			// % protected region % [Configure development seeding here] off begin
			if (_environment.IsDevelopment())
			{
				// Create users for testing in development environments
				await CreateUser(
					new User {Email = "super@example.com", Discriminator = "User"},
					"password",
					new [] {"Visitors", "ServiceCommissioningBody", "Admin", "Super Administrators"});
				await CreateUser(
					new AdminEntity {Email = "admin@example.com"},
					"password",
					new [] {"Admin"});
				await CreateUser(
					new ServiceCommissioningBodyEntity {Email = "servicecommissioningbody@example.com"},
					"password",
					new [] {"ServiceCommissioningBody"});
			}
			// % protected region % [Configure development seeding here] end

			// % protected region % [Add any extra seeding here] off begin
			// % protected region % [Add any extra seeding here] end
		}

		public async Task CreateRole(SeedGroup seedGroup)
		{
			var group = await _roleManager.FindByNameAsync(seedGroup.Name);
			if (group == null)
			{
				await _roleManager.CreateAsync(new Group
				{
					Id = Guid.NewGuid(),
					Name = seedGroup.Name,
					HasBackendAccess = seedGroup.HasBackendAccess,
				});
			}
			else
			{
				if (group.HasBackendAccess != seedGroup.HasBackendAccess)
				{
					group.HasBackendAccess = seedGroup.HasBackendAccess;
					await _roleManager.UpdateAsync(group);
				}

				// % protected region % [Configure any extra user updates here] off begin
				// % protected region % [Configure any extra user updates here] end

				_logger.LogInformation("Not creating group {GroupName} since this group already exists", seedGroup.Name, seedGroup);
			}
		}

		public async Task CreateUser(
			User user,
			string password,
			IEnumerable<string> groups,
			bool sendRegisterEmail = false)
		{
			try
			{
				var result = await _userService.RegisterUser(user, password, groups, sendRegisterEmail);
				if (!result.Result.Succeeded)
				{
					var duplicateUserNameError = result.Result.Errors.FirstOrDefault(e => e.Code == "DuplicateUserName");
					if (duplicateUserNameError == null)
					{
						throw new AggregateException(result.Result.Errors.Select(e => new Exception(e.Description)));
					}
					_logger.LogInformation("Not creating user {SeedUserName} since this user already exists", user.Email);
				}
			}
			catch (DuplicateUserException)
			{
				_logger.LogInformation("Not creating user {SeedUserName} since this user already exists", user.Email);
			}
			catch (DbUpdateException e)
			{
				_logger.LogError(e, "Not creating user {SeedUserName} because of a database error", user.Email);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "Unable to create {SeedUserName} because of an unhandled error", user.Email);
			}
		}

		// % protected region % [Add any extra data seeding functions here] off begin
		// % protected region % [Add any extra data seeding functions here] end
	}
}
