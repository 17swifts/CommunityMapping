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
using Cis.Graphql.Helpers;
using Cis.Services;
using GraphQL.Types;
using GraphQL.DataLoader;
using GraphQL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

namespace Cis.Models 
{
	/// <summary>
	/// The GraphQL type for returning data in GraphQL queries
	/// </summary>
	public class ServiceCommissioningBodiesServicesType : ObjectGraphType<ServiceCommissioningBodiesServices>
	{
		public ServiceCommissioningBodiesServicesType()
		{

			// Add model fields to type
			Field(o => o.Id, type: typeof(IdGraphType));
			Field(o => o.Created, type: typeof(DateTimeGraphType));
			Field(o => o.Modified, type: typeof(DateTimeGraphType));

			Field(o => o.ServiceCommissioningBodiesId, type: typeof(IdGraphType));
			Field(o => o.ServicesId, type: typeof(IdGraphType));

			// % protected region % [Add any extra GraphQL fields here] off begin
			// % protected region % [Add any extra GraphQL fields here] end

			// GraphQL reference to entity ServiceCommissioningBodyEntity via reference ServiceCommissioningBodyEntity
			Field<ServiceCommissioningBodyEntityType, ServiceCommissioningBodyEntity>()
				.Name("ServiceCommissioningBodies")
				.ResolveAsync(async context =>
				{
					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, ServiceCommissioningBodyEntity>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetServiceCommissioningBodiesForServiceCommissioningBodiesServices",
						async keys =>
						{
							var results = await QueryHelpers.BuildQueryResolver<ServiceCommissioningBodyEntity>(
								context,
								x => keys.Contains(x.Id));
							return results.ToDictionary(x => x.Id, x => x);
						});

					return loader.LoadAsync(context.Source.ServiceCommissioningBodiesId);
				});

			// GraphQL reference to entity ServiceEntity via reference ServiceEntity
			Field<ServiceEntityType, ServiceEntity>()
				.Name("Services")
				.ResolveAsync(async context =>
				{
					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, ServiceEntity>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetServicesForServiceCommissioningBodiesServices",
						async keys =>
						{
							var results = await QueryHelpers.BuildQueryResolver<ServiceEntity>(
								context,
								x => keys.Contains(x.Id));
							return results.ToDictionary(x => x.Id, x => x);
						});

					return loader.LoadAsync(context.Source.ServicesId);
				});

			// % protected region % [Add any extra GraphQL references here] off begin
			// % protected region % [Add any extra GraphQL references here] end
		}
	}

	/// <summary>
	/// The GraphQL input type for mutation input
	/// </summary>
	public class ServiceCommissioningBodiesServicesInputType : InputObjectGraphType<ServiceCommissioningBodiesServices>
	{
		public ServiceCommissioningBodiesServicesInputType()
		{
			Name = "ServiceCommissioningBodiesServicesInput";
			Description = "The input object for adding a new ServiceCommissioningBodiesServices";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");
			Field<IdGraphType>("ServiceCommissioningBodiesId");
			Field<IdGraphType>("ServicesId");

			// Add references to foreign objects
			Field<ServiceCommissioningBodyEntityInputType>("ServiceCommissioningBodies");
			Field<ServiceEntityInputType>("Services");

			// % protected region % [Add any extra GraphQL input fields here] off begin
			// % protected region % [Add any extra GraphQL input fields here] end
		}
	}
}