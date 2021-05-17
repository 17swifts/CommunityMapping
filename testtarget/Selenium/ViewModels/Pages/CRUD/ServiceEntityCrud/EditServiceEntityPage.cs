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
	public class EditServiceEntityPage : ServiceEntityAttributeCollection
	{
		// % protected region % [Override class properties here] off begin
		public CrudCreateButtons ActionButtons => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public EditServiceEntityPage(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Override set values here] off begin
		public void SetValues(ServiceEntity serviceEntity)
		{
			Name.Value = serviceEntity.Name;
			Category.Value = serviceEntity.Category;
			Servicetype.Value = serviceEntity.Servicetype.ToString();
			Noservicedays.Value = serviceEntity.Noservicedays.ToString();
			Investment.Value = serviceEntity.Investment.ToString();
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
				Category = Category.Value,
				Servicetype = Servicetype.Value.ToEnum<Servicetype>(),
				Noservicedays = Noservicedays.Value.ToNullableInt(),
				Investment = Investment.Value.ToNullableDouble(),
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