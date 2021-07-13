using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace MovieAppTests
{
    [TestClass]
    public class AddMovieTests
    {
        private readonly string _url = "[LoginPageURL]";
        private readonly string _userName = "[userNameValue]";
        private readonly string _password = "[passwordValue]";
        private string _titleAdded;
        private readonly IWebDriver driver = new ChromeDriver();
        private List<string> movies;


        private bool IsButtonEnabled(IWebElement button)
        {
            bool enabled = false;
            if (button.Enabled)
            {
                enabled = true;
            }
            return enabled;
        }

        private bool IsErrorDisplayed(string id)
        {
            bool error = false;
            if (driver.FindElement(By.Id(id)).Displayed)
            {
                error = true;
            }
            return error;
        }

        private void TextInput(IWebElement field, string text)
        {
            field.Clear();
            field.SendKeys(text);
        }


        [TestMethod]
        public void AddMovieSuccessful()
        {
            try
            {
                driver.Navigate().GoToUrl(_url);
                
                LoginPage login = new LoginPage();
                /*Assume these fields exist*/
                //login.UserName.SendKeys(_userName);
                //login.UserName.SendKeys(_password);             
                HomePagePOM homePagePOM = login.ButtonClick();
                movies = homePagePOM.MovieDetails();
                int count = movies.Count;

                CreatePagePOM createPagePOM = homePagePOM.ClickAddMovieLink();
                TextInput(createPagePOM.TextTitle, "Nomadland");
                TextInput(createPagePOM.TextReleaseDate, "2/19/2021");
                TextInput(createPagePOM.TextRating, "3");
                _titleAdded = createPagePOM.TextTitle.Text;

                Assert.IsTrue(IsButtonEnabled(createPagePOM.ButtonSave), "Button is disabled!");

                homePagePOM = createPagePOM.ButtonSaveClick();
                List<string> currentMovies = homePagePOM.MovieDetails();
                Assert.AreEqual(count + 1, currentMovies.Count, "List count should increase by 1!");
                int i = currentMovies.IndexOf(_titleAdded);
                Assert.IsTrue(currentMovies[i].Contains("2/19/2021") && currentMovies[i].Contains("3"), "Movie was not successfully added to list!");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception is: {0}", ex);
            }

        }

        [TestMethod]
        public void AddMovieInvalidTitle()
        {
            try
            {
                driver.Navigate().GoToUrl(_url);
                
                LoginPage login = new LoginPage();
                /*Assume these fields exist*/
                //login.UserName.SendKeys(_userName);
                //login.UserName.SendKeys(_password);             
                HomePagePOM homePagePOM = login.ButtonClick();
                movies = homePagePOM.MovieDetails();
                int count = movies.Count;

                CreatePagePOM createPagePOM = homePagePOM.ClickAddMovieLink();
                TextInput(createPagePOM.TextTitle, "Fdahfjdhfjdahfkjeahejkahrejjhdfjhajvbejkrbeajrhjeahfjkahfjhfejahrejhrelhrajehrejahreajlrhejwakhreakhrejkahrejahrjeahrelkauvczhvuidhvuhereamrmernkeafdahfodjaf lkjfklafjkeajrekjkwejrkeljrkwejrklwejrlkwefafefgeag");
                TextInput(createPagePOM.TextReleaseDate, "2/19/2021");
                TextInput(createPagePOM.TextRating, "2");
                _titleAdded = createPagePOM.TextTitle.Text;

                Assert.IsTrue(IsErrorDisplayed("title"), "No error message was displayed!");
                Assert.IsFalse(IsButtonEnabled(createPagePOM.ButtonSave), "Button should not be enabled!");

                homePagePOM = createPagePOM.ButtonHomeClick();
                List<string> currentMovies = homePagePOM.MovieDetails();
                Assert.AreEqual(count, currentMovies.Count, "A new row should not have been added to list!");
                Assert.IsFalse(currentMovies.Contains(_titleAdded), "Title should not exist in list!");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception is: {0}", ex);
            }
        }

        [TestMethod]
        public void AddMovieInvalidReleaseDate()
        {
            try
            {
                driver.Navigate().GoToUrl(_url);
                LoginPage login = new LoginPage();
                /*Assume these fields exist*/
                //login.UserName.SendKeys(_userName);
                //login.UserName.SendKeys(_password);             
                HomePagePOM homePagePOM = login.ButtonClick();
                movies = homePagePOM.MovieDetails();
                int count = movies.Count;

                CreatePagePOM createPagePOM = homePagePOM.ClickAddMovieLink();
                TextInput(createPagePOM.TextTitle, "Eternal Sunshine of the Spotless Mind");
                TextInput(createPagePOM.TextReleaseDate, "3/19/04");
                TextInput(createPagePOM.TextRating, "4");
                _titleAdded = createPagePOM.TextTitle.Text;

                Assert.IsTrue(IsErrorDisplayed("releaseDate"), "No error message was displayed!");
                Assert.IsFalse(IsButtonEnabled(createPagePOM.ButtonSave), "Button should not be enabled!");

                homePagePOM = createPagePOM.ButtonHomeClick();
                List<string> currentMovies = homePagePOM.MovieDetails();
                Assert.AreEqual(count, currentMovies.Count, "A new row should not have been added to list!");
                Assert.IsFalse(currentMovies.Contains(_titleAdded), "Title should not exist in list!");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception is: {0}", ex);
            }
        }

        [TestMethod]
        public void AddMovieInvalidRating()
        {
            try
            {
                driver.Navigate().GoToUrl(_url);
                LoginPage login = new LoginPage();
                /*Assume these fields exist*/
                //login.UserName.SendKeys(_userName);
                //login.UserName.SendKeys(_password);             
                HomePagePOM homePagePOM = login.ButtonClick();
                movies = homePagePOM.MovieDetails();
                int count = movies.Count;

                CreatePagePOM createPagePOM = homePagePOM.ClickAddMovieLink();
                TextInput(createPagePOM.TextTitle, "A Quiet Place Part II");
                TextInput(createPagePOM.TextReleaseDate, "5/21/2021");
                TextInput(createPagePOM.TextRating, "B");
                _titleAdded = createPagePOM.TextTitle.Text;

                Assert.IsTrue(IsErrorDisplayed("rating"), "No error message was displayed!");
                Assert.IsFalse(IsButtonEnabled(createPagePOM.ButtonSave), "Button should not be enabled!");

                homePagePOM = createPagePOM.ButtonHomeClick();
                List<string> currentMovies = homePagePOM.MovieDetails();
                Assert.AreEqual(count, currentMovies.Count, "A new row should not have been added to list!");
                Assert.IsFalse(currentMovies.Contains(_titleAdded), "Title should not exist in list!");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception is: {0}", ex);
            }
        }
    }
}
