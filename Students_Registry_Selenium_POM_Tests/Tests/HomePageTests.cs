using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class HomePageTests: BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That("MVC Example", Is.EqualTo(page.GetPageTitle()));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Students Registry"));
            
        }
        [Test]
        public void Test_CountStudents_Homepage()
        {
            var homePage = new HomePage(driver);

            homePage.Open();

            Assert.GreaterOrEqual(homePage.GetStudentsCount(), 0);
        }
        [Test]
        public void Test_Home_Page_Linkes()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }
        [Test]
        public void Test_HomePage_ViewStudentLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
        [Test]
        public void Test_HomePage_AddStudentLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
