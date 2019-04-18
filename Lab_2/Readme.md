```javascript
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Collections.ObjectModel;
using System.Drawing;

namespace CheckSelenium
{
    class Program
    {
        public class Product
        {
            public string name;
            public string price;
            public Product(string name, string price)
            {
                this.name = name;
                this.price = price;
            }
        }
        
        static void Main(string[] args)
        {
            //Path of chromedriver.exe:  
            IWebDriver driver = new ChromeDriver(@"C:\Users\VladG\source\repos\CheckSelenium\packages\Selenium.Chrome.WebDriver.2.45\driver");
            driver.Navigate().GoToUrl(@"https://price.md/ru/clothing-shoes-accessories/for-men/mens_belts");

            bool GoForward = true;
            List<Product> products = new List<Product>();

            int currentPage = 1;

            do
            {
                var links = driver.FindElement(By.Id("products_container")).FindElements(By.Name("div.category-slider-item"));

                foreach (var iter in links)
                    //div[@class='']
                {
                    string name = iter.FindElement(By.XPath(".//*[@id='products_container']/div[4]/a")).Text;
                    string price = iter.FindElement(By.XPath(".//*[@id='products_container']/div[4]/#text")).Text;
                    //string name = iter.FindElement(By.ClassName("category-slider-item-title")).FindElement(By.TagName("a")).Text;
                    //string price = iter.FindElement(By.ClassName("category-slider-item-price")).FindElement(By.TagName("#text")).Text;
                    Console.WriteLine(name + "  " + price);
                    products.Add(new Product(name, price));
                }

                int newPage = 0;

                try
                {
                    newPage = Int32.Parse(driver.FindElement(By.ClassName("paginator-base")).FindElement(By.TagName("a")).Text);
                    if (currentPage >= newPage)
                    {
                        GoForward = false;
                        currentPage = newPage;
                        break;
                    }

                    driver.FindElement(By.ClassName("paginator-base")).FindElement(By.TagName("a")).Click();
                    
                    //System.Threading.Thread.Sleep(4500);
                }
                catch (Exception e)
                {
                    GoForward = false;
                }
                Console.WriteLine(newPage);
            } while (GoForward);

            driver.Close();

            foreach(var p in products)
            {
                Console.WriteLine(p.name + ' ' + p.price);
            }
            Console.ReadKey();
        }
    }
}
```