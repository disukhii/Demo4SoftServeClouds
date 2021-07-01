﻿using NUnit.Framework;
using System.Threading;
using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("WishList")]
    [AllureDisplayIgnored]

    class WishListTests
    {
        private IWebDriver driver;

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
            driver.Navigate().GoToUrl(@"http://localhost/");
        }

        [Test]
        [AllureTag("OpenCart:WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Daria Slupachyk")]
        [Description("This test checks if user can add product to wish list being logged in")]
        public void AddToWishList_LoggedIn()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            HeaderComponent header1 = new HeaderComponent(driver);
            header1.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageProducts = new PageWithProducts(driver);
            string expected = pageProducts.GetSelectedProductName(pageProducts.FirstProductName);

            pageProducts.ClickWishListButton();

            string alertMessage = pageProducts.GetAlertMessageText();

            header.ClickOnWishList();

            WishListPage wishListPage = new WishListPage(driver);
            string actual = wishListPage.GetProductName();

            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.IsTrue(alertMessage.Contains("Success"));
                Assert.AreEqual(expected, actual);
            }
            catch (Exception) //Take a ScreenShot if test is failed
            {
                AfterTestScreen.SaveAsFile(@"../LV587SetOpencart/LV587SETOPENCART/LV587SETOPENCART/bin/Debug/net5.0/screens/ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", @"../LV587SetOpencart/LV587SETOPENCART/LV587SETOPENCART/bin/Debug/net5.0/screens/ScreenshotImageFormat.Png");
            }
            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
        }

        [Test]
        [AllureTag("OpenCart:WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Daria Slupachyk")]
        [Description("This test checks if user can add product to wish list being logged out")]
        public void AddToWishList_LoggedOut()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

            string actual = pageWithProduct.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("must login or create an account to save"));
        }

        [Test]
        [AllureTag("OpenCart:WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Daria Slupachyk")]
        [Description("This test checks if user can remove product from wish list")]
        public void RemoveFromWishListTest()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

            header.ClickOnWishList();

            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.RemoveProduct();

            string actual = wishListPage.GetAlertMessageText();

            Assert.IsTrue(actual.Contains("You have modified your wish list"));

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
        }

        [Test]
        [AllureTag("OpenCart:WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Daria Slupachyk")]
        [Description("This test checks if user can add product to the shopping cart from wish list")]
        public void AddToCartFromWishListTest()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

            header.ClickOnWishList();

            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.AddToCart();

            string alertMessage = wishListPage.GetAlertMessageText();

            string expected = wishListPage.GetProductName();

            header.ClickOnShoppingCartBlackButton();
            CartButtonComponent cartButton = new CartButtonComponent(driver);

            string actual = cartButton.GetProductNameInCart();

            Assert.IsTrue(alertMessage.Contains("Success"));
            Assert.AreEqual(expected, actual);

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
        }

        [Test]
        [AllureTag("OpenCart:WishList")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Daria Slupachyk")]
        [Description("This test verify if 'continue' button on wish list page works correctly")]
        public void ContinueButtonWishListTest()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            header.ClickOnWishList();

            WishListPage wishList = new WishListPage(driver);
            wishList.Continue();

            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string actual = myAccountPage.MyAccountText();

            Assert.IsTrue(actual.Contains("Account"));

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);

        }

    }
}
