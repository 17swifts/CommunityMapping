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
using SeleniumTests.Enums;
using SeleniumTests.Utils;
using SeleniumTests.Setup;
// % protected region % [Add further imports here] off begin
// % protected region % [Add further imports here] end

namespace SeleniumTests.PageObjects.BotWritten.UIModeled.Pages
{
	public class ServiceProfilePage : UIModeledPage
	{
		// % protected region % [Override class properties here] off begin
		public override string Url => baseUrl + "/serviceprofile";
		private const string RootSelector = "//div[@class='body-content']";
		private string ServiceProfilePageHorizontalLayout1Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By ServiceProfilePageHorizontalLayout1By => By.XPath(ServiceProfilePageHorizontalLayout1Selector);
		private By HeadingComponentBy => By.XPath($"{ServiceProfilePageHorizontalLayout1Selector}//h2[text()='Community Services Map']");
		private string ServiceProfilePageHorizontalLayout2Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By ServiceProfilePageHorizontalLayout2By => By.XPath(ServiceProfilePageHorizontalLayout2Selector);
		private By ParagraphBy => By.XPath($"{ServiceProfilePageHorizontalLayout2Selector}//p[text()='Description...']");
		// % protected region % [Override class properties here] end
		// % protected region % [Override constructor here] off begin
		public ServiceProfilePage(ContextConfiguration currentContext) : base(currentContext)
		{
		}
		// % protected region % [Override constructor here] end
		// % protected region % [Override ContainsModeledElements here] off begin
		public override bool ContainsModeledElements()
		{
			var validContents = true;
			validContents &= WaitUtils.elementState(DriverWait, ServiceProfilePageHorizontalLayout1By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, HeadingComponentBy, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, ServiceProfilePageHorizontalLayout2By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, ParagraphBy, ElementState.VISIBLE);
			return validContents;
		}
		// % protected region % [Override ContainsModeledElements here] end
	}
}