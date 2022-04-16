using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumExercise
{
    public class Tests
    {
        IWebDriver driver;
        private object baseUrl;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "http://demo.guru99.com/test/ajax.html";
            driver.FindElement(By.Id("no")).Click();
            driver.FindElement(By.Id("buttoncheck")).Click();

        }
        [Test]
        public void Test2()
        {
            driver.Url = "http://demo.guru99.com/test/ajax.html";
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name("name"));

            Console.WriteLine("Number of elements:" + elements.Count());

            for (int i = 0; i < elements.Count; i++)
            {
                Console.WriteLine("Radio button text:" + elements.ElementAt(1).GetAttribute("value"));
            }


        }


        [Test]

        public void Test3()

        {
            driver.Url = "http://demo.guru99.com/test/login.html";
            IWebElement email = driver.FindElement(By.Id("email"));
            IWebElement password = driver.FindElement(By.Name("password"));

            email.SendKeys("abcd@gmail.com");
            password.SendKeys("abcdefghlkjl");
            Console.WriteLine("Text Field Set");

            email.Clear();
            password.Clear();
            Console.WriteLine("Text Field Cleared");

            IWebElement login = driver.FindElement(By.Id("SubmitLogin"));

            email.SendKeys("abcd@gmail.com");
            password.SendKeys("abcdefghlkjl");
            login.Click();
            Console.WriteLine("Login Done with Click");

            Actions action = new Actions(driver);


            driver.FindElement(By.Id("email")).SendKeys("abcd@gmail.com");
            driver.FindElement(By.Name("passwd")).SendKeys("abcdefghlkjl");
            action.MoveToElement(driver.FindElement(By.Name("SubmitLogin"))).Clock().Perform();
            Console.WriteLine("Login Done with Submit");

        }

        [TearDown]

        public void closeBrowser()
        {
            driver.Close();
        }
    }
}