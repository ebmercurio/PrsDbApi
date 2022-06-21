using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Login.UITests {
    public class LoginWebAppShould {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage() {
            using (IWebDriver driver = new ChromeDriver()) {

                driver.Navigate().GoToUrl("http://localhost:4200/user/login");


            }
        }
    }
}
