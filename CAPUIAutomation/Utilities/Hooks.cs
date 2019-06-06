using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CAPUIAutomation.Utilities
{
    [Binding]
    public sealed class Hooks : BaseTest
    {
        private readonly IObjectContainer _objectContainer;
        new IWebDriver _webDriver;
        WebDriverHelper Driver;
        string BrowserConfig => ConfigurationManager.AppSettings["browser"];
        string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public Hooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }
        public Hooks()
        {
        }

        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            _webDriver = GetDriver("local", AppSetting("browser").ToString());
            Driver = new WebDriverHelper(_webDriver);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
            Driver.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(4000);
            Driver.CloseDriver();
        }
    }

    public abstract class BaseTest
    {
        protected IWebDriver _webDriver;

        /// <summary>
        /// Create and returns the WebDriver / Remote WebDriver instance based on the executionType parameter
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /// <param name="executionType">When passed with value "local", will execute in your local machine, else will execute in a Selenium Grid</param>
        /// <returns>IWebDriver instance</returns>
        public IWebDriver GetDriver(string executionType, string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //option.AddArgument("--headless");
                    _webDriver = executionType.ToLower().Equals("local") ? new ChromeDriver(chromeOptions) :
                        new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;

                case "firefox":
                case "ff":
                case "fire fox":
                    /*var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;*/
                    FirefoxOptions FFOptions = new FirefoxOptions();
                    _webDriver = executionType.ToLower().Equals("local") ? new FirefoxDriver() :
                        new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), FFOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;

                case "internetexplorer":
                case "internet explorer":
                case "IE":
                    InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
                    internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    _webDriver = executionType.ToLower().Equals("local") ? new InternetExplorerDriver() :
                    new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), internetExplorerOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;

                default:
                    throw new NotSupportedException($"{browserType} is not a supported browser. Please provide valid browser name.");
            }
            Thread.Sleep(5000);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return _webDriver;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// If the setting is not specified the default value is returned.
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <param name="defaultValue">The default value of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSettingOrDefault(string key, string defaultValue)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
                appSetting = defaultValue;

            return appSetting;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }

        public IWebElement FindElement(By by,IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return ele;
        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int FindElements(By by,IWebDriver driver)
        {
            return driver.FindElements(by).Count;
        }

    }
}
