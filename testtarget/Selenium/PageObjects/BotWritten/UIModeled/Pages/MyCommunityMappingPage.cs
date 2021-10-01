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
	public class MyCommunityMappingPage : UIModeledPage
	{
		// % protected region % [Override class properties here] off begin
		public override string Url => baseUrl + "/mycommunitymapping";
		private const string RootSelector = "//div[@class='body-content']";
		private string MyCommunityMappingPageHorizontalLayout1Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By MyCommunityMappingPageHorizontalLayout1By => By.XPath(MyCommunityMappingPageHorizontalLayout1Selector);
		private By HeadingComponentBy => By.XPath($"{MyCommunityMappingPageHorizontalLayout1Selector}//h2[text()='My Community Mapping']");
		private string MyCommunityMappingPageHorizontalLayout2Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By MyCommunityMappingPageHorizontalLayout2By => By.XPath(MyCommunityMappingPageHorizontalLayout2Selector);
		private By Button1By => By.XPath($"{MyCommunityMappingPageHorizontalLayout2Selector}//button[text()='Community Services Map']");
		private By Button2By => By.XPath($"{MyCommunityMappingPageHorizontalLayout2Selector}//button[text()='SEIFA Index Map']");
		private string MyCommunityMappingPageHorizontalLayout3Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By MyCommunityMappingPageHorizontalLayout3By => By.XPath(MyCommunityMappingPageHorizontalLayout3Selector);
		private By TextAreaComponentBy => By.XPath($"{MyCommunityMappingPageHorizontalLayout3Selector}//label[text()='Description']/following-sibling::textarea");
		private By HeadingComponentBy => By.XPath($"{MyCommunityMappingPageHorizontalLayout3Selector}//h5[text()='What is My Community Mapping']");
		private string MyCommunityMappingPageHorizontalLayout4Selector => RootSelector + "//*[@class='layout__horizontal']";
		private By MyCommunityMappingPageHorizontalLayout4By => By.XPath(MyCommunityMappingPageHorizontalLayout4Selector);
		private By TextAreaComponentBy => By.XPath($"{MyCommunityMappingPageHorizontalLayout4Selector}//label[text()='Supporters']/following-sibling::textarea");
		// % protected region % [Override class properties here] end
		// % protected region % [Override constructor here] off begin
		public MyCommunityMappingPage(ContextConfiguration currentContext) : base(currentContext)
		{
		}
		// % protected region % [Override constructor here] end
		// % protected region % [Override ContainsModeledElements here] off begin
		public override bool ContainsModeledElements()
		{
			var validContents = true;
			validContents &= WaitUtils.elementState(DriverWait, MyCommunityMappingPageHorizontalLayout1By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, HeadingComponentBy, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, MyCommunityMappingPageHorizontalLayout2By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, Button1By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, Button2By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, MyCommunityMappingPageHorizontalLayout3By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, TextAreaComponentBy, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, HeadingComponentBy, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, MyCommunityMappingPageHorizontalLayout4By, ElementState.VISIBLE);
			validContents &= WaitUtils.elementState(DriverWait, TextAreaComponentBy, ElementState.VISIBLE);
			return validContents;
		}
		// % protected region % [Override ContainsModeledElements here] end
	}
}