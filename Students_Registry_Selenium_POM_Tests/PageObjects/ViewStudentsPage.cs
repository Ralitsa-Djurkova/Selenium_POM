using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace Students_Registry_Selenium_POM_Tests.PageObjects
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public ReadOnlyCollection<IWebElement> StudentsList =>
            this.driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudent()
        {
            string[] elmentStudent = this.StudentsList.Select(x => x.Text).ToArray();
            return elmentStudent;
        }
    }
}
