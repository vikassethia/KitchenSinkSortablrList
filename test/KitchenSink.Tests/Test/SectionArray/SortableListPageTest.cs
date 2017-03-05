using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class SortableListPageTest : BaseTest
    {
        private SortableListPage _sortableListPage;
        private MainPage _mainPage;

        public SortableListPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _sortableListPage = _mainPage.GoToSortableListPage();
        }

        [Test]
        public void SortableListPage_Up()
        {

            var orderBefore = _sortableListPage.PeopelTableRows[_sortableListPage.PeopelTableRows.Count-1].FindElement(By.Id("sortOrder")).Text;
            _sortableListPage.Up();
            var orderAfter = _sortableListPage.PeopelTableRows[_sortableListPage.PeopelTableRows.Count - 1].FindElement(By.Id("sortOrder")).Text;
            Assert.Less(orderAfter, orderBefore);
        }

        [Test]
        public void SortableListPage_Down()
        {

            var orderBefore = _sortableListPage.PeopelTableRows[0].FindElement(By.Id("sortOrder")).Text;
            _sortableListPage.Up();
            var orderAfter = _sortableListPage.PeopelTableRows[0].FindElement(By.Id("sortOrder")).Text;
            Assert.Greater(orderAfter, orderBefore);
        }
    }
}
