using System;
using AvaliadorGastronomico.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliadorGastronomico.WebUI.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        //[TestMethod]
        //public void DadoHomeController_QuandoCarregarIndex_ViewBagDeveTerMensagemPreenchida()
        //{
        //    var controller = new HomeController();
        //    var result = controller.Index();
        //    Assert.IsNotNull(result.ViewBag.Message);
        //}

        [TestMethod]
        public void DadoHomeController_QuandoCarregarIndex_ViewBagDeveTerMensagemPreenchida()
        {
            var controller = new HomeController(new MockContext());
            var result = controller.Index();
            Assert.IsNotNull(result.ViewBag.Message);
        }

    }
}
