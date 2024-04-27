using OpenQA.Selenium;
using System.Threading;

namespace MyTestProject
{
    public class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddToCart()
        {
            // Add the item to the cart
            IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
            addToCartButton.Click();
            Thread.Sleep(2000); // Adding a delay to wait for cart to update
        }

        public CartPage GoToCart()
        {
            // Navigate to the cart
            IWebElement cart = driver.FindElement(By.Id("nav-cart"));
            cart.Click();
            Thread.Sleep(9000); // Adding a delay to wait for the cart page to load
            return new CartPage(driver);
        }
    }
}
