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
using System.Net.WebSockets;

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
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            }

            [Test]
            public void Test()
            {
               
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
                /*driver.FindElement(By.TagName("shadow-form")).GetShadowRoot()
                                    .FindElement(By.ClassName("row"))
                                    .FindElement(By.TagName("slot"))
                                    .FindElement(By.TagName("select"));*/

                var shadow_form = driver.FindElement(By.TagName("shadow-form"));
                shadow_form.FindElement(By.Id("fname")).SendKeys("Yash");
                shadow_form.FindElement(By.Id("lname")).SendKeys("Ambekar");
                shadow_form.FindElement(By.Id("male")).Click();

                driver.SwitchTo().DefaultContent();

                //2 ShadowDOMS
                var nestedShadowForm = driver.FindElement(By.TagName("nestedshadow-form"));
                var shadowRoot = nestedShadowForm.GetShadowRoot();
                var shadowForm = shadowRoot.FindElement(By.CssSelector("shadow-form"));
                shadowForm.FindElement(By.Id("fname")).SendKeys("Yash");
                shadowForm.FindElement(By.Id("lname")).SendKeys("Ambekar");
                shadowForm.FindElement(By.Id("male")).Click();

                driver.SwitchTo().DefaultContent();


            }

            [Test]
            public void NestedShadowDOM3()
            {
                var deepShadowRoot = driver.FindElement(By.TagName("nestedshadow-form3"))
                                            .GetShadowRoot()
                                            .FindElement(By.CssSelector("nestedshadow-form"))
                                            .GetShadowRoot()
                                             .FindElement(By.CssSelector("shadow-form"));
                deepShadowRoot.FindElement(By.Id("fname")).SendKeys("Yash");
                deepShadowRoot.FindElement(By.Id("lname")).SendKeys("Ambekar");
                deepShadowRoot.FindElement(By.Id("male")).Click();
            }

            [Test]
            public void NestedShadowDOM4()
            {
                var deepShadowRoot = driver.FindElement(By.TagName("nestedshadow-form4"))
                                            .GetShadowRoot()
                                            .FindElement(By.CssSelector("nestedshadow-form3"))
                                            .GetShadowRoot()
                                             .FindElement(By.CssSelector("nestedshadow-form"))
                                             .GetShadowRoot()
                                             .FindElement(By.CssSelector("shadow-form"));
                deepShadowRoot.FindElement(By.Id("fname")).SendKeys("Yash");
                deepShadowRoot.FindElement(By.Id("lname")).SendKeys("Ambekar");
                deepShadowRoot.FindElement(By.Id("male")).Click();
            }

            [Test]
            public void NestedShadowDOM5()
            {
                var deepShadowRoot = driver.FindElement(By.TagName("nestedshadow-form5"))
                                            .GetShadowRoot()
                                            .FindElement(By.CssSelector("nestedshadow-form4"))
                                            .GetShadowRoot()
                                             .FindElement(By.CssSelector("nestedshadow-form3"))
                                             .GetShadowRoot()
                                             .FindElement(By.CssSelector("nestedshadow-form"))
                                             .GetShadowRoot()
                                             .FindElement(By.CssSelector("shadow-form"));
                deepShadowRoot.FindElement(By.Id("fname")).SendKeys("Yash");
                deepShadowRoot.FindElement(By.Id("lname")).SendKeys("Ambekar");
                deepShadowRoot.FindElement(By.Id("male")).Click();
            }

            [Test]

            public void NestedShadowDOM6()
            {
                var level = 6;
                var midShadowRoot = driver.FindElement(By.TagName("nestedshadow-form" + level));

                for(int i = 5; i >=3; i--)
                {
                    midShadowRoot = midShadowRoot.GetShadowRoot()
                        .FindElement(By.CssSelector("nestedshadow-form" + i));
                }

                var deepShadowRoot = midShadowRoot.GetShadowRoot()
                                                 .FindElement(By.CssSelector("nestedshadow-form"))
                                                 .GetShadowRoot()
                                                 .FindElement(By.CssSelector("shadow-form"));

                deepShadowRoot.FindElement(By.Id("fname")).SendKeys("Yash");
                deepShadowRoot.FindElement(By.Id("lname")).SendKeys("Ambekar");
                deepShadowRoot.FindElement(By.Id("male")).Click();

            }

            [Test]
            public void IframeinsideShadowDom()
            {
                var shadowRoot = driver.FindElement(By.TagName("nestedshadow-iframe")).GetShadowRoot();
                var iframe = shadowRoot.FindElement(By.CssSelector("iframe"));
                driver.SwitchTo().Frame(iframe);
            }



        }
    }


}