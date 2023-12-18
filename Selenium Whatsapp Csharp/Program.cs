using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Whatsapp_Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--user-data-dir=C:\\Users\\Gustavo Lacerda\\AppData\\Local\\Google\\Chrome\\User Data");
            options.AddArgument("--profile-directory=Profile 1");

            string url = "https://web.whatsapp.com/";
            ChromeDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);


            TimeSpan wait = TimeSpan.FromSeconds(3);


            while (true)
            {
                try
                {
                    var elementImage = driver.FindElement(By.CssSelector("span[data-icon='status-image']"));
                    if (elementImage != null)
                    {
                        var spanParent = elementImage.FindElement(By.XPath("./.."));

                        if (spanParent != null)
                        {
                            var spanGrandParent = spanParent.FindElement(By.XPath("./.."));    
                            if (spanGrandParent.Text == "$sticker")
                            {
                                Console.WriteLine("Encontrado");
                                IList<IWebElement> statusPhotoElements = driver.FindElements(By.CssSelector("span[data-icon='status-image']"));
                                foreach (IWebElement element in statusPhotoElements)
                                {
                                    Console.WriteLine(element);
                                }
                                Thread.Sleep(wait);
                                spanGrandParent.Click();
                                break;
                            }
                        }
                    };
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Não encontrado ainda");
                    Thread.Sleep(wait); 
                    continue;
                }
            }
        }
    }
}
