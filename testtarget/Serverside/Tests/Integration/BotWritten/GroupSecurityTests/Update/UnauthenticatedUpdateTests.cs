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
using System.Threading.Tasks;
using Cis.Models;
using ServersideTests.Helpers;
using Xunit;
// % protected region % [Add any extra imports here] off begin
// % protected region % [Add any extra imports here] end

// to prevent warnings of using the model type in theory data.
#pragma warning disable xUnit1026
#pragma warning disable S2699

namespace ServersideTests.Tests.Integration.BotWritten.GroupSecurityTests.Update
{
	[Trait("Category", "BotWritten")]
	[Trait("Category", "Integration")]
	[Trait("Category", "Security")]
	public class UnauthenticatedUpdateTests : BaseUpdateTest
	{
		public UnauthenticatedUpdateTests()
		{
			// % protected region % [Add constructor logic here] off begin
			// % protected region % [Add constructor logic here] end
		}

		public static TheoryData<IAbstractModel, string, string> UnauthenticatedUpdateSecurityData 
		{
			get
			{
				var data = new TheoryData<IAbstractModel, string,string>
				{
					// % protected region % [Configure entity theory data for Unauthenticated here] off begin
					{new RegionalAreaEntity(), SecurityStringHelper.UserPermissionDenied, null},
					{new ServiceEntity(), SecurityStringHelper.UserPermissionDenied, null},
					{new RegionalAreaTimelineEventsEntity(), SecurityStringHelper.UserPermissionDenied, null},
					// % protected region % [Configure entity theory data for Unauthenticated here] end
				};
				// % protected region % [Add any extra theory data here] off begin
				// % protected region % [Add any extra theory data here] end
				return data;
			}
		}

		[Theory]
		[MemberData(nameof(UnauthenticatedUpdateSecurityData))]
		public async Task UnauthenticatedUpdateSecurityTests<T>(T model, string message, string groupName)
			where T : class, IOwnerAbstractModel, new()
		{
			// % protected region % [Overwrite update security test here] off begin
			await UpdateTest(model, message, groupName);
			// % protected region % [Overwrite update security test here] end
		}
	}
}