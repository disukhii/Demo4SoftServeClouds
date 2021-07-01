﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    class CartPage : ClassWithDriver
    {
        //Quantity fiela
        //Unit Price (only first row)
        //Total price (down total)

        //Update button
        //remove button
        public IWebElement Quantity { get { return driver.FindElement(By.CssSelector(".text-left .input-group > input.form-control")); } }
        public IWebElement RefreshButton { get { return driver.FindElement(By.CssSelector(".fa-refresh")); } }
        public IWebElement RemoveInCartButton { get { return driver.FindElement(By.CssSelector(".fa-times-circle")); } }
        public IWebElement CartButtonSum { get { return driver.FindElement(By.CssSelector(".table-responsive .table-bordered tbody tr > td:last-child")); } }
        public IWebElement EmptyCart { get { return driver.FindElement(By.CssSelector(".col-sm-12 > p")); } }
        public IWebElement TotalPrice { get { return driver.FindElement(By.CssSelector(".col-sm-offset-8 .table-bordered tr:nth-child(2) td:nth-child(2)")); } }
        public IWebElement RefreshMessage { get { return driver.FindElement(By.CssSelector(".alert-success")); } }
        public IWebElement ContinueCartButton { get { return driver.FindElement(By.CssSelector(".pull-right > a[href*='home']")); } }
        public CartPage(IWebDriver driver) : base(driver) { }

        public void QuantityInput(string quantity)
        {
            //Quantity.Click();
            Quantity.Clear();
            Quantity.SendKeys(quantity);
        }
        public void RefreshButtonClick() 
        {
            RefreshButton.Click();
        }
        public void RemoveCircleInCartButton()
        {
            RemoveInCartButton.Click();
        }
        public string GetCartButtonSum()
        {
            return CartButtonSum.Text;
        }
        public string EmptyCartMessage()
        {
            return EmptyCart.Text;
        }
        public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }
        public string GetRefreshMessageText()
        {
            return RefreshMessage.Text;
        }
    }
}
