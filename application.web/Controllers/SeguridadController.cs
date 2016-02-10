using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;
using System.Web.Security;
 

namespace application.web.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {        
        private application.BL.IUsuariosService UsuarioService = new application.BL.UsuariosService();
        private application.BL.Configuracion.FuncionGeneral FunGen = new BL.Configuracion.FuncionGeneral();
        
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult login()
        {
            ViewBag.TitlePag = "Login";
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                return View();
            }

            
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login(Usuario Elmodel)
        {
            if (ModelState.IsValid)
            {
                IList<RespuestaUsuario> Mirespuesta = this.FunGen.Isvalida(Elmodel);
                if (Mirespuesta  != null)
                {
                    var auth = FormsAuthentication.GetAuthCookie(Elmodel.usuario, false);
                    //FormsAuthentication.SetAuthCookie()
                    RespuestaUsuario Respue = new RespuestaUsuario();
                    //System.Web.HttpContext.Current.Session["NombreUsuario"] = Mirespuesta[0].ResNombre;
                    Session["NombreUsuario"] = Mirespuesta[0].ResNombre;   
                    this.Response.Cookies.Add(auth);
                    ViewBag.nom = User.Identity.Name;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                   //return new HttpStatusCodeResult(401);
                    ViewBag.msgerror = "Error de Usuario y/o Contraseña";
                    return View();
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

        public ActionResult NewUser() {
            ViewBag.TitlePag = "Nuevo Usuario";
            //List<string> petList = new List<string>();
            //petList.Add("Dog");
            //petList.Add("Cat");
            //petList.Add("Hamster");
            //petList.Add("Parrot");
            //petList.Add("Gold fish");
            //petList.Add("Mountain lion");
            //petList.Add("Elephant");

            //ViewData["Pets"] = new SelectList(petList);
             

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(FormCollection form)
        {
            string textBoxNameValue = Request["txtnombre"];
            form["txtnombre"] = textBoxNameValue;
            return View();
        }

        public ActionResult Changepass()
        {
            ViewBag.TitlePag = "Cambiar Clave";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Changepass( FormCollection form)
        {
            
            if (ModelState.IsValid) {
                ViewBag.TitlePag = "Cambiar Clave";
                string texto = "";
  
                string segpass01 = Request["segpass01"].Trim(); 
                string segPasswordConfirmacion = Request["segPasswordConfirmacion"].Trim();
                if ( (segpass01 == segPasswordConfirmacion) && ( segpass01 != ""  && segPasswordConfirmacion != "" ) )
                {
                    IList<RespuestaGlobal> Mirespuesta = UsuarioService.BL_ChangePwd(User.Identity.Name, segpass01);
                    if (Mirespuesta != null)
                    {
                        texto = Mirespuesta[0].RespText;
                        string cls = Mirespuesta[0].RespClass;
                        string respue = ("<div class='" + cls + "'>" + texto + "</div>");
                        TempData["mensajeserver"] = respue;
                        if (Mirespuesta[0].RespEstado == "true")
                        {
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                        else {
                            ViewBag.msgerror = texto;
                            return View();
                        }
                    }
                    else
                    {
                        //return new HttpStatusCodeResult(401);
                        ViewBag.msgerror = "Error de Usuario y/o Contraseña";
                        return View();
                    }
                }
                else {
                    texto = "Las Claves no coninciden";
                    ViewBag.msgerror = texto;
                    return View(); 
                }
            }
            else
            {
                return HttpNotFound(" No se encuentra Disponible la Aplicacion ...");
            }
       
        }
    }
}