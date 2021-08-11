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
using System.Collections.Generic;
using EntityObject.Enums;
using APITests.EntityObjects.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.PageObjects.Components;
using SeleniumTests.Setup;
using SeleniumTests.Utils;
using SeleniumTests.Enums;
using SeleniumTests.PageObjects.BotWritten;
// % protected region % [Custom imports] off begin
// % protected region % [Custom imports] end

namespace SeleniumTests.PageObjects.CRUDPageObject.PageDetails
{
	//This section is a mapping from an entity object to an entity create or detailed view page
	public class ServiceEntityDetailSection : BasePage, IEntityDetailSection
	{
		private readonly IWait<IWebDriver> _driverWait;
		private readonly IWebDriver _driver;
		private readonly bool _isFastText;
		private readonly ContextConfiguration _contextConfiguration;

		// reference elements
		private static By RegionalAreaIdElementBy => By.XPath("//*[contains(@class, 'regionalArea')]//div[contains(@class, 'dropdown__container')]");
		private static By RegionalAreaIdInputElementBy => By.XPath("//*[contains(@class, 'regionalArea')]/div/input");
		private static By ServiceCommissioningBodiessElementBy => By.XPath("//*[contains(@class, 'serviceCommissioningBodies')]//div[contains(@class, 'dropdown__container')]/a");
		private static By ServiceCommissioningBodiessInputElementBy => By.XPath("//*[contains(@class, 'serviceCommissioningBodies')]/div/input");

		//FlatPickr Elements
		private DateTimePickerComponent StartdateElement => new DateTimePickerComponent(_contextConfiguration, "startdate");
		private DateTimePickerComponent EnddateElement => new DateTimePickerComponent(_contextConfiguration, "enddate");

		//Attribute Headers
		private readonly ServiceEntity _serviceEntity;

		//Attribute Header Titles
		private IWebElement NameHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Name']"));
		private IWebElement CategoryHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Category']"));
		private IWebElement ServicetypeHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='ServiceType']"));
		private IWebElement NoservicedaysHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='NoServiceDays']"));
		private IWebElement InvestmentHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Investment']"));
		private IWebElement StartdateHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='StartDate']"));
		private IWebElement EnddateHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='EndDate']"));
		private IWebElement ActiveHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Active']"));

		// Datepickers
		public IWebElement CreateAtDatepickerField => _driver.FindElementExt(By.CssSelector("div.created > input[type='date']"));
		public IWebElement ModifiedAtDatepickerField => _driver.FindElementExt(By.CssSelector("div.modified > input[type='date']"));

		public ServiceEntityDetailSection(ContextConfiguration contextConfiguration, ServiceEntity serviceEntity = null) : base(contextConfiguration)
		{
			_driver = contextConfiguration.WebDriver;
			_driverWait = contextConfiguration.WebDriverWait;
			_isFastText = contextConfiguration.SeleniumSettings.FastText;
			_contextConfiguration = contextConfiguration;
			_serviceEntity = serviceEntity;

			InitializeSelectors();
			// % protected region % [Add any extra construction requires] off begin
			// % protected region % [Add any extra construction requires] end
		}

		// initialise all selectors and grouping them with the selector type which is used
		private void InitializeSelectors()
		{
			// Attribute web elements
			selectorDict.Add("NameElement", (selector: "//div[contains(@class, 'name')]//input", type: SelectorType.XPath));
			selectorDict.Add("CategoryElement", (selector: "//div[contains(@class, 'category')]//input", type: SelectorType.XPath));
			selectorDict.Add("ServicetypeElement", (selector: "//div[contains(@class, 'servicetype')]//input", type: SelectorType.XPath));
			selectorDict.Add("NoservicedaysElement", (selector: "//div[contains(@class, 'noservicedays')]//input", type: SelectorType.XPath));
			selectorDict.Add("InvestmentElement", (selector: "//div[contains(@class, 'investment')]//input", type: SelectorType.XPath));
			selectorDict.Add("ActiveElement", (selector: "//div[contains(@class, 'active')]//input", type: SelectorType.XPath));

			// Reference web elements
			selectorDict.Add("RegionalareaElement", (selector: ".input-group__dropdown.regionalAreaId > .dropdown.dropdown__container", type: SelectorType.CSS));
			selectorDict.Add("ServicecommissioningbodiesElement", (selector: ".input-group__dropdown.serviceCommissioningBodiess > .dropdown.dropdown__container", type: SelectorType.CSS));

			// Datepicker
			selectorDict.Add("CreateAtDatepickerField", (selector: "//div[contains(@class, 'created')]/input", type: SelectorType.XPath));
			selectorDict.Add("ModifiedAtDatepickerField", (selector: "//div[contains(@class, 'modified')]/input", type: SelectorType.XPath));
		}

		//outgoing Reference web elements
		//get the input path as set by the selector library
		private IWebElement RegionalAreaElement => FindElementExt("RegionalAreaElement");

		//Attribute web Elements
		private IWebElement NameElement => FindElementExt("NameElement");
		private IWebElement CategoryElement => FindElementExt("CategoryElement");
		private IWebElement ServicetypeElement => FindElementExt("ServicetypeElement");
		private IWebElement NoservicedaysElement => FindElementExt("NoservicedaysElement");
		private IWebElement InvestmentElement => FindElementExt("InvestmentElement");
		private IWebElement ActiveElement => FindElementExt("ActiveElement");

		// Return an IWebElement that can be used to sort an attribute.
		public IWebElement GetHeaderTile(string attribute)
		{
			return attribute switch
			{
				"Name" => NameHeaderTitle,
				"Category" => CategoryHeaderTitle,
				"ServiceType" => ServicetypeHeaderTitle,
				"NoServiceDays" => NoservicedaysHeaderTitle,
				"Investment" => InvestmentHeaderTitle,
				"StartDate" => StartdateHeaderTitle,
				"EndDate" => EnddateHeaderTitle,
				"Active" => ActiveHeaderTitle,
				_ => throw new Exception($"Cannot find header tile {attribute}"),
			};
		}

		// Return an IWebElement for an attribute input
		public IWebElement GetInputElement(string attribute)
		{
			switch (attribute)
			{
				case "Name":
					return NameElement;
				case "Category":
					return CategoryElement;
				case "Servicetype":
					return ServicetypeElement;
				case "Noservicedays":
					return NoservicedaysElement;
				case "Investment":
					return InvestmentElement;
				case "Startdate":
					return StartdateElement.DateTimePickerElement;
				case "Enddate":
					return EnddateElement.DateTimePickerElement;
				case "Active":
					return ActiveElement;
				default:
					throw new Exception($"Cannot find input element {attribute}");
			}
		}

		public void SetInputElement(string attribute, string value)
		{
			switch (attribute)
			{
				case "Name":
					SetName(value);
					break;
				case "Category":
					SetCategory(value);
					break;
				case "Servicetype":
					SetServicetype((Servicetype)Enum.Parse(typeof(Servicetype), value));
					break;
				case "Noservicedays":
					int? noservicedays = null;
					if (int.TryParse(value, out var intNoservicedays))
					{
						noservicedays = intNoservicedays;
					}
					SetNoservicedays(noservicedays);
					break;
				case "Investment":
					SetInvestment(Convert.ToDouble(value));
					break;
				case "Startdate":
					if (DateTime.TryParse(value, out var startdateValue))
					{
						SetStartdate(startdateValue);
					}
					break;
				case "Enddate":
					if (DateTime.TryParse(value, out var enddateValue))
					{
						SetEnddate(enddateValue);
					}
					break;
				case "Active":
					SetActive(bool.Parse(value));
					break;
				default:
					throw new Exception($"Cannot find input element {attribute}");
			}
		}

		private By GetErrorAttributeSectionAsBy(string attribute)
		{
			return attribute switch
			{
				"Name" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.name > div > p"),
				"Category" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.category > div > p"),
				"Servicetype" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.servicetype > div > p"),
				"Noservicedays" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.noservicedays > div > p"),
				"Investment" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.investment > div > p"),
				"Startdate" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.startdate > div > p"),
				"Enddate" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.enddate > div > p"),
				"Active" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.active > div > p"),
				_ => throw new Exception($"No such attribute {attribute}"),
			};
		}

		public List<string> GetErrorMessagesForAttribute(string attribute)
		{
			var elementBy = GetErrorAttributeSectionAsBy(attribute);
			WaitUtils.elementState(_driverWait, elementBy, ElementState.VISIBLE);
			var element = _driver.FindElementExt(elementBy);
			var errors = new List<string>(element.Text.Split("\r\n"));
			// remove the item in the list which is the name of the attribute and not an error.
			errors.Remove(attribute);
			return errors;
		}

		public void Apply()
		{
			// % protected region % [Configure entity application here] off begin
			SetName(_serviceEntity.Name);
			SetCategory(_serviceEntity.Category);
			SetServicetype(_serviceEntity.Servicetype);
			SetNoservicedays(_serviceEntity.Noservicedays);
			SetInvestment(_serviceEntity.Investment);
			SetStartdate(_serviceEntity.Startdate);
			SetEnddate(_serviceEntity.Enddate);
			SetActive(_serviceEntity.Active);

			SetRegionalAreaId(_serviceEntity.RegionalAreaId?.ToString());
			if (_serviceEntity.ServiceCommissioningBodiesIds != null)
			{
				SetServiceCommissioningBodiess(_serviceEntity.ServiceCommissioningBodiesIds.Select(x => x.ToString()));
			}
			// % protected region % [Configure entity application here] end
		}

		public List<Guid> GetAssociation(string referenceName)
		{
			switch (referenceName)
			{
				case "regionalarea":
					return new List<Guid>() {GetRegionalAreaId()};
				case "servicecommissioningbodies":
					return GetServiceCommissioningBodiess();
				default:
					throw new Exception($"Cannot find association type {referenceName}");
			}
		}

		// set associations
		private void SetRegionalAreaId(string id)
		{
			if (id == "") { return; }
			WaitUtils.elementState(_driverWait, RegionalAreaIdInputElementBy, ElementState.VISIBLE);
			var regionalAreaIdInputElement = _driver.FindElementExt(RegionalAreaIdInputElementBy);

			if (id != null)
			{
				regionalAreaIdInputElement.SendKeys(id);
				WaitForDropdownOptions();
				WaitUtils.elementState(_driverWait, By.XPath($"//*/div[@role='option']/span[text()='{id}']"), ElementState.EXISTS);
				regionalAreaIdInputElement.SendKeys(Keys.Return);
			}
		}
		private void SetServiceCommissioningBodiess(IEnumerable<string> ids)
		{
			WaitUtils.elementState(_driverWait, ServiceCommissioningBodiessInputElementBy, ElementState.VISIBLE);
			var serviceCommissioningBodiessInputElement = _driver.FindElementExt(ServiceCommissioningBodiessInputElementBy);

			foreach(var id in ids)
			{
				serviceCommissioningBodiessInputElement.SendKeys(id);
				WaitForDropdownOptions();
				serviceCommissioningBodiessInputElement.SendKeys(Keys.Return);
			}
		}


		// get associations
		private Guid GetRegionalAreaId()
		{
			WaitUtils.elementState(_driverWait, RegionalAreaIdElementBy, ElementState.VISIBLE);
			var regionalAreaIdElement = _driver.FindElementExt(RegionalAreaIdElementBy);
			return new Guid(regionalAreaIdElement.GetAttribute("data-id"));
		}
		private List<Guid> GetServiceCommissioningBodiess()
		{
			var guids = new List<Guid>();
			WaitUtils.elementState(_driverWait, ServiceCommissioningBodiessElementBy, ElementState.VISIBLE);
			var serviceCommissioningBodiessElement = _driver.FindElements(ServiceCommissioningBodiessElementBy);

			foreach(var element in serviceCommissioningBodiessElement)
			{
				guids.Add(new Guid (element.GetAttribute("data-id")));
			}
			return guids;
		}

		// wait for dropdown to be displaying options
		private void WaitForDropdownOptions()
		{
			var xpath = "//*/div[@aria-expanded='true']";
			var elementBy = WebElementUtils.GetElementAsBy(SelectorPathType.XPATH, xpath);
			WaitUtils.elementState(_driverWait, elementBy,ElementState.EXISTS);
		}

		private void SetName (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "name", value, _isFastText);
			NameElement.SendKeys(Keys.Tab);
			NameElement.SendKeys(Keys.Escape);
		}

		private String GetName =>
			NameElement.Text;

		private void SetCategory (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "category", value, _isFastText);
			CategoryElement.SendKeys(Keys.Tab);
			CategoryElement.SendKeys(Keys.Escape);
		}

		private String GetCategory =>
			CategoryElement.Text;

		private void SetServicetype (Servicetype value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "servicetype", value.ToString(), _isFastText);
		}

		private Servicetype GetServicetype =>
			(Servicetype)Enum.Parse(typeof(Servicetype), ServicetypeElement.Text);
		private void SetNoservicedays (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "noservicedays", intValue.ToString(), _isFastText);
			}
		}

		private int? GetNoservicedays =>
			int.Parse(NoservicedaysElement.Text);

		private void SetInvestment (Double? value)
		{
			if (value is double doubleValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "investment", doubleValue.ToString(), _isFastText);
			}
		}

		private Double? GetInvestment =>
			Convert.ToDouble(InvestmentElement.Text);
		private void SetStartdate (DateTime? value)
		{
			if (value is DateTime datetimeValue)
			{
				StartdateElement.SetDate(datetimeValue);
			}
		}

		private DateTime? GetStartdate =>
			Convert.ToDateTime(StartdateElement.DateTimePickerElement.Text);
		private void SetEnddate (DateTime? value)
		{
			if (value is DateTime datetimeValue)
			{
				EnddateElement.SetDate(datetimeValue);
			}
		}

		private DateTime? GetEnddate =>
			Convert.ToDateTime(EnddateElement.DateTimePickerElement.Text);
		private void SetActive (Boolean? value)
		{
			if (value is bool boolValue)
			{
				if (ActiveElement.Selected != boolValue) {
					ActiveElement.Click();
				}
			}
		}

		private Boolean? GetActive =>
			ActiveElement.Selected;


		// % protected region % [Add any additional getters and setters of web elements] off begin
		// % protected region % [Add any additional getters and setters of web elements] end
	}
}