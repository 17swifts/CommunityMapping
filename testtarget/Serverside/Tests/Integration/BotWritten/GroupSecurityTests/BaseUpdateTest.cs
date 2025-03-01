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
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Cis.Models;
using Cis.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using ServersideTests.Helpers;
using ServersideTests.Helpers.EntityFactory;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace ServersideTests.Tests.Integration.BotWritten.GroupSecurityTests
{
	public class BaseUpdateTest : IDisposable
	{
		private IHost _host;
		private IServiceScope _scope;

		public BaseUpdateTest()
		{
			// % protected region % [Add constructor logic here] off begin
			// % protected region % [Add constructor logic here] end
		}

		public void Dispose()
		{
			// % protected region % [Configure dispose here] off begin
			_host.Dispose();
			_scope.Dispose();
			// % protected region % [Configure dispose here] end
		}

		public async Task UpdateTest<T>(T model, string message, string groupName)
			where T : class, IOwnerAbstractModel, new()
		{
			// % protected region % [Overwrite update security test here] off begin
			// Arrange.
			IServiceProvider serviceProvider;
			if (groupName != null)
			{
				_host = ServerBuilder.CreateServer(new ServerBuilderOptions
				{
					UserPrincipalFactory = async sp => await sp
						.GetRequiredService<IUserClaimsPrincipalFactory<User>>()
						.CreateAsync(await sp
							.GetRequiredService<UserManager<User>>()
							.FindByNameAsync($"test_{groupName.ToLower()}@example.com"))
				});
				_scope = _host.Services.CreateScope();
				serviceProvider = _scope.ServiceProvider;

				var user = new User
				{
					Email = $"test_{groupName.ToLower()}@example.com",
					Discriminator = "User"
				};
				await serviceProvider.GetRequiredService<IUserService>().RegisterUser(
					user,
					Guid.NewGuid().ToString(),
					new [] { groupName });
			}
			else
			{
				_host = ServerBuilder.CreateServer(new ServerBuilderOptions
				{
					UserPrincipalFactory = _ => Task.FromResult<ClaimsPrincipal>(null),
				});
				_scope = _host.Services.CreateScope();
				serviceProvider = _scope.ServiceProvider;
			}

			// Arrange.
			var crudService = serviceProvider.GetRequiredService<ICrudService>();
			await using var seedDbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<CisDBContext>();

			var ownerId = Guid.NewGuid();

			var entity = new EntityFactory<T>(10)
				.UseAttributes()
				.UseReferences()
				.UseOwner(ownerId)
				.Generate()
				.First();
			seedDbContext.Add(entity);
			await seedDbContext.SaveChangesAsync();

			var updatedEntity = new EntityFactory<T>()
				.UseAttributes()
				.UseOwner(ownerId)
				.Generate()
				.First();
			updatedEntity.Id = entity.Id;

			// Act.
			Func<Task> act = async () => await crudService.Update(updatedEntity);

			// Assert.
			if (message == null)
			{
				act.Should().NotThrow($"{groupName} should be allowed to read {model.GetType().Name}");
			}
			else
			{
				act
					.Should()
					.Throw<AggregateException>($"{groupName} should not be allowed to read {model.GetType().Name}")
					.WithInnerException<InvalidOperationException>()
					.And
					.Message
					.Should()
					.Contain(message);
			}
			// % protected region % [Overwrite update security test here] end
		}
	}
}