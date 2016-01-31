using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;
using System.Web.Security;

namespace application.web.Controllers
{
 
    public class SeguridadController : Controller
    {
        private application.BL.IUsuariosService UsuarioService = new application.BL.UsuariosService();
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(Usuario Elmodel)
        {
            if (ModelState.IsValid)
            {
                if (Isvalid(Elmodel))//Verificar que el email y clave exista utilizando el método privado
                {
                    //crea variable de usuario con el correo del usuario
                  
                    var auth = FormsAuthentication.GetAuthCookie(Elmodel.usuario, false);
                    //FormsAuthentication.SetAuthCookie()
                    this.Response.Cookies.Add(auth);
                    ViewBag.nom = User.Identity.Name;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return new HttpStatusCodeResult(401);
                }
            }
            else
            {
                return HttpNotFound(" No se encuentra Disponible la Aplicacion");
            }
        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }

        private bool Isvalid(Usuario ModeloUsuario)
        {
            bool Isvalid = false;
            string pass = ModeloUsuario.pass;
            IList<RespuestaUsuario> respuesta = this.UsuarioService.ValidaAcceso(ModeloUsuario);
            
            if (respuesta.Count() > 0)
            {
                string pass2 = respuesta[0].ResPass.ToString().Trim();
                if (pass == pass2)
                {
                    Isvalid = true;
                }
            }
            return Isvalid;
        }
    }
}