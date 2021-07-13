using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace MovieAppTests
{
    public class HomePagePOM
    {
        IWebDriver driver = new ChromeDriver();
        public IWebElement LinkAddMovie
        {
            get { return driver.FindElement(By.Id("[ID]")); }
        }

        public CreatePagePOM ClickAddMovieLink()
        {
            LinkAddMovie.Click();
            return new CreatePagePOM();
        }

        //Assume method that returns a new list of movie details whenever called
        public List<string> MovieDetails()
        {
            List<string> details = new List<string>();
            return details;
        }

    }
}
