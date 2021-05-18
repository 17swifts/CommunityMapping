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
using APITests.EntityObjects.Models;
using SeleniumTests.Setup;
using SeleniumTests.Utils;
using SeleniumTests.ViewModels.Pages.CRUD.RegionalAreaEntityCrud.Internal;
using SeleniumTests.ViewModels.Pages.Crud.Internal;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.ViewModels.Pages.CRUD.RegionalAreaEntityCrud
{
	public class CreateRegionalAreaEntityPage : RegionalAreaEntityAttributeCollection
	{
		// % protected region % [Override class properties here] off begin
		public string Url => ContextConfiguration.BaseUrl + "/admin/regionalAreaEntity/create";
		public CrudCreateButtons ActionButtons => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public CreateRegionalAreaEntityPage(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end
		// % protected region % [Override Navigate here] off begin
		public void Navigate()
		{
			ContextConfiguration.WebDriver.GoToUrlExt(ContextConfiguration.WebDriverWait, Url);
		}
		// % protected region % [Override Navigate here] end

		// % protected region % [Override set values here] off begin
		public void SetValues(RegionalAreaEntity regionalAreaEntity)
		{
			Sa2id.Value = regionalAreaEntity.Sa2id;
			Sa3id.Value = regionalAreaEntity.Sa3id;
			Sa3name.Value = regionalAreaEntity.Sa3name;
			Numofpph.Value = regionalAreaEntity.Numofpph.ToString();
			Percentpphperday.Value = regionalAreaEntity.Percentpphperday.ToString();
			Sa2name.Value = regionalAreaEntity.Sa2name;
			Indigenous.Value = regionalAreaEntity.Indigenous.ToString();
			Nonindigenous.Value = regionalAreaEntity.Nonindigenous.ToString();
			Irsd.Value = regionalAreaEntity.Irsd.ToString();
			Irsad.Value = regionalAreaEntity.Irsad.ToString();
			Ier.Value = regionalAreaEntity.Ier.ToString();
			Ieo.Value = regionalAreaEntity.Ieo.ToString();
			GapScore.Value = regionalAreaEntity.GapScore.ToString();
			Noservices.Value = regionalAreaEntity.Noservices.ToString();
			Totalinvestment.Value = regionalAreaEntity.Totalinvestment.ToString();
			ServicesIds.Value = regionalAreaEntity.ServicesIds?.Select(x => x.ToString());
		}
		// % protected region % [Override set values here] end

		// % protected region % [Override get values here] off begin
		public RegionalAreaEntity GetValues()
		{
			var regionalAreaEntity =  new RegionalAreaEntity
			{
				Sa2id = Sa2id.Value,
				Sa3id = Sa3id.Value,
				Sa3name = Sa3name.Value,
				Numofpph = Numofpph.Value.ToNullableInt(),
				Percentpphperday = Percentpphperday.Value.ToNullableDouble(),
				Sa2name = Sa2name.Value,
				Indigenous = Indigenous.Value.ToNullableInt(),
				Nonindigenous = Nonindigenous.Value.ToNullableInt(),
				Irsd = Irsd.Value.ToNullableInt(),
				Irsad = Irsad.Value.ToNullableInt(),
				Ier = Ier.Value.ToNullableInt(),
				Ieo = Ieo.Value.ToNullableInt(),
				GapScore = GapScore.Value.ToNullableDouble(),
				Noservices = Noservices.Value.ToNullableInt(),
				Totalinvestment = Totalinvestment.Value.ToNullableDouble(),
			};

			regionalAreaEntity.ServicesIds = ServicesIds.Value.Select(Guid.Parse).ToList();;
			return regionalAreaEntity;
		}
		// % protected region % [Override get values here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}