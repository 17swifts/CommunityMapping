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
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

namespace Cis.Models.Internal.Identity
{
	public class UserResult : ILoginResult
	{
		public string Type => "user-data";

		public Guid Id { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }

		public List<GroupResult> Groups { get; set; } = new();

		// % protected region % [Add any extra fields here] off begin
		// % protected region % [Add any extra fields here] end

		public UserResult()
		{
			// % protected region % [Add any extra parameterless constructor logic here] off begin
			// % protected region % [Add any extra parameterless constructor logic here] end
		}

		public UserResult(User user, IEnumerable<Group> groups)
		{
			Id = user.Id;
			Email = user.Email;
			UserName = user.UserName;

			if (groups != null)
			{
				Groups.AddRange(groups.Select(group => new GroupResult(group)));
			}

			// % protected region % [Add any extra constructor logic here] off begin
			// % protected region % [Add any extra constructor logic here] end
		}
	}
}
