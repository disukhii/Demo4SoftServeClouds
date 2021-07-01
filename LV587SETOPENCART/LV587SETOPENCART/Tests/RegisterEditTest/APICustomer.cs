﻿using NUnit.Framework;
using System.Threading;
using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using RestSharp;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class APICustomer
    {
        [Test]
        public void CustomerApiTest()
        {
            var client = new RestClient("http://localhost/index.php?route=api/customer&api_token=281a0632abb9988e61816bd5ad");
            
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("firstname", "Dima");
            request.AddParameter("lastname", "Sukhii");
            request.AddParameter("email", "user1@gmail.com");
            request.AddParameter("telephone", "0930020102");

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            //Assert

            Assert.True(response.Content.Contains("success"));
            Assert.AreEqual(true, response.IsSuccessful);
            

        }


    }
}
