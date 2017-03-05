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

        [FindsBy(How = How.XPath, Using = ".fa-thumbs-up[last()]")]
        public IWebElement UpButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".fa-thumbs-down[1]")]
        public IWebElement DownButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='table-striped']//tbody//tr")]
        public IList<IWebElement> PeopelTableRows { get; set; }

        public void Up()
        {
            ClickOn(UpButton);
        }

        public void Down()
        {
            ClickOn(DownButton);
        }
    }
}
