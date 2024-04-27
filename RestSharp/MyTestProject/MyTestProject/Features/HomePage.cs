using OpenQA.Selenium;
using System;
using System.Threading;

namespace MyTestProject
{
    public class HomePage
    {
        private IWebDriver driver;
        private string url = "https://www.amazon.com/s?k=tp-link+n450+wifi+router-wireless+internet+router+for+home+tl-wr940n&crid=3RFUQTWTJRYZP&sprefix=TP-Link+N450+WiFi+Router+-+Wireless+Internet+Router+for+Home+%28TL-WR940N%29%2Caps%2C1278&ref=nb_sb_ss_ts-doa-p_1_71";
private string url2="https://www.amazon.com/ref=cs_503_link";
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(url2);
            Thread.Sleep(2000);
            
        }

        public void SearchItem(string itemName)
        {
            // Search for the item
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys(itemName);
            searchBox.SendKeys(Keys.Return);
            Thread.Sleep(3000); // Adding a delay to wait for search results to load
        }

        public ProductPage ClickFirstItem()
        {
            // Click on the first item
            IWebElement firstResult = driver.FindElement(By.XPath("//span[contains(text(),'Tri-Band BE9300 WiFi 7 Router Archer BE550 | 6-Str')]"));
            firstResult.Click();
            Thread.Sleep(2000); // Adding a delay to wait for product page to load
            return new ProductPage(driver);
        }
    }
}
