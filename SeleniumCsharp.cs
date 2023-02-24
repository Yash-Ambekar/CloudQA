using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;
using System;

using System.Collections.ObjectModel;

using System.IO;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharp

{

    class firstProgram
    {
        public class Tests
        {
            IWebDriver driver;

            [OneTimeSetUp]

            public void Setup()

            {

                //Below code is to get the drivers folder path dynamically.

                //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

                //Creates the ChomeDriver object, Executes tests on Google Chrome

                driver = new ChromeDriver(path + @"\drivers\");

                //If you want to Execute Tests on Firefox uncomment the below code

                // Specify Correct location of geckodriver.exe folder path. Ex: C:/Project/drivers

                //driver= new FirefoxDriver(path + @"\drivers\");

            }

            [Test]
            public void Test()
            {
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

                //Inputing the first name

                driver.FindElement(By.Id("fname")).SendKeys("Yash");

                //Inputing the last name

                driver.FindElement(By.Id("lname")).SendKeys("Ambekar");

                //Inputing the mobile number
                driver.FindElement(By.Id("mobile"))
                    .SendKeys("873575872");

                //Switching to a different Frame

                /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));*/

                driver.SwitchTo().Frame("iframeId");
                Console.WriteLine("Switching to the frame");
                driver.FindElement(By.Id("fname")).SendKeys("Yash");
                driver.FindElement(By.Id("lname"))
                    .SendKeys("Ambekar");
                driver.FindElement(By.Id("mobile"))
                    .SendKeys("873575872");
                
                //Switching back to original frame

                driver.SwitchTo().DefaultContent();

                //Switching to another Frame without ID 

                driver.SwitchTo().Frame(driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/iframe")));
                Console.WriteLine("Switching to the frame");
                driver.FindElement(By.Id("fname"))
                    .SendKeys("Yash");
                driver.FindElement(By.Id("lname"))
                    .SendKeys("Ambekar");
                driver.FindElement(By.Id("mobile"))
                    .SendKeys("873575872");

                //Switching to Nested Frame

                driver.SwitchTo().Frame(0);
                Console.WriteLine("Switching to the frame");
                driver.FindElement(By.Id("fname"))
                    .SendKeys("Yash");
                driver.FindElement(By.Id("lname"))
                    .SendKeys("Ambekar");
                driver.FindElement(By.Id("mobile"))
                    .SendKeys("873575872");

                //Switching to Inner Nested Form

                driver.SwitchTo().Frame(0);
                Console.WriteLine("Switching to the frame");
                driver.FindElement(By.Id("fname"))
                    .SendKeys("Yash");
                driver.FindElement(By.Id("lname"))
                    .SendKeys("Ambekar");
                driver.FindElement(By.Id("mobile"))
                    .SendKeys("873575872");

                //Switching to main content

                driver.SwitchTo().DefaultContent();

                //Handling Shadow DOM
                driver.FindElement(By.TagName("shadow-form")).GetShadowRoot()
                                    .FindElement(By.Id("fname"))
                                    .SendKeys("Yash");








            }


        }
    }


}