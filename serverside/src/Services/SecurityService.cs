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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cis.Models;
using Cis.Helpers;
using Cis.Security;
using Cis.Services.Interfaces;
using Cis.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cis.Services
{
	public enum DATABASE_OPERATION
	{
		CREATE,
		READ,
		UPDATE,
		DELETE
	}

	public class SecurityService : ISecurityService
	{
		/// <summary>
		/// The default access rule as defined by the security model
		/// </summary>
		private const bool ALLOW_DEFAULT = false;

		private readonly UserManager<User> _userManager;
		private readonly IServiceProvider _serviceProvider;

		// % protected region % [Add any additional fields here] off begin
		// % protected region % [Add any additional fields here] end

		public SecurityService(
			// % protected region % [Add any constructor arguments here] off begin
			// % protected region % [Add any constructor arguments here] end
			UserManager<User> userManager,
			IServiceProvider serviceProvider)
		{
			_userManager = userManager;
			_serviceProvider = serviceProvider;
			// % protected region % [Add any constructor logic here] off begin
			// % protected region % [Add any constructor logic here] end
		}

		/// <summary>
		/// Creates the filter function for reading, updating or deleting data from an enumeration of models
		/// </summary>
		/// <param name="operation">The database operation that is being performed</param>
		/// <param name="identityService">The identity service to fetch the user from</param>
		/// <param name="userManager">A userManager to pass to the ACLs</param>
		/// <param name="dbContext">A dbContext to pass to the ACLs</param>
		/// <param name="serviceProvider">Service provider to pass to the ACLs</param>
		/// <typeparam name="TModel">The type of the model to add security to</typeparam>
		/// <returns>An expression that can be user for the where condition of a linq query</returns>
		public static Expression<Func<TModel, bool>> CreateSecurityFilter<TModel>(
			DATABASE_OPERATION operation,
			IIdentityService identityService,
			UserManager<User> userManager,
			CisDBContext dbContext,
			IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{

			// % protected region % [Customise CreateSecurityFilter logic here] off begin
			identityService.RetrieveUserAsync().Wait();
			var model = new TModel();
			var userGroups = identityService.Groups;
			var userModelAcls = model.Acls
				.Where(x => userGroups.Contains(x.Group) || x.IsVisitorAcl)
				.ToList();

			Expression<Func<TModel, bool>> baseRule = _ => false;

			var filter = Expression.OrElse(baseRule.Body, baseRule.Body);
			var param = Expression.Parameter(typeof(TModel), "model");

			if (!userModelAcls.Any())
			{
				// If we have no rules on this model then we should inherit from the model driven base rule
				Expression<Func<TModel, bool>> defaultFilter = _ => ALLOW_DEFAULT;
				filter = Expression.OrElse(filter, defaultFilter.Body);
			}
			else
			{
				// Otherwise combine the filter on acl with any existing filters
				var securityContext = new SecurityContext
				{
					DbContext = dbContext,
					UserManager = userManager,
					Groups = identityService.Groups,
					ServiceProvider = serviceProvider,
				};

				var acls = operation switch
				{
					DATABASE_OPERATION.READ => userModelAcls
						.Select(acl => acl.GetReadConditions<TModel>(identityService.User, securityContext))
						.ToList(),
					DATABASE_OPERATION.UPDATE => userModelAcls
						.Select(acl => acl.GetUpdateConditions<TModel>(identityService.User, securityContext))
						.ToList(),
					DATABASE_OPERATION.DELETE => userModelAcls
						.Select(acl => acl.GetDeleteConditions<TModel>(identityService.User, securityContext))
						.ToList(),
					_ => throw new InvalidOperationException("Invalid query filter operation.")
				};

				acls = acls.Select(acl =>
				{
					var aclParam = acl.Parameters.First();
					return ParameterReplacer
						.Replace(param, aclParam, acl) as Expression<Func<TModel, bool>>;
				}).ToList();

				filter = acls.Aggregate(filter, (current, expression) =>
						Expression.OrElse(current, expression.Body));
			}

			return Expression.Lambda<Func<TModel, bool>>(filter, param);
			// % protected region % [Customise CreateSecurityFilter logic here] end
		}

		/// <summary>
		/// Creates the filter function for reading data from an enumeration of models
		/// </summary>
		/// <param name="identityService"></param>
		/// <param name="userManager">A userManager to pass to the ACLs</param>
		/// <param name="dbContext">A dbContext to pass to the ACLs</param>
		/// <param name="serviceProvider">Service provider to pass to the ACLs</param>
		/// <typeparam name="TModel">The type of the model to add security to</typeparam>
		/// <returns>An expression that can be used for the where condition of a linq query</returns>
		public static Expression<Func<TModel, bool>> CreateReadSecurityFilter<TModel>(
			IIdentityService identityService,
			UserManager<User> userManager,
			CisDBContext dbContext,
			IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{
			return CreateSecurityFilter<TModel>(DATABASE_OPERATION.READ, identityService, userManager, dbContext, serviceProvider);
		}

		/// <summary>
		/// Creates the filter function for reading data from an enumeration of models.
		/// </summary>
		/// <param name="serviceProvider">A service provider that will resolve all the necessary services for creating
		/// security.</param>
		/// <typeparam name="TModel">The type of entity to create the security condition for.</typeparam>
		/// <returns>An expression that can be used for the where condition of a linq query</returns>
		public static Expression<Func<TModel, bool>> CreateReadSecurityFilter<TModel>(IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{
			var identityService = serviceProvider.GetRequiredService<IIdentityService>();
			var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
			var dbContext = serviceProvider.GetRequiredService<CisDBContext>();
			return CreateSecurityFilter<TModel>(DATABASE_OPERATION.READ, identityService, userManager, dbContext, serviceProvider);
		}

		/// <summary>
		/// Creates the filter function for updating data from an enumeration of models
		/// </summary>
		/// <param name="identityService"></param>
		/// <param name="userManager">A userManager to pass to the ACLs</param>
		/// <param name="dbContext">A dbContext to pass to the ACLs</param>
		/// <param name="serviceProvider">Service provider to pass to the ACLs</param>
		/// <typeparam name="TModel">The type of the model to add security to</typeparam>
		/// <returns>An expression that can be used for the where condition of a linq query</returns>
		public static Expression<Func<TModel, bool>> CreateUpdateSecurityFilter<TModel>(
			IIdentityService identityService,
			UserManager<User> userManager,
			CisDBContext dbContext,
			IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{
			return CreateSecurityFilter<TModel>(DATABASE_OPERATION.UPDATE, identityService, userManager, dbContext, serviceProvider);
		}

		/// <summary>
		/// Creates the filter function for deleting data from an enumeration of models
		/// </summary>
		/// <param name="identityService"></param>
		/// <param name="userManager">A userManager to pass to the ACLs</param>
		/// <param name="dbContext">A dbContext to pass to the ACLs</param>
		/// <param name="serviceProvider">Service provider to pass to the ACLs</param>
		/// <typeparam name="TModel">The type of the model to add security to</typeparam>
		/// <returns>An expression that can be used for the where condition of a linq query</returns>
		public static Expression<Func<TModel, bool>> CreateDeleteSecurityFilter<TModel>(
			IIdentityService identityService,
			UserManager<User> userManager,
			CisDBContext dbContext,
			IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{
			return CreateSecurityFilter<TModel>(DATABASE_OPERATION.DELETE, identityService, userManager, dbContext, serviceProvider);
		}

		public async Task<List<string>> CheckDbSecurityChanges(IIdentityService identityService, CisDBContext dbContext)
		{
			// % protected region % [Customise CheckDbSecurityChanges logic here] off begin
			await identityService.RetrieveUserAsync();

			var securityContext = new SecurityContext
			{
				DbContext = dbContext,
				UserManager = _userManager,
				Groups = identityService.Groups,
				ServiceProvider = _serviceProvider,
			};

			return dbContext.ChangeTracker
				.Entries()
				.Where(entry => entry.Entity is IOwnerAbstractModel)
				.GroupBy(entry => entry.Entity.GetType())
				.ToDictionary(grouping => grouping.Key, grouping =>
				{
					var entityName = grouping.First().Entity.GetType().Name;
					var modelErrors = new List<string>();

					// If there is no mutating actions then continue
					var actions = grouping.Select(e => e.State).ToList();
					if (!(actions.Contains(EntityState.Added) ||
						actions.Contains(EntityState.Deleted) ||
						actions.Contains(EntityState.Modified)))
					{
						return modelErrors;
					}

					// Even though we have filtered this before we need this check for the compiler
					if (!(grouping.FirstOrDefault()?.Entity is IOwnerAbstractModel model))
					{
						modelErrors.Add("Unknown model type");
						return modelErrors;
					}

					// If the model has no security rules that apply to us then just fall back to the default rule
					var schemes = model.Acls
						.Where(scheme => identityService.Groups.Contains(scheme.Group) || scheme.Group == null || scheme.IsVisitorAcl)
						.ToList();
					if (!schemes.Any())
					{
						if (!ALLOW_DEFAULT)
						{
							modelErrors.Add($"No applicable schemes for this group on the model '{model.GetType()}'");
						}

						return modelErrors;
					}

					// Group on each type of operation that is being performed on the entity
					var entityStates = grouping.GroupBy(entrySet => entrySet.State, (state, entityEntries) =>
					{
						return new
						{
							State = state,
							Entities = entityEntries.Select(e => (IOwnerAbstractModel) e.Entity),
						};
					});

					// For each type of mutation call the rule on the acls that is applicable to that model
					foreach (var state in entityStates)
					{
						// Construct a list of auth functions to iterate over
						var authFunctionList = new List<Func<User, IEnumerable<IAbstractModel>, SecurityContext, bool>>();
						AddAuthFunctions(authFunctionList, schemes, state.State);

						// Iterate over each of the auth functions, and work out weather we have permissions to do this
						// operation. Permissions are additive so we can use a bitwise or to represent the adding of
						// permissions
						var canOperate = false;
						foreach (var func in authFunctionList)
						{
							canOperate |= func(identityService.User, state.Entities, securityContext);

							// Once we hit a true we can break out of the loop since (true | anything == true)
							if (canOperate)
							{
								break;
							}
						}

						// After running the auth functions if we still have no permissions then throw an error message
						if (!canOperate)
						{
							AddError(modelErrors, state.State, entityName);
						}
					}

					return modelErrors;
				})
				.Aggregate(new List<string>(), (list, pair) =>
				{
					// Combine the lists of error messages for each model to a single list of errors ready to return
					list.AddRange(pair.Value);
					return list;
				});
			// % protected region % [Customise CheckDbSecurityChanges logic here] end
		}

		/// <summary>
		/// Adds an error to the list of errors
		/// </summary>
		/// <param name="errors">The list of errors to append to</param>
		/// <param name="operation">The type of operation being denied access to</param>
		/// <param name="entityName">The name of the entity being denied access to</param>
		private static void AddError(ICollection<string> errors, EntityState operation, string entityName)
		{
			errors.Add($"The current user does not have permissions to perform {operation} on {entityName}");
		}

		/// <summary>
		/// Adds the correct auth function to a list of funcs from the acls given a type of auth state
		/// </summary>
		/// <param name="funcs">The list of funcs to add to</param>
		/// <param name="acls">The list of acls to source the functions from</param>
		/// <param name="state">The type of change that is being performed</param>
		private static void AddAuthFunctions(
			ICollection<Func<User, IEnumerable<IAbstractModel>, SecurityContext, bool>> funcs,
			IEnumerable<IAcl> acls,
			EntityState state)
		{
			switch (state)
			{
				case EntityState.Added:
					foreach (var acl in acls)
					{
						funcs.Add(acl.GetCreate);
					}
					break;
				case EntityState.Modified:
					foreach (var acl in acls)
					{
						funcs.Add(acl.GetUpdate);
					}
					break;
				case EntityState.Deleted:
					foreach (var acl in acls)
					{
						funcs.Add(acl.GetDelete);
					}
					break;
				default:
					// Unchanged or untracked need no security checks
					funcs.Add((a,b,c) => true);
					break;
			}
		}

		/// <summary>
		/// Gets an aggregated version of the update acls for an entity
		/// </summary>
		/// <param name="user">The user trying to access the entity</param>
		/// <param name="groups">The groups that the user belongs to</param>
		/// <param name="operation"> The database operation the user is trying to perform  </param>
		/// <param name="serviceProvider">Service provider to pass to the ACLs</param>
		/// <typeparam name="TModel">The entity model the user wishes to read</typeparam>
		/// <returns>An expression that can be used for the where condition of a linq query</returns>
		public static Expression<Func<User, bool>> GetAggregatedUserModelAcls<TModel>(
			User user, 
			IList<string> groups, 
			DATABASE_OPERATION operation,
			IServiceProvider serviceProvider)
			where TModel : IOwnerAbstractModel, new()
		{
			var groupAcls = new TModel().Acls.Where(a => groups.Contains(a.Group));
			IEnumerable<Expression<Func<User, bool>>> operationAcls = null;
			switch (operation)
			{
				case DATABASE_OPERATION.READ:
					operationAcls = groupAcls.Select(acl => acl.GetReadConditions<User>(user, new SecurityContext
					{
						Groups = groups,
						DbContext = serviceProvider.GetRequiredService<CisDBContext>(),
						ServiceProvider = serviceProvider,
						UserManager = serviceProvider.GetRequiredService<UserManager<User>>(),
					}));
					break;
				case DATABASE_OPERATION.UPDATE:
					operationAcls = groupAcls.Select(acl => acl.GetUpdateConditions<User>(user, new SecurityContext
					{
						Groups = groups,
						DbContext = serviceProvider.GetRequiredService<CisDBContext>(),
						ServiceProvider = serviceProvider,
						UserManager = serviceProvider.GetRequiredService<UserManager<User>>(),
					}));
					break;
				case DATABASE_OPERATION.DELETE:
					operationAcls = groupAcls.Select(acl => acl.GetDeleteConditions<User>(user, new SecurityContext
					{
						Groups = groups,
						DbContext = serviceProvider.GetRequiredService<CisDBContext>(),
						ServiceProvider = serviceProvider,
						UserManager = serviceProvider.GetRequiredService<UserManager<User>>(),
					}));
					break;
				default:
					break;
			}
			return ExpressionHelper.OrExpressions(operationAcls);
		}
	}
}