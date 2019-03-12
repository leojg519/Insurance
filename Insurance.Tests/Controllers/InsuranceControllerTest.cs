using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insurance.Controllers;

namespace Insurance.Tests.Controllers
{
    [TestClass]
    public class InsuranceControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            InsuranceController controller = new InsuranceController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Insurance Page", result.ViewBag.Title);
        }
    }
}
