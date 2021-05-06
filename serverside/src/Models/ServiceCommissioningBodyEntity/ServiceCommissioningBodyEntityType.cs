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
	public class ServiceCommissioningBodyEntityType : ObjectGraphType<ServiceCommissioningBodyEntity>
	{
		public ServiceCommissioningBodyEntityType()
		{

			// Add model fields to type
			Field(o => o.Id, type: typeof(IdGraphType));
			Field(o => o.Created, type: typeof(DateTimeGraphType));
			Field(o => o.Modified, type: typeof(DateTimeGraphType));
			Field(o => o.Email, type: typeof(StringGraphType));
			Field(o => o.Name, type: typeof(StringGraphType));
			Field(o => o.Location, type: typeof(StringGraphType));
			Field(o => o.ProfileImageId, type: typeof(IdGraphType));
			// % protected region % [Add any extra GraphQL fields here] off begin
			// % protected region % [Add any extra GraphQL fields here] end

			// Add entity references

			// GraphQL many to many reference to entity ServiceEntity via reference Services
			Field<ListGraphType<ServiceCommissioningBodiesServicesType>, IEnumerable<ServiceCommissioningBodiesServices>>()
				.Name("Servicess")
				.AddCommonArguments()
				.ResolveAsync(async context =>
				{
					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, ServiceCommissioningBodiesServices>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetServicessForServiceCommissioningBodyEntity",
						async keys =>
						{
							var args = new CommonArguments(context);
							var query = QueryHelpers.CreateResolveFunction<ServiceCommissioningBodiesServices>(context, new ReadOptions {DisableAudit = true});
							var results = await query
								.Where(x => keys.Contains(x.ServiceCommissioningBodiesId))
								.Select(x => x.ServiceCommissioningBodiesId)
								.Distinct()
								.SelectMany(x => query
									.Where(y => y.ServiceCommissioningBodiesId == x)
									.AddIdCondition(args.Id)
									.AddIdsCondition(args.Ids)
									.AddWhereFilter(args.Where)
									.AddConditionalWhereFilter(args.Conditions)
									.AddConditionalHasFilter(args.Has, ((CisGraphQlContext) context.UserContext).ServiceProvider)
									.AddOrderBys(args.OrderBy)
									.AddSkip(args.Skip)
									.AddTake(args.Take))
								.ToListAsync(context.CancellationToken);
							return results.ToLookup(x => x.ServiceCommissioningBodiesId, x => x);
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
	public class ServiceCommissioningBodyEntityInputType : InputObjectGraphType<ServiceCommissioningBodyEntity>
	{
		public ServiceCommissioningBodyEntityInputType()
		{
			Name = "ServiceCommissioningBodyEntityInput";
			Description = "The input object for adding a new ServiceCommissioningBodyEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");
			Field<StringGraphType>("Name");
			Field<StringGraphType>("Location");
			Field(o => o.ProfileImageId, type: typeof(IdGraphType));

			// Add entity references

			// Add references to foreign models to allow nested creation
			Field<ListGraphType<ServiceCommissioningBodiesServicesInputType>>("Servicess");

			// % protected region % [Add any extra GraphQL input fields here] off begin
			// % protected region % [Add any extra GraphQL input fields here] end
		}
	}

	/// <summary>
	/// The GraphQL input type for creating a user entity
	/// </summary>
	public class ServiceCommissioningBodyEntityCreateInputType : InputObjectGraphType<ServiceCommissioningBodyEntity>
	{
		public ServiceCommissioningBodyEntityCreateInputType()
		{
			Name = "ServiceCommissioningBodyEntityCreateInput";
			Description = "The input object for creating a new ServiceCommissioningBodyEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");

			// Add fields specific to a user entity
			Field<StringGraphType>("Email");
			Field<StringGraphType>("Password");

			Field<StringGraphType>("Name");
			Field<StringGraphType>("Location");
			Field(o => o.ProfileImageId, type: typeof(IdGraphType));

			// Add entity references


			// Add references to foreign models to allow nested creation
			Field<ListGraphType<ServiceCommissioningBodiesServicesInputType>>("Servicess");

			// % protected region % [Add any extra GraphQL create input fields here] off begin
			// % protected region % [Add any extra GraphQL create input fields here] end
		}
	}
}