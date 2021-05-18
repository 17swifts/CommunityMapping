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

namespace SeleniumTests.ViewModels.Pages.CRUD.RegionalAreaEntityCrud.Internal
{
	public class RegionalAreaEntityAttributeCollection : Page
	{
		// % protected region % [Override class properties here] off begin
		public AttributeTextField Sa2code => new(By.CssSelector("div.sa2code"), ContextConfiguration);
		public AttributeTextField Name => new(By.CssSelector("div.name"), ContextConfiguration);
		public AttributeTextField Nonindigenouspopulation => new(By.CssSelector("div.nonindigenouspopulation"), ContextConfiguration);
		public AttributeTextField Indigenouspopulation => new(By.CssSelector("div.indigenouspopulation"), ContextConfiguration);
		public AttributeTextField Pph => new(By.CssSelector("div.pph"), ContextConfiguration);
		public AttributeTextField Irsd => new(By.CssSelector("div.irsd"), ContextConfiguration);
		public AttributeTextField Irsad => new(By.CssSelector("div.irsad"), ContextConfiguration);
		public AttributeTextField Ieo => new(By.CssSelector("div.ieo"), ContextConfiguration);
		public AttributeTextField Ier => new(By.CssSelector("div.ier"), ContextConfiguration);
		public AttributeTextField GapScore => new(By.CssSelector("div.gapScore"), ContextConfiguration);
		public AttributeTextField Noservices => new(By.CssSelector("div.noservices"), ContextConfiguration);
		public AttributeTextField Totalinvestment => new(By.CssSelector("div.totalinvestment"), ContextConfiguration);
		public AttributeReferenceMultiCombobox ServicesIds => new(By.CssSelector("div.servicess"), ContextConfiguration);
		public AttributeReferenceMultiCombobox LoggedEventIds => new(By.CssSelector("div.loggedEvents"), ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public RegionalAreaEntityAttributeCollection(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}