﻿
using System;
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
using System.Threading;

namespace LV587SETOPENCART.Tests

{
    [TestFixture]
  //  [AllureNUnit]
  //  [AllureSuite("[Register] Entering incorrect data in fields of register ")]
  //   [AllureDisplayIgnored]
    class VerifyRegInputFieldsTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(@"http://34.198.140.2/");
        }
        [Test]
      //  [AllureTag("OpenCart: Verify warning message in Register Test")]
      //  [AllureSeverity(SeverityLevel.critical)]
      //  [AllureOwner("Sukhii Dmitro")]
      //  [Description("The test check that you cannot create new customer account if this email is used (Registration)")]
        public void RegisterPageTest()
        {
            // Click on My Account > Register
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Register);

            Thread.Sleep(1000);//only for presentation

            // Execute all test methods for fill in the fields
            RegisterPage registerPage = new RegisterPage(driver);
            registerPage.SetFirstNameInputTextAndClear("Dima");
            registerPage.SetLastNameInputTextAndClear("Sukhii");
            registerPage.SetEmailInputTextAndClear("tasfest@gmail");
            registerPage.SetTelephoneInputTextAndClear("0930020102");
            registerPage.SetPasswordInputTextAndClear("qwerty12345678");
            registerPage.SetPasswordConfirmInputTextAndClear("qwerty");
            Thread.Sleep(1000);//only for presentation
            registerPage.ClickSubscribeRadioButton();
            Thread.Sleep(1000);//only for presentation
            registerPage.ClickConfirmButton();
            Thread.Sleep(1000);//only for presentation

            // verify that user geted exception message
            string expResGeneralWarningMessage = "Warning: You must agree to the Privacy Policy!";
            string expResEmailWarningMessage = "E-Mail Address does not appear to be valid!";
            string expResPasswordWarningMessage = "Password confirmation does not match password!";

            //Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expResGeneralWarningMessage, registerPage.VerifyGeneralExeptionRegText());
            }
            catch (Exception)
            {
          //      AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
        //        AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png");
            }

            Thread.Sleep(1000);//only for presentation

            try
            {
                Assert.AreEqual(expResEmailWarningMessage, registerPage.VerifyExeptionEmailText());
            }
            catch (Exception)
            {
            //    AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
              //  AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png");
            }

            Thread.Sleep(1000);//only for presentation

            try
            {
                Assert.AreEqual(expResPasswordWarningMessage, registerPage.VerifyExeptionPasswordText());
            }
            catch (Exception)
            {
            //    AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
            //    AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png");
            }

            Thread.Sleep(1000);//only for presentation



        }

    }
}
