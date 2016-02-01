using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using AvaliadorGastronomico.WebUI.Controllers;
using AvaliadorGastronomico.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliadorGastronomico.Tests
{
    [TestClass]
    public class InfoControllerIndexTests
    {
        [TestMethod]
        public async Task Index_Produz_Model()
        {
            var controller = new InfoController();
            var result = (ViewResult)await controller.Index(new CancellationToken());
            var model = result.Model;
            Assert.IsNotNull(model as InfoViewModel);
        }
    }
}
