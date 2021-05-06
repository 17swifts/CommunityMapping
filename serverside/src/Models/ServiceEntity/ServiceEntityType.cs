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
using Cis.Enums;
using Cis.Graphql.Helpers;
using Cis.Helpers;
using Cis.Services;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// % protected region % [Add any further imports here] off begin
// % protected region % [Add any further imports here] end

namespace Cis.Models
{
	/// <summary>
	/// The GraphQL type for returning data in GraphQL queries
	/// </summary>
	public class ServiceEntityType : ObjectGraphType<ServiceEntity>
	{
		public ServiceEntityType()
		{

			// Add model fields to type
			Field(o => o.Id, type: typeof(IdGraphType));
			Field(o => o.Created, type: typeof(DateTimeGraphType));
			Field(o => o.Modified, type: typeof(DateTimeGraphType));
			Field(o => o.Name, type: typeof(StringGraphType));
			Field(o => o.Category, type: typeof(StringGraphType));
			Field(o => o.Servicetype, type: typeof(EnumerationGraphType<Servicetype>)).Description(@"Whether the service is permanent or temporary ");
			Field(o => o.Noservicedays, type: typeof(IntGraphType)).Description(@"Number of days the service is operating");
			// % protected region % [Add any extra GraphQL fields here] off begin
			// % protected region % [Add any extra GraphQL fields here] end

			// Add entity references
			Field(o => o.RegionalAreaId, type: typeof(IdGraphType));

			// GraphQL reference to entity RegionalAreaEntity via reference RegionalArea
			Field<RegionalAreaEntityType, RegionalAreaEntity>()
				.Name("RegionalArea")
				.ResolveAsync(async context =>
				{
					if (!context.Source.RegionalAreaId.HasValue)
					{
						return null;
					}

					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid?, RegionalAreaEntity>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetRegionalAreaForServiceEntity",
						async keys =>
						{
							var results = await QueryHelpers.BuildQueryResolver<RegionalAreaEntity>(
								context,
								x => keys.Contains(x.Id));
							return results.ToDictionary(x => new Guid?(x.Id), x => x);
						});

					return loader.LoadAsync(context.Source.RegionalAreaId);
				});

			// GraphQL many to many reference to entity  via reference Services
			Field<ListGraphType<ServiceCommissioningBodiesServicesType>, IEnumerable<ServiceCommissioningBodiesServices>>()
				.Name("ServiceCommissioningBodiess")
				.AddCommonArguments()
				.ResolveAsync(async context =>
				{
					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, ServiceCommissioningBodiesServices>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetServiceCommissioningBodiessForServiceEntity",
						async keys =>
						{
							var args = new CommonArguments(context);
							var query = QueryHelpers.CreateResolveFunction<ServiceCommissioningBodiesServices>(context, new ReadOptions {DisableAudit = true});
							var results = await query
								.Where(x => keys.Contains(x.ServicesId))
								.Select(x => x.ServicesId)
								.Distinct()
								.SelectMany(x => query
									.Where(y => y.ServicesId == x)
									.AddIdCondition(args.Id)
									.AddIdsCondition(args.Ids)
									.AddWhereFilter(args.Where)
									.AddConditionalWhereFilter(args.Conditions)
									.AddConditionalHasFilter(args.Has, ((CisGraphQlContext) context.UserContext).ServiceProvider)
									.AddOrderBys(args.OrderBy)
									.AddSkip(args.Skip)
									.AddTake(args.Take))
								.ToListAsync(context.CancellationToken);
							return results.ToLookup(x => x.ServicesId, x => x);
						});

					return loader.LoadAsync(context.Source.Id);
				});

			// % protected region % [Add any extra GraphQL references here] off begin
			// % protected region % [Add any extra GraphQL references here] end
		}
	}

	/// <summary>
	/// The GraphQL input type for mutation input
	/// </summary>
	public class ServiceEntityInputType : InputObjectGraphType<ServiceEntity>
	{
		public ServiceEntityInputType()
		{
			Name = "ServiceEntityInput";
			Description = "The input object for adding a new ServiceEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");
			Field<StringGraphType>("Name");
			Field<StringGraphType>("Category");
			Field<EnumerationGraphType<Servicetype>>("Servicetype").Description = @"Whether the service is permanent or temporary ";
			Field<IntGraphType>("Noservicedays").Description = @"Number of days the service is operating";

			// Add entity references
			Field<IdGraphType>("RegionalAreaId");

			// Add references to foreign models to allow nested creation
			Field<RegionalAreaEntityInputType>("RegionalArea");
			Field<ListGraphType<ServiceCommissioningBodiesServicesInputType>>("ServiceCommissioningBodiess");

			// % protected region % [Add any extra GraphQL input fields here] off begin
			// % protected region % [Add any extra GraphQL input fields here] end
		}
	}

}