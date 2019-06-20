using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);


        }

        #region Initialize Elements
        //shareSKILLS
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ServiceListing']")]
        public IWebElement ShareSkills { get; set; }


        // Title
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Write a title to describe the service you provide.']")]

        public IWebElement Title { get; set; }


        // Description

        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        public IWebElement Description { get; set; }

        // Select Category

        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId' and @class='ui fluid dropdown']")]
        public IWebElement Category { get; set; }

        // Select Programming & Tech

        [FindsBy(How = How.XPath, Using = "//option[@value='6']")]
        public IWebElement ProgrammingandTech { get; set; }


        //Click on  SubCategory button
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        public IWebElement SubCategory { get; set; }

        //Select SubCategory  QA
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'QA')]")]
        public IWebElement QA { get; set; }


        //Select Tag Names
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField' and @aria-label='Add new tag'])[1]")]

        public IWebElement Tags { get; set; }

        //Select Service Type -Hourly Basis
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0']")]
        public IWebElement ServiceTypeHourly { get; set; }

        //Select Service Type -One-off
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        public IWebElement ServiceTypeOneOff { get; set; }

        //Select Location Type - Onsite
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        public IWebElement LocationTypeOnsite { get; set; }

        //Select Location Type - Online
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        public IWebElement LocationTypeOnline { get; set; }

        //Avilable Days -Start Date
        [FindsBy(How = How.XPath, Using = "(//input[contains(@max,'9999-12-31')])[1]")]
        public IWebElement StartDate { get; set; }

        //Avilable Days -End Date
        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'End date')]")]
        public IWebElement EndDate { get; set; }

        //Select the day
        [FindsBy(How = How.XPath, Using = "//input[@index='0']")]
        public IWebElement SelectDays { get; set; }

        //Start Time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='0' ]")]
        public IWebElement StartTime { get; set; }

        //End Time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='0' ]")]
        public IWebElement EndTime { get; set; }

        //Skill Trade - Skill Exchange
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='true']")]
        public IWebElement SkillExchange { get; set; }

        //Skills Exchange-Skills to be trade 
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[2]")]
        public IWebElement Skillstrade { get; set; }

        //Skill Trdae- credit
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")]
        public IWebElement Credit { get; set; }

        //Credit - Enter Amount
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        public IWebElement CreditAmount { get; set; }

        //Work Sample
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        public IWebElement Sample { get; set; }

        //Status- Active
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true']")]
        public IWebElement Active { get; set; }


        // Status- Hidden
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        public IWebElement Hidden { get; set; }

        //Save Skills 
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Save']")]
        public IWebElement Save { get; set; }

        //Cancel Skills
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Cancel']")]
        public IWebElement Cancel { get; set; }

        #endregion

        #region Add new Skill
        //public void AddNewShareSkill()
       
        internal void AddNewSkill()
        {
            {

                #region Enter the deatils

                //Click on Share Skill button
                Thread.Sleep(1000);
                ShareSkills.Click();
                Thread.Sleep(1000);

                //Populate the excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkills");

                // Enter Title
                Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
                Base.test.Log(LogStatus.Info, "Title has been successfully entered");

                //Enter description
                Description.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
                Base.test.Log(LogStatus.Info, "Description has been successfully entered");

                //click on category dropdown menu
                Thread.Sleep(500);
                Category.Click();
                Thread.Sleep(1000);


                //Select the category
                Thread.Sleep(500);
                ProgrammingandTech.Click();
                Thread.Sleep(500);



                //Click on subcatogory drop down option 
                Thread.Sleep(1000);
                SubCategory.Click();

                //Select the Sub-Category option
                Thread.Sleep(500);
                QA.Click();
                Thread.Sleep(500);

                //Enter Tags
                Tags.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);
                Base.test.Log(LogStatus.Info, "TagName has been successfully entered");

                //Select service type
                //ServiceTypeHourly.Click();

                if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
                {
                    ServiceTypeHourly.Click();
                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "One-off service")
                {
                    ServiceTypeOneOff.Click();
                }

                //Select Location Type
                //LocationTypeOnline.Click();
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
                {
                    LocationTypeOnline.Click();
                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "On-site")
                {
                    LocationTypeOnsite.Click();
                }




                //Select the date
                //StartDate.SendKeys(Keys.Backspace);
                Thread.Sleep(1000);
                //StartDate.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Start Date"));
                //StartDate.SendKeys(Keys.Tab);
                StartDate.SendKeys("25-06-2019");

                //Select the end Date
                EndDate.SendKeys("25-06-2019");

                //Select the Days available


                SelectDays.Click();
                Thread.Sleep(500);

                //Select starttime
                Thread.Sleep(1000);
                StartTime.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Start Time"));

                //Select EndTime
                Thread.Sleep(1000);
                EndTime.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "End Time"));

                //Select Skill Trade
                Credit.Click();
                Thread.Sleep(500);
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Skill-exchange")
                {

                    Skillstrade.Click();
                    Skillstrade.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade"));
                    Skillstrade.SendKeys(Keys.Enter);

                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Credit")
                {

                    CreditAmount.Click();
                    CreditAmount.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit Amount"));
                    CreditAmount.SendKeys(Keys.Enter);

                    //Enter credit amount
                    // CreditAmount.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit Amount"));

                    //Select the stats
                    // StatusActive.Click();
                    //Thread.Sleep(500);
                    if (GlobalDefinitions.ExcelLib.ReadData(2, "Status") == "Active")
                    {
                        Active.Click();
                    }
                    else if (GlobalDefinitions.ExcelLib.ReadData(2, "Status") == "Hidden")
                    {
                        Hidden.Click();
                    }

                    //Save the Share Skill
                    Thread.Sleep(500);
                    Save.Click();
                    Thread.Sleep(500);


                    //Verify if newShared skill is saved
                    Thread.Sleep(3000);
                    string ShareSkillSucess = Global.GlobalDefinitions.driver.FindElement(By.XPath("//th[contains(text(),'Image')]")).Text;

                    if (ShareSkillSucess == "Image")
                    {
                        Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Saved Skill Successful");
                    }
                    else
                        Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Saving Skill Unsuccessful");
                }





            }
            #endregion
        }
    }
}

#endregion

    

