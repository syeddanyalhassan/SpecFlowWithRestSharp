using OpenQA.Selenium;

namespace MyTestProject
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetItemName()
        {
            // Validate the correct item
            IWebElement cartItem = driver.FindElement(By.CssSelector(".sc-product-title"));
            return cartItem.Text.Trim();
        }

        public string GetItemPrice()
        {
            // Validate the correct item price
            IWebElement cartItemPrice = driver.FindElement(By.Id("sc-subtotal-amount-buybox"));
            return cartItemPrice.Text.Trim();
        }
    }
}
