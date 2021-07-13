using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace MovieAppTests
{
    public class CreatePagePOM
    {
        private readonly IWebDriver driver = new ChromeDriver();

        public CreatePagePOM()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.Id("title")));
        }

        public IWebElement TextTitle
        {
            get { return driver.FindElement(By.Id("title")); }
        }

        public IWebElement TextReleaseDate
        {
            get { return driver.FindElement(By.Id("releaseDate")); }
        }

        public IWebElement TextRating
        {
            get { return driver.FindElement(By.Id("rating")); }
        }

        public IWebElement ButtonSave
        {
            get { return driver.FindElement(By.Id("saveButton")); }
        }

        private IWebElement ButtonHome
        {
            get { return driver.FindElement(By.Id("topNavBar")).FindElement(By.LinkText("Home")); }

        }

        public HomePagePOM ButtonSaveClick()
        {
            ButtonSave.Click();
            return new HomePagePOM();
        }

        public HomePagePOM ButtonHomeClick()
        {
            ButtonHome.Click();
            return new HomePagePOM();
        }

    }
}
