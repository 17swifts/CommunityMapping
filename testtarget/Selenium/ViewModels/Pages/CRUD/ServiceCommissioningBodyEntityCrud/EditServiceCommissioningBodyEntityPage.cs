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
using APITests.Classes;
using APITests.EntityObjects.Models;
using SeleniumTests.Setup;
using SeleniumTests.Utils;
using SeleniumTests.ViewModels.Pages.CRUD.ServiceCommissioningBodyEntityCrud.Internal;
using SeleniumTests.ViewModels.Pages.Crud.Internal;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.ViewModels.Pages.CRUD.ServiceCommissioningBodyEntityCrud
{
	public class EditServiceCommissioningBodyEntityPage : ServiceCommissioningBodyEntityAttributeCollection
	{
		// % protected region % [Override class properties here] off begin
		public CrudCreateButtons ActionButtons => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public EditServiceCommissioningBodyEntityPage(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Override set values here] off begin
		public void SetValues(ServiceCommissioningBodyEntity serviceCommissioningBodyEntity)
		{
			Name.Value = serviceCommissioningBodyEntity.Name;
			Location.Value = serviceCommissioningBodyEntity.Location;
			ProfileImage.Value = serviceCommissioningBodyEntity.ProfileImage.Filename;
			ServicesIds.Value = serviceCommissioningBodyEntity.ServicesIds?.Select(x => x.ToString());
		}
		// % protected region % [Override set values here] end

		// % protected region % [Override get values here] off begin
		public ServiceCommissioningBodyEntity GetValues()
		{
			var serviceCommissioningBodyEntity =  new ServiceCommissioningBodyEntity
			{
				EmailAddress = EmailAddress.Value,
				Name = Name.Value,
				Location = Location.Value,
				ProfileImage = new FileData { Filename = ProfileImage.Value },
			};

			serviceCommissioningBodyEntity.ServicesIds = ServicesIds.Value.Select(Guid.Parse).ToList();;
			return serviceCommissioningBodyEntity;
		}
		// % protected region % [Override get values here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}