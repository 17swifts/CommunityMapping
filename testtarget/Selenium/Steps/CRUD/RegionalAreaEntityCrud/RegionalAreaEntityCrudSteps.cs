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
using System.Linq;
using SeleniumTests.Setup;
using SeleniumTests.ViewModels.Pages.CRUD.RegionalAreaEntityCrud;
using TechTalk.SpecFlow;
using Xunit;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.Steps.CRUD.RegionalAreaEntityCrud
{
	[Binding]
	public class RegionalAreaEntityCrudSteps : StepDefinition
	{
		// % protected region % [Override class properties here] off begin
		public CrudRegionalAreaEntityPage CrudRegionalAreaEntityPage => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public RegionalAreaEntityCrudSteps(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Override NavigateToTheEntityBackendPage here] off begin
		[StepDefinition("I navigate to the RegionalAreaEntity admin crud page")]
		public void NavigateToTheRegionalAreaEntityBackendPage()
		{
			CrudRegionalAreaEntityPage.Navigate();
		}
		// % protected region % [Override NavigateToTheEntityBackendPage here] end

		// % protected region % [Override IClickToCreateAnEntity here] off begin
		[StepDefinition("I click to create a RegionalAreaEntity")]
		public void ClickToCreateARegionalAreaEntity()
		{
			CrudRegionalAreaEntityPage.CreateButton.Click();
		}
		// % protected region % [Override IClickToCreateAnEntity here] end

		// % protected region % [Override IAssertThatIAmOnTheEntityBackendPage here] off begin
		[StepDefinition("I assert that I am on the RegionalAreaEntity admin crud page")]
		public void AssertIAmOnTheRegionalAreaEntityBackendPage()
		{
			ContextConfiguration.WebDriverWait.Until(_ => ContextConfiguration.WebDriver.Url.Trim('/') == CrudRegionalAreaEntityPage.Url);
			Assert.Equal(ContextConfiguration.WebDriver.Url.Trim('/'), CrudRegionalAreaEntityPage.Url);
		}
		// % protected region % [Override IAssertThatIAmOnTheEntityBackendPage here] end

		// % protected region % [Override IClickToViewTheFirstEntityInTheCrudList here] off begin
		[StepDefinition("I click View on the first RegionalAreaEntity in the crud list")]
		public void ClickToViewTheFirstEntityInTheCrudList()
		{
			ContextConfiguration.WebDriverWait.Until(_ => CrudRegionalAreaEntityPage.CrudList.Items.Any());
			CrudRegionalAreaEntityPage.CrudList.Items.First().ViewButton.Click();
		}
		// % protected region % [Override IClickToViewTheFirstEntityInTheCrudList here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}