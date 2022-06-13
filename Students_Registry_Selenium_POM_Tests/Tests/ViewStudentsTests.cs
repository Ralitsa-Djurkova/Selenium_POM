using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class ViewStudentsTests : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var viewStudents = new ViewStudentsPage(driver);
            var students = viewStudents.GetRegisteredStudent();
            viewStudents.Open();

            Assert.That(viewStudents.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(viewStudents.GetPageHeadingText, Is.EqualTo("Registered Students"));

        }
        [Test]
        public void Test_GetStudentsCount()
        {
            var studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();

            var students = studentsPage.GetRegisteredStudent();


            foreach (string student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }
        }
        [Test]
        public void Test_ViewStudetnts_HomePageLink()
        {
            var viewStudents = new ViewStudentsPage(driver);

            viewStudents.Open();
            viewStudents.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }
        [Test]
        public void Test_ViewStudents_AddStudentPage()
        {
            var viewStudents = new ViewStudentsPage(driver);

            viewStudents.Open();
            viewStudents.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());   
        }
    }
}
