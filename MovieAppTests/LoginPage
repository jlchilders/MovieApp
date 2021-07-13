using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MovieAppTests
{
    public class LoginPage
    {
        private readonly IWebDriver driver = new ChromeDriver();
        private IWebElement ButtonLogin
        {
            get { return driver.FindElement(By.Id("loginBtn")); }

        }
        public HomePagePOM ButtonClick()
        {
            ButtonLogin.Click();
            return new HomePagePOM();
        }
    }
}
