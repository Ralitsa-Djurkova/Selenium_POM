using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";
        public IWebElement StudentsName => this.driver.FindElement(By.Id("name"));
        public IWebElement StudentsEmail => this.driver.FindElement(By.Id("email"));
        public IWebElement ButtonAdd => this.driver.FindElement(By.CssSelector("body > form > button"));
        public IWebElement ErrorMessageProperty => driver.FindElement(By.CssSelector("body > div"));

        public void AddStudent(string name, string email)
        {
            this.StudentsName.SendKeys(name);
            this.StudentsEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }

        public string ErrorMessage()
        {
            this.StudentsName.Clear();
            this.StudentsEmail.Clear();
            this.ButtonAdd.Click();
            return ErrorMessageProperty.Text;
        }
    }
}
