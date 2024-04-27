using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace MyTestProject
{
    [Binding]
    public class AmazonAddItemToCartSteps
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ProductPage productPage;
        private CartPage cartPage;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            homePage = new HomePage(driver);
            homePage.GoTo();
        }

        [Given(@"I am on the Amazon home page")]
        public void GivenIAmOnTheAmazonHomePage()
        {
            // This step is already handled in the BeforeScenario hook
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string itemName)
        {
            // Search for the item
            homePage.SearchItem(itemName);
        }

        [When(@"I click on the first search result")]
        public void WhenIClickOnTheFirstSearchResult()
        {
            // Click on the first item
            productPage = homePage.ClickFirstItem();
        }

        [When(@"I add the item to the cart")]
        public void WhenIAddTheItemToTheCart()
        {
            // Add the item to the cart
            productPage.AddToCart();
        }

        [When(@"I go to the cart")]
        public void WhenIGoToTheCart()
        {
            // Navigate to the cart
            cartPage = productPage.GoToCart();
        }

        [Then(@"I validate the correct item and amount")]
        public void ThenIValidateTheCorrectItemAndAmount()
        {
            // Validate the correct item and amount
            Assert.AreEqual("TP-Link Tri-Band BE9300 WiFi 7 Router Archer BE550 | 6-Stream 9.2Gbps | 𝗙𝘂𝗹𝗹 𝟮.𝟱𝗚 Ports | USB 3.0 | 6 Smart Internal Antennas | VPN Clients & Server | Easy Mesh, HomeS…", cartPage.GetItemName().Trim(), "Incorrect item in the cart.");
            Assert.AreEqual("$249.00", cartPage.GetItemPrice().Trim(), "Incorrect item price in the cart.");
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
