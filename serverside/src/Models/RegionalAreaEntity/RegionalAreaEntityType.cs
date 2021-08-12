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
	public class RegionalAreaEntityType : ObjectGraphType<RegionalAreaEntity>
	{
		public RegionalAreaEntityType()
		{

			// Add model fields to type
			Field(o => o.Id, type: typeof(NonNullGraphType<IdGraphType>));
			Field(o => o.Created, type: typeof(NonNullGraphType<DateTimeGraphType>));
			Field(o => o.Modified, type: typeof(NonNullGraphType<DateTimeGraphType>));
			Field(o => o.Sa2id, type: typeof(StringGraphType));
			Field(o => o.Sa3id, type: typeof(StringGraphType));
			Field(o => o.Sa3name, type: typeof(StringGraphType));
			Field(o => o.Numofpph, type: typeof(IntGraphType)).Description(@"Potentially Preventable Hospitalisations");
			Field(o => o.Percentpphperday, type: typeof(FloatGraphType));
			Field(o => o.Sa2name, type: typeof(StringGraphType));
			Field(o => o.Indigenous, type: typeof(IntGraphType));
			Field(o => o.Nonindigenous, type: typeof(IntGraphType));
			Field(o => o.Irsd, type: typeof(IntGraphType)).Description(@"The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. ");
			Field(o => o.Irsad, type: typeof(IntGraphType)).Description(@"The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.");
			Field(o => o.Ier, type: typeof(IntGraphType)).Description(@"The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. ");
			Field(o => o.Ieo, type: typeof(IntGraphType)).Description(@"The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. ");
			Field(o => o.GapScore, type: typeof(FloatGraphType));
			// % protected region % [Add any extra GraphQL fields here] off begin
			// % protected region % [Add any extra GraphQL fields here] end

			// Add entity references

			// GraphQL reference to entity ServiceEntity via reference Services
			Field<ListGraphType<NonNullGraphType<ServiceEntityType>>, IEnumerable<ServiceEntity>>()
				.Name("Servicess")
				.AddCommonArguments()
				.ResolveAsync(async context =>
				{
					var graphQlContext = (CisGraphQlContext) context.UserContext;
					var accessor = graphQlContext.ServiceProvider.GetRequiredService<IDataLoaderContextAccessor>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid?, ServiceEntity>(
						string.Join("-", context.ResponsePath.Where(x => x is string)) + "GetServicessForRegionalAreaEntity",
						async keys =>
						{
							var args = new CommonArguments(context);
							var query = QueryHelpers.CreateResolveFunction<ServiceEntity>(context, new ReadOptions {DisableAudit = true});
							var results = await query
								.Where(x => x.RegionalAreaId.HasValue && keys.Contains(x.RegionalAreaId))
								.Select(x => x.RegionalAreaId.Value)
								.Distinct()
								.SelectMany(x => query
									.Where(y => y.RegionalAreaId == x)
									.AddIdCondition(args.Id)
									.AddIdsCondition(args.Ids)
									.AddWhereFilter(args.Where)
									.AddConditionalWhereFilter(args.Conditions)
									.AddConditionalHasFilter(args.Has, ((CisGraphQlContext) context.UserContext).ServiceProvider)
									.AddOrderBys(args.OrderBy)
									.AddSkip(args.Skip)
									.AddTake(args.Take))
								.ToListAsync(context.CancellationToken);
							return results.ToLookup(x => x.RegionalAreaId, x => x);
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
	public class RegionalAreaEntityInputType : InputObjectGraphType<RegionalAreaEntity>
	{
		public RegionalAreaEntityInputType()
		{
			Name = "RegionalAreaEntityInput";
			Description = "The input object for adding a new RegionalAreaEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");
			Field<StringGraphType>("Sa2id");
			Field<StringGraphType>("Sa3id");
			Field<StringGraphType>("Sa3name");
			Field<IntGraphType>("Numofpph").Description = @"Potentially Preventable Hospitalisations";
			Field<FloatGraphType>("Percentpphperday");
			Field<StringGraphType>("Sa2name");
			Field<IntGraphType>("Indigenous");
			Field<IntGraphType>("Nonindigenous");
			Field<IntGraphType>("Irsd").Description = @"The Index of Relative Socio-economic Disadvantage (IRSD) is a general socio-economic index that summarises a range of information about the economic and social conditions of people and households within an area. ";
			Field<IntGraphType>("Irsad").Description = @"The Index of Relative Socio-economic Advantage and Disadvantage (IRSAD) summarises information about the economic and social conditions of people and households within an area, including both relative advantage and disadvantage measures.";
			Field<IntGraphType>("Ier").Description = @"The Index of Economic Resources (IER) focuses on the financial aspects of relative socio-economic advantage and disadvantage, by summarising variables related to income and wealth. ";
			Field<IntGraphType>("Ieo").Description = @"The Index of Education and Occupation (IEO) is designed to reflect the educational and occupational level of communities. ";
			Field<FloatGraphType>("GapScore");

			// Add entity references

			// Add references to foreign models to allow nested creation
			Field<ListGraphType<ServiceEntityInputType>>("Servicess");

			// % protected region % [Add any extra GraphQL input fields here] off begin
			// % protected region % [Add any extra GraphQL input fields here] end
		}
	}

}