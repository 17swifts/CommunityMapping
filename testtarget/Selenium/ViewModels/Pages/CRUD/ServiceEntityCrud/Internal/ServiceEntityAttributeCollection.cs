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
using OpenQA.Selenium;
using SeleniumTests.PageObjects.Pages;
using SeleniumTests.Setup;
using SeleniumTests.ViewModels.Components.Attribute;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.ViewModels.Pages.CRUD.ServiceEntityCrud.Internal
{
	public class ServiceEntityAttributeCollection : Page
	{
		// % protected region % [Override class properties here] off begin
		public AttributeTextField Name => new(By.CssSelector("div.name"), ContextConfiguration);
		public AttributeTextField Category => new(By.CssSelector("div.category"), ContextConfiguration);
		public AttributeEnumCombobox Servicetype => new(By.CssSelector("div.servicetype"), ContextConfiguration);
		public AttributeTextField Noservicedays => new(By.CssSelector("div.noservicedays"), ContextConfiguration);
		public AttributeTextField Investment => new(By.CssSelector("div.investment"), ContextConfiguration);
		public AttributeDatePicker Startdate => new(By.CssSelector("div.startdate"), ContextConfiguration);
		public AttributeDatePicker Enddate => new(By.CssSelector("div.enddate"), ContextConfiguration);
		public AttributeCheckbox Active => new(By.CssSelector("div.active"), ContextConfiguration);
		public AttributeReferenceCombobox RegionalAreaId => new(By.CssSelector("div.regionalAreaId"), ContextConfiguration);
		public AttributeReferenceMultiCombobox ServiceCommissioningBodiesIds => new(By.CssSelector("div.serviceCommissioningBodiess"), ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public ServiceEntityAttributeCollection(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}