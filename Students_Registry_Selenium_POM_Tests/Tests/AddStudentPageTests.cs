using NUnit.Framework;
using Students_Registry_Selenium_POM_Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.Tests
{
    public class AddStudentPageTests : BaseTest
    {
        [Test]
        public void Test_TestAddstudentPage_Content()
        {
            var addStudent = new AddStudentPage(driver);

            addStudent.Open();

            Assert.That(addStudent.GetPageTitle, Is.EqualTo("Add Student"));
            Assert.That(addStudent.GetPageHeadingText, Is.EqualTo("Register New Student"));

            addStudent.StudentsName.Click();

            Assert.IsEmpty(addStudent.StudentsName.Text);
            Assert.IsEmpty(addStudent.StudentsEmail.Text);
            Assert.That(addStudent.ButtonAdd.Text, Is.EqualTo("Add"));  
        }
        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            addStudentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.LinkViewStudentsPage.Click();

            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
        [Test]
        public void Test_AddStudentPage_AddValidStudent()
        {
            var addStudent = new AddStudentPage(driver);

            var nameStudent = "Alex" + DateTime.Now.Ticks;
            var emailStudent = "email" + DateTime.Now.Ticks + "@abv.bg";
            string expectedStudent = nameStudent + " (" + emailStudent + ")";

            addStudent.Open();
            addStudent.AddStudent(nameStudent, emailStudent);

            var viewPage = new ViewStudentsPage(driver);
            var students = viewPage.GetRegisteredStudent();

            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            

            Assert.Contains(expectedStudent, students);
        }
        [Test]
        public void Test_Add_InvalidStudent()
        {
            var studentPage = new AddStudentPage(driver);
            studentPage.Open();

            var nameStudent = " " + DateTime.Now.Ticks;
            var emailStudent = "email" + DateTime.Now.Ticks + "@abv.bg";

            Assert.IsTrue(studentPage.IsOpen());
            Assert.That(studentPage.ErrorMessage, Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }
    }
}
