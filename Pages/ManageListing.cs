using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    class ManageListing
    {

        public ManageListing()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialise web element
        //Click on the Manage Listings Button

        [FindsBy(How = How.XPath, Using = "//a[ @href='/Home/ListingManagement']")]
        private IWebElement ManageListingbtn { get; set; }

        //Click on Eye Icon
        [FindsBy(How = How.XPath, Using = "//tr[1]//td[8]//i[1]")]
        private IWebElement EyeIconbtn { get; set; }

        //Click on Edit list
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Editbtn { get; set; }

        // Title
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[2]")]

        public IWebElement Title { get; set; }

        //Title
        [FindsBy(How = How.XPath, Using = "(//td[@class='two wide'])[2]")]
        private IWebElement TitleName { get; set; }

        //Verify Delete listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement DeleteIcon { get; set; }


        //Click on Action Button
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive'][2]")]
        private IWebElement ActionBtn { get; set; }

        //Click on yes Button
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement YesBtn { get; set; }

        //Click on next page icon
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement NextPage { get; set; }



        #endregion

        internal void Listing()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("View Manage Listings");

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ManageListing");

            //Click on ManageListing tab
            ManageListingbtn.Click();
            Thread.Sleep(500);

            //Click on Eye icon
            EyeIconbtn.Click();
            Thread.Sleep(1000);

            //Click on Edit Button
            GlobalDefinitions.driver.Navigate().Back();
            Thread.Sleep(1000);
            Editbtn.Click();
            Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Edit Title"));
            GlobalDefinitions.driver.Navigate().Back();


            //delete  Skills 
            Thread.Sleep(1000);
            DeleteIcon.Click();

            //Click on Yes button
            Thread.Sleep(1000);
           GlobalDefinitions.driver.SwitchTo().Alert().Accept();
            



        }
    }
}
    

