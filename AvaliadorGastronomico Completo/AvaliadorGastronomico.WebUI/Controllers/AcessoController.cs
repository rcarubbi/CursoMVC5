using AvaliadorGastronomico.WebUI.Infrastructure;
using AvaliadorGastronomico.WebUI.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace AvaliadorGastronomico.WebUI.Controllers
{

    [Authorize]
    [InitializeSimpleMembership]
    [RequireHttps]
    public class AcessoController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.NomeConta, model.Senha, persistCookie: model.LembrarMe))
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Cadastrar()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.NomeConta, model.Senha);
                    WebSecurity.Login(model.NomeConta, model.Senha);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }


        //
        // GET: /Account/Manage

        public ActionResult AlterarSenha(bool sucesso = false)
        {
            if (sucesso)
            {
                ViewBag.StatusMessage = "Sua senha foi alterada com sucesso.";
            }
            ViewBag.ReturnUrl = Url.Action("AlterarSenha");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(AlteracaoSenhaViewModel model)
        {
            ViewBag.ReturnUrl = Url.Action("AlterarSenha");
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.SenhaAtual, model.NovaSenha);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("AlterarSenha", new { sucesso = true });
                }
                else
                {
                    ModelState.AddModelError("", "A senha atual ou a nova senha está inválida.");
                }
            }

            return View(model);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Já existe um usuário cadastrado com este nome. Tente outro nome de usuário";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Já existe um usuário cadastrado com este e-mail. Tente outro e-mail.";

                case MembershipCreateStatus.InvalidPassword:
                    return "Senha inválida. Tente novamente.";

                case MembershipCreateStatus.InvalidEmail:
                    return "E-mail inválido. Verifique e tente novamente.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "Resposta da pergunta de segurança inválida. Verifique e tente novamente.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "Pergunta de segurança inválida. Verifique e tente novamente.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Nome de usuário inválido. Verifique e tente novamente.";

                case MembershipCreateStatus.ProviderError:
                    return "O provedor de autenticação retornou um erro. Tente novamente e se o problema persistir contate o administrador do sistema";

                case MembershipCreateStatus.UserRejected:
                    return "A solicitação de criação de usuário foi cancelada. Por favor verifique os dados e tente novamente. Se o problema persistir contate o administrador do sistema.";

                default:
                    return "Ocorreu um erro desconhecido. Por favor verifique os dados e tente novamente. Se o problema persistir contate o administrador do sistema.";
            }
        }
        #endregion
    }
}