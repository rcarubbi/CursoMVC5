using System;
using System.Collections.Generic;
using AvaliadorGastronomico.Domain;
using AvaliadorGastronomico.WebUI.Controllers;
using AvaliadorGastronomico.WebUI.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;

namespace AvaliadorGastronomico.Tests
{
    // Slide 6
    [TestClass]
    public class HomeControllerIndexTests
    {
        #region Slide 6
        /* [TestMethod]
        public void DadoHomeController_QuandoCarregarIndex_ViewBagDeveTerMensagemPreenchida()
        {
            var controller = new HomeController();
            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result.ViewBag.Message);
        }*/
        #endregion

        #region Slide 66
        [TestMethod]
        public void Passando_Mensagens_Na_ViewBag()
        {
            var controller = new HomeController(new MockContext());
            var result = controller.Index();
            Assert.IsNotNull(result.ViewBag.Message);
        }
        #endregion

    }

    // slide 66
    public class MockContext : IDbContext
    {

        private List<Restaurante> _restaurantes = new List<Restaurante>();
        private List<Critica> _criticas = new List<Critica>();
        private List<Usuario> _usuarios = new List<Usuario>();

        public System.Linq.IQueryable<AvaliadorGastronomico.Domain.Restaurante> Restaurantes
        {
            get { return _restaurantes.AsQueryable(); }
        }

        public System.Linq.IQueryable<AvaliadorGastronomico.Domain.Critica> Criticas
        {
            get { return _criticas.AsQueryable(); }
        }

        public System.Linq.IQueryable<AvaliadorGastronomico.Domain.Usuario> Usuarios
        {
            get { return _usuarios.AsQueryable(); }
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(object entity)
        {
             
        }
    }
}
