using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Controllers;
using WebAPI.Models;

namespace UnitTestAgreda
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange

            agredasController agredasController = new agredasController();


            //Act

            var listaAgreda = agredasController.Getagredas();

            //Assert

            Assert.IsNotNull(listaAgreda);

        }
        [TestMethod]
        public void TestMethodPost()
        {
            //Arrange

            agredasController controlador = new agredasController();
            agreda modelo = new agreda()
            {
                agredaID = 2,
                Friendofagreda = "Ajejandra Molina",
                Place_lista = 0,
                email = "ale@gmail.com",
                Birthday = DateTime.Today

            };

            //Act

            var listaAgreda = controlador.Postagreda(modelo);
            var resultadoCreado = listaAgreda as CreatedAtRouteNegotiatedContentResult<agreda>;

            //Assert

            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual("DefaultApi", resultadoCreado.RouteName);
            Assert.AreEqual(modelo.agredaID, resultadoCreado.Content.agredaID);

        }

        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange

            agredasController agredasController = new agredasController();
            agreda modelo = new agreda()
            {
                agredaID = 2,
                Friendofagreda = "Ajejandra Molina",
                Place_lista = 0,
                email = "ale@gmail.com",
                Birthday = DateTime.Today

            };

            //Act

            var listaAgreda = agredasController.Deleteagreda(modelo);
            var resultadoEliminado = agredasController.Deleteagreda(modelo.agredaID);

            //Assert

            Assert.IsInstanceOfType(resultadoEliminado, typeof(OkNegotiatedContentResult<agreda>));

        }
        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange

            agredasController agredasController = new agredasController();
            agreda modelo = new agreda()
            {
                agredaID = 2,
                Friendofagreda = "Ajejandra Molina",
                Place_lista = 0,
                email = "ale@gmail.com",
                Birthday = DateTime.Today

            };

            //Act

            var listaAgreda = agredasController.Putagreda(modelo.agredaID, modelo);

            var resultadoCreado = listaAgreda as OkNegotiatedContentResult<agreda>;


            //Assert

            Assert.IsNull(resultadoCreado);

        }
    }
}
