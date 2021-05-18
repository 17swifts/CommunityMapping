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
	public class RegionalAreaEntityDetailSection : BasePage, IEntityDetailSection
	{
		private readonly IWait<IWebDriver> _driverWait;
		private readonly IWebDriver _driver;
		private readonly bool _isFastText;
		private readonly ContextConfiguration _contextConfiguration;

		// reference elements
		private static By ServicessElementBy => By.XPath("//*[contains(@class, 'services')]//div[contains(@class, 'dropdown__container')]/a");
		private static By ServicessInputElementBy => By.XPath("//*[contains(@class, 'services')]/div/input");

		//FlatPickr Elements

		//Attribute Headers
		private readonly RegionalAreaEntity _regionalAreaEntity;

		//Attribute Header Titles
		private IWebElement Sa2idHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='sa2Id']"));
		private IWebElement Sa3idHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='sa3Id']"));
		private IWebElement Sa3nameHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='sa3Name']"));
		private IWebElement NumofpphHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='numOfPph']"));
		private IWebElement PercentpphperdayHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='percentPphPerDay']"));
		private IWebElement Sa2nameHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='sa2Name']"));
		private IWebElement IndigenousHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='indigenous']"));
		private IWebElement NonindigenousHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='nonIndigenous']"));
		private IWebElement IrsdHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='irsd']"));
		private IWebElement IrsadHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='irsad']"));
		private IWebElement IerHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='ier']"));
		private IWebElement IeoHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='ieo']"));
		private IWebElement GapScoreHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='gap Score']"));
		private IWebElement NoservicesHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='noServices']"));
		private IWebElement TotalinvestmentHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='totalInvestment']"));

		// Datepickers
		public IWebElement CreateAtDatepickerField => _driver.FindElementExt(By.CssSelector("div.created > input[type='date']"));
		public IWebElement ModifiedAtDatepickerField => _driver.FindElementExt(By.CssSelector("div.modified > input[type='date']"));

		public RegionalAreaEntityDetailSection(ContextConfiguration contextConfiguration, RegionalAreaEntity regionalAreaEntity = null) : base(contextConfiguration)
		{
			_driver = contextConfiguration.WebDriver;
			_driverWait = contextConfiguration.WebDriverWait;
			_isFastText = contextConfiguration.SeleniumSettings.FastText;
			_contextConfiguration = contextConfiguration;
			_regionalAreaEntity = regionalAreaEntity;

			InitializeSelectors();
			// % protected region % [Add any extra construction requires] off begin
			// % protected region % [Add any extra construction requires] end
		}

		// initialise all selectors and grouping them with the selector type which is used
		private void InitializeSelectors()
		{
			// Attribute web elements
			selectorDict.Add("Sa2idElement", (selector: "//div[contains(@class, 'sa2id')]//input", type: SelectorType.XPath));
			selectorDict.Add("Sa3idElement", (selector: "//div[contains(@class, 'sa3id')]//input", type: SelectorType.XPath));
			selectorDict.Add("Sa3nameElement", (selector: "//div[contains(@class, 'sa3name')]//input", type: SelectorType.XPath));
			selectorDict.Add("NumofpphElement", (selector: "//div[contains(@class, 'numofpph')]//input", type: SelectorType.XPath));
			selectorDict.Add("PercentpphperdayElement", (selector: "//div[contains(@class, 'percentpphperday')]//input", type: SelectorType.XPath));
			selectorDict.Add("Sa2nameElement", (selector: "//div[contains(@class, 'sa2name')]//input", type: SelectorType.XPath));
			selectorDict.Add("IndigenousElement", (selector: "//div[contains(@class, 'indigenous')]//input", type: SelectorType.XPath));
			selectorDict.Add("NonindigenousElement", (selector: "//div[contains(@class, 'nonindigenous')]//input", type: SelectorType.XPath));
			selectorDict.Add("IrsdElement", (selector: "//div[contains(@class, 'irsd')]//input", type: SelectorType.XPath));
			selectorDict.Add("IrsadElement", (selector: "//div[contains(@class, 'irsad')]//input", type: SelectorType.XPath));
			selectorDict.Add("IerElement", (selector: "//div[contains(@class, 'ier')]//input", type: SelectorType.XPath));
			selectorDict.Add("IeoElement", (selector: "//div[contains(@class, 'ieo')]//input", type: SelectorType.XPath));
			selectorDict.Add("GapScoreElement", (selector: "//div[contains(@class, 'gapScore')]//input", type: SelectorType.XPath));
			selectorDict.Add("NoservicesElement", (selector: "//div[contains(@class, 'noservices')]//input", type: SelectorType.XPath));
			selectorDict.Add("TotalinvestmentElement", (selector: "//div[contains(@class, 'totalinvestment')]//input", type: SelectorType.XPath));

			// Reference web elements
			selectorDict.Add("ServicesElement", (selector: ".input-group__dropdown.servicess > .dropdown.dropdown__container", type: SelectorType.CSS));

			// Datepicker
			selectorDict.Add("CreateAtDatepickerField", (selector: "//div[contains(@class, 'created')]/input", type: SelectorType.XPath));
			selectorDict.Add("ModifiedAtDatepickerField", (selector: "//div[contains(@class, 'modified')]/input", type: SelectorType.XPath));
		}

		//outgoing Reference web elements

		//Attribute web Elements
		private IWebElement Sa2idElement => FindElementExt("Sa2idElement");
		private IWebElement Sa3idElement => FindElementExt("Sa3idElement");
		private IWebElement Sa3nameElement => FindElementExt("Sa3nameElement");
		private IWebElement NumofpphElement => FindElementExt("NumofpphElement");
		private IWebElement PercentpphperdayElement => FindElementExt("PercentpphperdayElement");
		private IWebElement Sa2nameElement => FindElementExt("Sa2nameElement");
		private IWebElement IndigenousElement => FindElementExt("IndigenousElement");
		private IWebElement NonindigenousElement => FindElementExt("NonindigenousElement");
		private IWebElement IrsdElement => FindElementExt("IrsdElement");
		private IWebElement IrsadElement => FindElementExt("IrsadElement");
		private IWebElement IerElement => FindElementExt("IerElement");
		private IWebElement IeoElement => FindElementExt("IeoElement");
		private IWebElement GapScoreElement => FindElementExt("GapScoreElement");
		private IWebElement NoservicesElement => FindElementExt("NoservicesElement");
		private IWebElement TotalinvestmentElement => FindElementExt("TotalinvestmentElement");

		// Return an IWebElement that can be used to sort an attribute.
		public IWebElement GetHeaderTile(string attribute)
		{
			return attribute switch
			{
				"sa2Id" => Sa2idHeaderTitle,
				"sa3Id" => Sa3idHeaderTitle,
				"sa3Name" => Sa3nameHeaderTitle,
				"numOfPph" => NumofpphHeaderTitle,
				"percentPphPerDay" => PercentpphperdayHeaderTitle,
				"sa2Name" => Sa2nameHeaderTitle,
				"indigenous" => IndigenousHeaderTitle,
				"nonIndigenous" => NonindigenousHeaderTitle,
				"irsd" => IrsdHeaderTitle,
				"irsad" => IrsadHeaderTitle,
				"ier" => IerHeaderTitle,
				"ieo" => IeoHeaderTitle,
				"gap Score" => GapScoreHeaderTitle,
				"noServices" => NoservicesHeaderTitle,
				"totalInvestment" => TotalinvestmentHeaderTitle,
				_ => throw new Exception($"Cannot find header tile {attribute}"),
			};
		}

		// Return an IWebElement for an attribute input
		public IWebElement GetInputElement(string attribute)
		{
			switch (attribute)
			{
				case "Sa2id":
					return Sa2idElement;
				case "Sa3id":
					return Sa3idElement;
				case "Sa3name":
					return Sa3nameElement;
				case "Numofpph":
					return NumofpphElement;
				case "Percentpphperday":
					return PercentpphperdayElement;
				case "Sa2name":
					return Sa2nameElement;
				case "Indigenous":
					return IndigenousElement;
				case "Nonindigenous":
					return NonindigenousElement;
				case "Irsd":
					return IrsdElement;
				case "Irsad":
					return IrsadElement;
				case "Ier":
					return IerElement;
				case "Ieo":
					return IeoElement;
				case "GapScore":
					return GapScoreElement;
				case "Noservices":
					return NoservicesElement;
				case "Totalinvestment":
					return TotalinvestmentElement;
				default:
					throw new Exception($"Cannot find input element {attribute}");
			}
		}

		public void SetInputElement(string attribute, string value)
		{
			switch (attribute)
			{
				case "Sa2id":
					SetSa2id(value);
					break;
				case "Sa3id":
					SetSa3id(value);
					break;
				case "Sa3name":
					SetSa3name(value);
					break;
				case "Numofpph":
					int? numofpph = null;
					if (int.TryParse(value, out var intNumofpph))
					{
						numofpph = intNumofpph;
					}
					SetNumofpph(numofpph);
					break;
				case "Percentpphperday":
					SetPercentpphperday(Convert.ToDouble(value));
					break;
				case "Sa2name":
					SetSa2name(value);
					break;
				case "Indigenous":
					int? indigenous = null;
					if (int.TryParse(value, out var intIndigenous))
					{
						indigenous = intIndigenous;
					}
					SetIndigenous(indigenous);
					break;
				case "Nonindigenous":
					int? nonindigenous = null;
					if (int.TryParse(value, out var intNonindigenous))
					{
						nonindigenous = intNonindigenous;
					}
					SetNonindigenous(nonindigenous);
					break;
				case "Irsd":
					int? irsd = null;
					if (int.TryParse(value, out var intIrsd))
					{
						irsd = intIrsd;
					}
					SetIrsd(irsd);
					break;
				case "Irsad":
					int? irsad = null;
					if (int.TryParse(value, out var intIrsad))
					{
						irsad = intIrsad;
					}
					SetIrsad(irsad);
					break;
				case "Ier":
					int? ier = null;
					if (int.TryParse(value, out var intIer))
					{
						ier = intIer;
					}
					SetIer(ier);
					break;
				case "Ieo":
					int? ieo = null;
					if (int.TryParse(value, out var intIeo))
					{
						ieo = intIeo;
					}
					SetIeo(ieo);
					break;
				case "GapScore":
					SetGapScore(Convert.ToDouble(value));
					break;
				case "Noservices":
					int? noservices = null;
					if (int.TryParse(value, out var intNoservices))
					{
						noservices = intNoservices;
					}
					SetNoservices(noservices);
					break;
				case "Totalinvestment":
					SetTotalinvestment(Convert.ToDouble(value));
					break;
				default:
					throw new Exception($"Cannot find input element {attribute}");
			}
		}

		private By GetErrorAttributeSectionAsBy(string attribute)
		{
			return attribute switch
			{
				"Sa2id" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.sa2id > div > p"),
				"Sa3id" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.sa3id > div > p"),
				"Sa3name" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.sa3name > div > p"),
				"Numofpph" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.numofpph > div > p"),
				"Percentpphperday" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.percentpphperday > div > p"),
				"Sa2name" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.sa2name > div > p"),
				"Indigenous" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.indigenous > div > p"),
				"Nonindigenous" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.nonindigenous > div > p"),
				"Irsd" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.irsd > div > p"),
				"Irsad" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.irsad > div > p"),
				"Ier" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.ier > div > p"),
				"Ieo" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.ieo > div > p"),
				"GapScore" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.gapScore > div > p"),
				"Noservices" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.noservices > div > p"),
				"Totalinvestment" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.totalinvestment > div > p"),
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
			SetSa2id(_regionalAreaEntity.Sa2id);
			SetSa3id(_regionalAreaEntity.Sa3id);
			SetSa3name(_regionalAreaEntity.Sa3name);
			SetNumofpph(_regionalAreaEntity.Numofpph);
			SetPercentpphperday(_regionalAreaEntity.Percentpphperday);
			SetSa2name(_regionalAreaEntity.Sa2name);
			SetIndigenous(_regionalAreaEntity.Indigenous);
			SetNonindigenous(_regionalAreaEntity.Nonindigenous);
			SetIrsd(_regionalAreaEntity.Irsd);
			SetIrsad(_regionalAreaEntity.Irsad);
			SetIer(_regionalAreaEntity.Ier);
			SetIeo(_regionalAreaEntity.Ieo);
			SetGapScore(_regionalAreaEntity.GapScore);
			SetNoservices(_regionalAreaEntity.Noservices);
			SetTotalinvestment(_regionalAreaEntity.Totalinvestment);

			if (_regionalAreaEntity.ServicesIds != null)
			{
				SetServicess(_regionalAreaEntity.ServicesIds.Select(x => x.ToString()));
			}
			// % protected region % [Configure entity application here] end
		}

		public List<Guid> GetAssociation(string referenceName)
		{
			switch (referenceName)
			{
				case "services":
					return GetServicess();
				default:
					throw new Exception($"Cannot find association type {referenceName}");
			}
		}

		// set associations
		private void SetServicess(IEnumerable<string> ids)
		{
			WaitUtils.elementState(_driverWait, ServicessInputElementBy, ElementState.VISIBLE);
			var servicessInputElement = _driver.FindElementExt(ServicessInputElementBy);

			foreach(var id in ids)
			{
				servicessInputElement.SendKeys(id);
				WaitForDropdownOptions();
				servicessInputElement.SendKeys(Keys.Return);
			}
		}


		// get associations
		private List<Guid> GetServicess()
		{
			var guids = new List<Guid>();
			WaitUtils.elementState(_driverWait, ServicessElementBy, ElementState.VISIBLE);
			var servicessElement = _driver.FindElements(ServicessElementBy);

			foreach(var element in servicessElement)
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

		private void SetSa2id (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "sa2id", value, _isFastText);
			Sa2idElement.SendKeys(Keys.Tab);
			Sa2idElement.SendKeys(Keys.Escape);
		}

		private String GetSa2id =>
			Sa2idElement.Text;

		private void SetSa3id (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "sa3id", value, _isFastText);
			Sa3idElement.SendKeys(Keys.Tab);
			Sa3idElement.SendKeys(Keys.Escape);
		}

		private String GetSa3id =>
			Sa3idElement.Text;

		private void SetSa3name (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "sa3name", value, _isFastText);
			Sa3nameElement.SendKeys(Keys.Tab);
			Sa3nameElement.SendKeys(Keys.Escape);
		}

		private String GetSa3name =>
			Sa3nameElement.Text;

		private void SetNumofpph (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "numofpph", intValue.ToString(), _isFastText);
			}
		}

		private int? GetNumofpph =>
			int.Parse(NumofpphElement.Text);

		private void SetPercentpphperday (Double? value)
		{
			if (value is double doubleValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "percentpphperday", doubleValue.ToString(), _isFastText);
			}
		}

		private Double? GetPercentpphperday =>
			Convert.ToDouble(PercentpphperdayElement.Text);
		private void SetSa2name (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "sa2name", value, _isFastText);
			Sa2nameElement.SendKeys(Keys.Tab);
			Sa2nameElement.SendKeys(Keys.Escape);
		}

		private String GetSa2name =>
			Sa2nameElement.Text;

		private void SetIndigenous (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "indigenous", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIndigenous =>
			int.Parse(IndigenousElement.Text);

		private void SetNonindigenous (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "nonindigenous", intValue.ToString(), _isFastText);
			}
		}

		private int? GetNonindigenous =>
			int.Parse(NonindigenousElement.Text);

		private void SetIrsd (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "irsd", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIrsd =>
			int.Parse(IrsdElement.Text);

		private void SetIrsad (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "irsad", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIrsad =>
			int.Parse(IrsadElement.Text);

		private void SetIer (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "ier", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIer =>
			int.Parse(IerElement.Text);

		private void SetIeo (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "ieo", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIeo =>
			int.Parse(IeoElement.Text);

		private void SetGapScore (Double? value)
		{
			if (value is double doubleValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "gapScore", doubleValue.ToString(), _isFastText);
			}
		}

		private Double? GetGapScore =>
			Convert.ToDouble(GapScoreElement.Text);
		private void SetNoservices (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "noservices", intValue.ToString(), _isFastText);
			}
		}

		private int? GetNoservices =>
			int.Parse(NoservicesElement.Text);

		private void SetTotalinvestment (Double? value)
		{
			if (value is double doubleValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "totalinvestment", doubleValue.ToString(), _isFastText);
			}
		}

		private Double? GetTotalinvestment =>
			Convert.ToDouble(TotalinvestmentElement.Text);

		// % protected region % [Add any additional getters and setters of web elements] off begin
		// % protected region % [Add any additional getters and setters of web elements] end
	}
}