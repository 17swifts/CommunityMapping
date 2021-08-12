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
		public AttributeTextField Sa2id => new(By.CssSelector("div.sa2id"), ContextConfiguration);
		public AttributeTextField Sa3id => new(By.CssSelector("div.sa3id"), ContextConfiguration);
		public AttributeTextField Sa3name => new(By.CssSelector("div.sa3name"), ContextConfiguration);
		public AttributeTextField Numofpph => new(By.CssSelector("div.numofpph"), ContextConfiguration);
		public AttributeTextField Percentpphperday => new(By.CssSelector("div.percentpphperday"), ContextConfiguration);
		public AttributeTextField Sa2name => new(By.CssSelector("div.sa2name"), ContextConfiguration);
		public AttributeTextField Indigenous => new(By.CssSelector("div.indigenous"), ContextConfiguration);
		public AttributeTextField Nonindigenous => new(By.CssSelector("div.nonindigenous"), ContextConfiguration);
		public AttributeTextField Irsd => new(By.CssSelector("div.irsd"), ContextConfiguration);
		public AttributeTextField Irsad => new(By.CssSelector("div.irsad"), ContextConfiguration);
		public AttributeTextField Ier => new(By.CssSelector("div.ier"), ContextConfiguration);
		public AttributeTextField Ieo => new(By.CssSelector("div.ieo"), ContextConfiguration);
		public AttributeTextField GapScore => new(By.CssSelector("div.gapScore"), ContextConfiguration);
		public AttributeReferenceMultiCombobox ServicesIds => new(By.CssSelector("div.servicess"), ContextConfiguration);
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