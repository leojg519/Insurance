using System.Collections.Generic;
using System.Linq;
using Insurance.ApiControllers;
using Insurance.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurance.Tests.ApiControllers
{
    [TestClass]
    public class ClientControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Disponer
            ApiClientController controller = new ApiClientController();

            // Actuar
            IEnumerable<Client> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Disponer
            ApiClientController controller = new ApiClientController();

            // Actuar
            Client result = controller.Get(1);

            // Declarar
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Disponer
            ApiClientController controller = new ApiClientController();

            // Actuar
            controller.Post(new Client());

            // Declarar
        }

        [TestMethod]
        public void Put()
        {
            // Disponer
            ApiClientController controller = new ApiClientController();

            // Actuar
            controller.Put(5, new Client());

            // Declarar
        }

        [TestMethod]
        public void Delete()
        {
            // Disponer
            ApiClientController controller = new ApiClientController();

            // Actuar
            controller.Delete(5);

            // Declarar
        }
    }
}
