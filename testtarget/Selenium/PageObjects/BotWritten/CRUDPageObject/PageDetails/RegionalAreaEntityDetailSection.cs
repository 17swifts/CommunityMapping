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
		private IWebElement Sa2codeHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='SA2Code']"));
		private IWebElement NameHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Name']"));
		private IWebElement NonindigenouspopulationHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='NonIndigenousPopulation']"));
		private IWebElement IndigenouspopulationHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='IndigenousPopulation']"));
		private IWebElement PphHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='PPH']"));
		private IWebElement IrsdHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='IRSD']"));
		private IWebElement IrsadHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='IRSAD']"));
		private IWebElement IeoHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='IEO']"));
		private IWebElement IerHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='IER']"));
		private IWebElement GapScoreHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='Gap Score']"));
		private IWebElement NoservicesHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='NoServices']"));
		private IWebElement TotalinvestmentHeaderTitle => _driver.FindElementExt(By.XPath("//th[text()='TotalInvestment']"));

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
			selectorDict.Add("Sa2codeElement", (selector: "//div[contains(@class, 'sa2code')]//input", type: SelectorType.XPath));
			selectorDict.Add("NameElement", (selector: "//div[contains(@class, 'name')]//input", type: SelectorType.XPath));
			selectorDict.Add("NonindigenouspopulationElement", (selector: "//div[contains(@class, 'nonindigenouspopulation')]//input", type: SelectorType.XPath));
			selectorDict.Add("IndigenouspopulationElement", (selector: "//div[contains(@class, 'indigenouspopulation')]//input", type: SelectorType.XPath));
			selectorDict.Add("PphElement", (selector: "//div[contains(@class, 'pph')]//input", type: SelectorType.XPath));
			selectorDict.Add("IrsdElement", (selector: "//div[contains(@class, 'irsd')]//input", type: SelectorType.XPath));
			selectorDict.Add("IrsadElement", (selector: "//div[contains(@class, 'irsad')]//input", type: SelectorType.XPath));
			selectorDict.Add("IeoElement", (selector: "//div[contains(@class, 'ieo')]//input", type: SelectorType.XPath));
			selectorDict.Add("IerElement", (selector: "//div[contains(@class, 'ier')]//input", type: SelectorType.XPath));
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
		private IWebElement Sa2codeElement => FindElementExt("Sa2codeElement");
		private IWebElement NameElement => FindElementExt("NameElement");
		private IWebElement NonindigenouspopulationElement => FindElementExt("NonindigenouspopulationElement");
		private IWebElement IndigenouspopulationElement => FindElementExt("IndigenouspopulationElement");
		private IWebElement PphElement => FindElementExt("PphElement");
		private IWebElement IrsdElement => FindElementExt("IrsdElement");
		private IWebElement IrsadElement => FindElementExt("IrsadElement");
		private IWebElement IeoElement => FindElementExt("IeoElement");
		private IWebElement IerElement => FindElementExt("IerElement");
		private IWebElement GapScoreElement => FindElementExt("GapScoreElement");
		private IWebElement NoservicesElement => FindElementExt("NoservicesElement");
		private IWebElement TotalinvestmentElement => FindElementExt("TotalinvestmentElement");

		// Return an IWebElement that can be used to sort an attribute.
		public IWebElement GetHeaderTile(string attribute)
		{
			return attribute switch
			{
				"SA2Code" => Sa2codeHeaderTitle,
				"Name" => NameHeaderTitle,
				"NonIndigenousPopulation" => NonindigenouspopulationHeaderTitle,
				"IndigenousPopulation" => IndigenouspopulationHeaderTitle,
				"PPH" => PphHeaderTitle,
				"IRSD" => IrsdHeaderTitle,
				"IRSAD" => IrsadHeaderTitle,
				"IEO" => IeoHeaderTitle,
				"IER" => IerHeaderTitle,
				"Gap Score" => GapScoreHeaderTitle,
				"NoServices" => NoservicesHeaderTitle,
				"TotalInvestment" => TotalinvestmentHeaderTitle,
				_ => throw new Exception($"Cannot find header tile {attribute}"),
			};
		}

		// Return an IWebElement for an attribute input
		public IWebElement GetInputElement(string attribute)
		{
			switch (attribute)
			{
				case "Sa2code":
					return Sa2codeElement;
				case "Name":
					return NameElement;
				case "Nonindigenouspopulation":
					return NonindigenouspopulationElement;
				case "Indigenouspopulation":
					return IndigenouspopulationElement;
				case "Pph":
					return PphElement;
				case "Irsd":
					return IrsdElement;
				case "Irsad":
					return IrsadElement;
				case "Ieo":
					return IeoElement;
				case "Ier":
					return IerElement;
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
				case "Sa2code":
					int? sa2code = null;
					if (int.TryParse(value, out var intSa2code))
					{
						sa2code = intSa2code;
					}
					SetSa2code(sa2code);
					break;
				case "Name":
					SetName(value);
					break;
				case "Nonindigenouspopulation":
					int? nonindigenouspopulation = null;
					if (int.TryParse(value, out var intNonindigenouspopulation))
					{
						nonindigenouspopulation = intNonindigenouspopulation;
					}
					SetNonindigenouspopulation(nonindigenouspopulation);
					break;
				case "Indigenouspopulation":
					int? indigenouspopulation = null;
					if (int.TryParse(value, out var intIndigenouspopulation))
					{
						indigenouspopulation = intIndigenouspopulation;
					}
					SetIndigenouspopulation(indigenouspopulation);
					break;
				case "Pph":
					int? pph = null;
					if (int.TryParse(value, out var intPph))
					{
						pph = intPph;
					}
					SetPph(pph);
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
				case "Ieo":
					int? ieo = null;
					if (int.TryParse(value, out var intIeo))
					{
						ieo = intIeo;
					}
					SetIeo(ieo);
					break;
				case "Ier":
					int? ier = null;
					if (int.TryParse(value, out var intIer))
					{
						ier = intIer;
					}
					SetIer(ier);
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
				"Sa2code" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.sa2code > div > p"),
				"Name" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.name > div > p"),
				"Nonindigenouspopulation" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.nonindigenouspopulation > div > p"),
				"Indigenouspopulation" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.indigenouspopulation > div > p"),
				"Pph" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.pph > div > p"),
				"Irsd" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.irsd > div > p"),
				"Irsad" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.irsad > div > p"),
				"Ieo" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.ieo > div > p"),
				"Ier" => WebElementUtils.GetElementAsBy(SelectorPathType.CSS, "div.ier > div > p"),
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
			SetSa2code(_regionalAreaEntity.Sa2code);
			SetName(_regionalAreaEntity.Name);
			SetNonindigenouspopulation(_regionalAreaEntity.Nonindigenouspopulation);
			SetIndigenouspopulation(_regionalAreaEntity.Indigenouspopulation);
			SetPph(_regionalAreaEntity.Pph);
			SetIrsd(_regionalAreaEntity.Irsd);
			SetIrsad(_regionalAreaEntity.Irsad);
			SetIeo(_regionalAreaEntity.Ieo);
			SetIer(_regionalAreaEntity.Ier);
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

		private void SetSa2code (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "sa2code", intValue.ToString(), _isFastText);
			}
		}

		private int? GetSa2code =>
			int.Parse(Sa2codeElement.Text);

		private void SetName (String value)
		{
			TypingUtils.InputEntityAttributeByClass(_driver, "name", value, _isFastText);
			NameElement.SendKeys(Keys.Tab);
			NameElement.SendKeys(Keys.Escape);
		}

		private String GetName =>
			NameElement.Text;

		private void SetNonindigenouspopulation (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "nonindigenouspopulation", intValue.ToString(), _isFastText);
			}
		}

		private int? GetNonindigenouspopulation =>
			int.Parse(NonindigenouspopulationElement.Text);

		private void SetIndigenouspopulation (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "indigenouspopulation", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIndigenouspopulation =>
			int.Parse(IndigenouspopulationElement.Text);

		private void SetPph (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "pph", intValue.ToString(), _isFastText);
			}
		}

		private int? GetPph =>
			int.Parse(PphElement.Text);

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

		private void SetIeo (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "ieo", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIeo =>
			int.Parse(IeoElement.Text);

		private void SetIer (int? value)
		{
			if (value is int intValue)
			{
				TypingUtils.InputEntityAttributeByClass(_driver, "ier", intValue.ToString(), _isFastText);
			}
		}

		private int? GetIer =>
			int.Parse(IerElement.Text);

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