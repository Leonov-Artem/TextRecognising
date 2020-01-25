using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PhotoParser
{
    public class TextRecogniser
    {
        const string URL_PAGE_TRANSLATOR = "https://translate.yandex.ru/ocr";
        const string BODY = "//body";
        const string COPY_BUTTON = "copyButton";
        const string TRANSLATION_BUTTON = "/html/body/div[2]/div[1]/div[1]/div[4]/span[1]";
        const string SWITCH_DIRECTION_BUTTON = "/html/body/div[2]/div[2]/div[3]";
        const int WAIT_TIME = 1000;
        const double TEXT_RECOGNITION_WAITING = 10;
        static readonly string CTRL_V = Keys.Control + "v";

        IWebDriver _driver;

        public TextRecogniser()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        public TextRecogniser Recognize()
        {
            SwitchToPageWithTranslation();
            ClickOnSwitchDirection();
            Thread.Sleep(WAIT_TIME);

            return this;
        }

        public TextRecogniser Translate()
        {
            SwitchToPageWithTranslation();

            return this;
        }

        public void CopyToClipboard()
        {
            CopyTextFromArea();
            CloseBrowser();
        }

        private void SwitchToPageWithTranslation()
        {
            OpenTranslator();
            DragPhotoIntoBox();
            ClickOnTranslationButton();
            SwitchToLastTab();
        }

        private void OpenTranslator()
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

        private void ClickOnTranslationButton()
        {
            WaitHideElement
            (
                By.XPath(TRANSLATION_BUTTON),
                TEXT_RECOGNITION_WAITING
            ).Click();
        }

        private void CopyTextFromArea()
        {
            _driver
                .FindElement(By.Id(COPY_BUTTON))
                .Click();
        }

        /// <summary>
        /// Переключение между переводами. 
        /// Нужно для перемещения текста в блок, в котором есть кнопка копирования.
        /// </summary>
        private void ClickOnSwitchDirection()
        {
            var switchDirectionButton = _driver.FindElement(By.XPath(SWITCH_DIRECTION_BUTTON));
            switchDirectionButton.Click();
        }

        private void SwitchToLastTab()
        {
            string lastTabName = _driver.WindowHandles.Last();
            _driver = _driver
                        .SwitchTo()
                        .Window(lastTabName);
        }

        private IWebElement WaitHideElement(By by, double waitTime)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        private void CloseBrowser()
            => _driver.Quit();
    }
}
