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
using EntityObject.Enums;
using SeleniumTests.Setup;
using SeleniumTests.Utils;
using SeleniumTests.ViewModels.Pages.CRUD.ServiceEntityCrud.Internal;
using SeleniumTests.ViewModels.Pages.Crud.Internal;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.ViewModels.Pages.CRUD.ServiceEntityCrud
{
	public class CreateServiceEntityPage : ServiceEntityAttributeCollection
	{
		// % protected region % [Override class properties here] off begin
		public string Url => ContextConfiguration.BaseUrl + "/admin/serviceEntity/create";
		public CrudCreateButtons ActionButtons => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public CreateServiceEntityPage(ContextConfiguration contextConfiguration) : base(contextConfiguration)
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
		public void SetValues(ServiceEntity serviceEntity)
		{
			Name.Value = serviceEntity.Name;
			Description.Value = serviceEntity.Description;
			Servicetype.Value = serviceEntity.Servicetype.ToString();
			Category.Value = serviceEntity.Category.ToString();
			Active.Value = serviceEntity.Active.GetValueOrDefault();
			Noservicedays.Value = serviceEntity.Noservicedays.ToString();
			Investment.Value = serviceEntity.Investment.ToString();
			Startdate.Value = serviceEntity.Startdate.GetValueOrDefault();
			Enddate.Value = serviceEntity.Enddate.GetValueOrDefault();
			Gender.Value = serviceEntity.Gender.ToString();
			Agemin.Value = serviceEntity.Agemin.ToString();
			Agemax.Value = serviceEntity.Agemax.ToString();
			RegionalAreaId.Value = serviceEntity.RegionalAreaId == null ? string.Empty : serviceEntity.RegionalAreaId.ToString();
			ServiceCommissioningBodiesIds.Value = serviceEntity.ServiceCommissioningBodiesIds?.Select(x => x.ToString());
		}
		// % protected region % [Override set values here] end

		// % protected region % [Override get values here] off begin
		public ServiceEntity GetValues()
		{
			var serviceEntity =  new ServiceEntity
			{
				Name = Name.Value,
				Description = Description.Value,
				Servicetype = Servicetype.Value.ToEnum<Servicetype>(),
				Category = Category.Value.ToEnum<Categories>(),
				Active = Active.Value,
				Noservicedays = Noservicedays.Value.ToNullableInt(),
				Investment = Investment.Value.ToNullableDouble(),
				Startdate = Startdate.Value,
				Enddate = Enddate.Value,
				Gender = Gender.Value.ToEnum<Gender>(),
				Agemin = Agemin.Value.ToNullableInt(),
				Agemax = Agemax.Value.ToNullableInt(),
			};

			if (Guid.TryParse(RegionalAreaId.Value, out var regionalAreaId)) {
				serviceEntity.RegionalAreaId = regionalAreaId;
			}
			serviceEntity.ServiceCommissioningBodiesIds = ServiceCommissioningBodiesIds.Value.Select(Guid.Parse).ToList();;
			return serviceEntity;
		}
		// % protected region % [Override get values here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}