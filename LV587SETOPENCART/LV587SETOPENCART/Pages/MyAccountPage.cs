﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace LV587SETOPENCART.Pages
{
    class MyAccountPage : ClassWithDriver
    {
        public IWebElement textPageAccount { get { return driver.FindElement(By.CssSelector("#content.col-sm-9 > h2:first-child")); } }
        public IWebElement accountUpdatedText { get { return driver.FindElement(By.CssSelector("div.alert.alert-success.alert-dismissible")); } }

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }
        
        public string MyAccountText()
        {
            return textPageAccount.Text;
        }
        public string VerifyAccountUpdateText()
        {
            return accountUpdatedText.Text;
        }


    }
}
