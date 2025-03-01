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
	public class AdminEntityType : ObjectGraphType<AdminEntity>
	{
		public AdminEntityType()
		{

			// Add model fields to type
			Field(o => o.Id, type: typeof(NonNullGraphType<IdGraphType>));
			Field(o => o.Created, type: typeof(NonNullGraphType<DateTimeGraphType>));
			Field(o => o.Modified, type: typeof(NonNullGraphType<DateTimeGraphType>));
			Field(o => o.Email, type: typeof(StringGraphType));
			// % protected region % [Add any extra GraphQL fields here] off begin
			// % protected region % [Add any extra GraphQL fields here] end

			// Add entity references

			// % protected region % [Add any extra GraphQL references here] off begin
			// % protected region % [Add any extra GraphQL references here] end
		}
	}

	/// <summary>
	/// The GraphQL input type for mutation input
	/// </summary>
	public class AdminEntityInputType : InputObjectGraphType<AdminEntity>
	{
		public AdminEntityInputType()
		{
			Name = "AdminEntityInput";
			Description = "The input object for adding a new AdminEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");

			// Add entity references

			// Add references to foreign models to allow nested creation

			// % protected region % [Add any extra GraphQL input fields here] off begin
			// % protected region % [Add any extra GraphQL input fields here] end
		}
	}

	/// <summary>
	/// The GraphQL input type for creating a user entity
	/// </summary>
	public class AdminEntityCreateInputType : InputObjectGraphType<AdminEntity>
	{
		public AdminEntityCreateInputType()
		{
			Name = "AdminEntityCreateInput";
			Description = "The input object for creating a new AdminEntity";

			// Add entity fields
			Field<IdGraphType>("Id");
			Field<DateTimeGraphType>("Created");
			Field<DateTimeGraphType>("Modified");

			// Add fields specific to a user entity
			Field<StringGraphType>("Email");
			Field<StringGraphType>("Password");


			// Add entity references


			// Add references to foreign models to allow nested creation

			// % protected region % [Add any extra GraphQL create input fields here] off begin
			// % protected region % [Add any extra GraphQL create input fields here] end
		}
	}
}