using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace PhotoParser
{
    public class TextRecogniser
    {
        const string URL_PAGE_TRANSLATOR = "https://translate.yandex.ru/ocr";
        const string BODY = "//body";
        const string OPEN_IN_TRANSLATOR_BUTTON = "/html/body/div[2]/div[1]/div[1]/div[4]/span[1]";
        const string SWAP_TRANSLATIONS_BUTTON = "/html/body/div[2]/div[2]/div[3]";
        const int WAIT_TIME = 5000;
        static readonly string CTRL_V = Keys.Control + "v";

        IWebDriver _driver;

        public TextRecogniser()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        public void RecognizeAndCopyToClipboard()
        {
            OpenTranslatePage();
            DragPhotoIntoBox();
            OpenPageWithTranslation();
            IWebDriver driver = SwapTranslations();
            CopyTextFromArea(driver);
            CloseBrowser();     
        }

        public void Recognize()
        {

        }

        public void Translate()
        {
            OpenTranslatePage();
            DragPhotoIntoBox();
            OpenPageWithTranslation();
            IWebDriver driver = SwitchToLastTab();
            CopyTextFromArea(driver);
            CloseBrowser();
        }

        private void OpenTranslatePage()
        {
            _driver
                .Navigate()
                .GoToUrl(URL_PAGE_TRANSLATOR);
        }

        private void DragPhotoIntoBox()
        {
            _driver
                .FindElement(By.XPath(BODY))
                .SendKeys(CTRL_V);
        }

        private void OpenPageWithTranslation()
        {
            DoTaskWithWait(By.XPath(OPEN_IN_TRANSLATOR_BUTTON));

            //Thread.Sleep(WAIT_TIME);
            //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME));
            //var element = wait.Until((d) => d.FindElement(By.XPath(OPEN_IN_TRANSLATOR_BUTTON)));
            //element.Click();
        }

        private void CopyTextFromArea(IWebDriver driver=null)
        {
            DoTaskWithWait(By.Id("copyButton"), driver);
        }

        private IWebDriver SwapTranslations()
        {
            IWebDriver lastTab = SwitchToLastTab();
            var swapTranslationsButton = lastTab.FindElement(By.XPath(SWAP_TRANSLATIONS_BUTTON));
            swapTranslationsButton.Click();

            return lastTab;
        }

        private IWebDriver SwitchToLastTab()
        {
            return _driver
                        .SwitchTo()
                        .Window(_driver.WindowHandles.Last());
        }

        private void CloseBrowser()
            => _driver.Quit();

        private void DoTaskWithWait(By by, IWebDriver driver = null)
        {
            if (driver == null)
                driver = _driver;

            Thread.Sleep(WAIT_TIME);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIME));
            var element = wait.Until((d) => d.FindElement(by));
            element.Click();
        }
    }
}
