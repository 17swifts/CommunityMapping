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

using AutoFixture;
using TestDataLib;

namespace EntityObject.Enums
{
	public enum Categories
	{
		ABORIGINAL_SERVICE,
		ACCOMMODATION_SERVICE,
		ADVOCACY_SERVICE,
		ALCOHOL_AND_DRUG_SERVICE,
		ARTS_AND_CREATIVES,
		COMMUNITY_CENTRES_HALLS_AND_FACILITIES,
		COMMUNITY_CLUB,
		CRISIS_AND_EMERGENCY_SERVICE,
		CULTURAL_AND_MIGRANT_SERVICE,
		DISABILITY_SERVICE,
		EDUCATION,
		EMPLOYMENT_AND_TRAINING,
		HEALTH_SERVICE,
		INFORMATION_AND_COUNSELLING,
		LEGAL_SERVICE,
		RELIGION_AND_PHILOSOPHY,
		SELF_HELP,
		SPORT,
		TRANSPORT_SERVICE,
		WELFARE_ASSISTANCE,
		YOUTH_SERVICE,
	}

	internal static class CategoriesEnum
	{
		public static Categories GetRandomCategories() => new Fixture().Create<Categories>();

		public static string GetInvalidCategories()
		{
			return DataUtils.RandString(charType: CharType.FIXTURE_STRING);
		}
	}
}