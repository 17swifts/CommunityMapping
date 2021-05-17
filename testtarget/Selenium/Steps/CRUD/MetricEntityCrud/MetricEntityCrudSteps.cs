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
using SeleniumTests.ViewModels.Pages.CRUD.MetricEntityCrud;
using TechTalk.SpecFlow;
using Xunit;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.Steps.CRUD.MetricEntityCrud
{
	[Binding]
	public class MetricEntityCrudSteps : StepDefinition
	{
		// % protected region % [Override class properties here] off begin
		public CrudMetricEntityPage CrudMetricEntityPage => new(ContextConfiguration);
		// % protected region % [Override class properties here] end

		// % protected region % [Override constructor here] off begin
		public MetricEntityCrudSteps(ContextConfiguration contextConfiguration) : base(contextConfiguration)
		{
		}
		// % protected region % [Override constructor here] end

		// % protected region % [Override NavigateToTheEntityBackendPage here] off begin
		[StepDefinition("I navigate to the MetricEntity admin crud page")]
		public void NavigateToTheMetricEntityBackendPage()
		{
			CrudMetricEntityPage.Navigate();
		}
		// % protected region % [Override NavigateToTheEntityBackendPage here] end

		// % protected region % [Override IClickToCreateAnEntity here] off begin
		[StepDefinition("I click to create a MetricEntity")]
		public void ClickToCreateAMetricEntity()
		{
			CrudMetricEntityPage.CreateButton.Click();
		}
		// % protected region % [Override IClickToCreateAnEntity here] end

		// % protected region % [Override IAssertThatIAmOnTheEntityBackendPage here] off begin
		[StepDefinition("I assert that I am on the MetricEntity admin crud page")]
		public void AssertIAmOnTheMetricEntityBackendPage()
		{
			ContextConfiguration.WebDriverWait.Until(_ => ContextConfiguration.WebDriver.Url.Trim('/') == CrudMetricEntityPage.Url);
			Assert.Equal(ContextConfiguration.WebDriver.Url.Trim('/'), CrudMetricEntityPage.Url);
		}
		// % protected region % [Override IAssertThatIAmOnTheEntityBackendPage here] end

		// % protected region % [Override IClickToViewTheFirstEntityInTheCrudList here] off begin
		[StepDefinition("I click View on the first MetricEntity in the crud list")]
		public void ClickToViewTheFirstEntityInTheCrudList()
		{
			ContextConfiguration.WebDriverWait.Until(_ => CrudMetricEntityPage.CrudList.Items.Any());
			CrudMetricEntityPage.CrudList.Items.First().ViewButton.Click();
		}
		// % protected region % [Override IClickToViewTheFirstEntityInTheCrudList here] end

		// % protected region % [Add class methods here] off begin
		// % protected region % [Add class methods here] end
	}
}