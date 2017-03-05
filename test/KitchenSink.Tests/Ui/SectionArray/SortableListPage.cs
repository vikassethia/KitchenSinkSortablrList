using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.SectionArray
{
    public class SortableListPage : BasePage
    {
        public SortableListPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Up']")]
        public IWebElement AddUpButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Down']")]
        public IWebElement AddDownButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='htCore']//tbody//tr")]
        public IList<IWebElement> PeopelTableRows { get; set; }

        public void Up()
        {
            ClickOn(AddUpButton);
        }

        public void Down()
        {
            ClickOn(AddDownButton);
        }
    }
}
