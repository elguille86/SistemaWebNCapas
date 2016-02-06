﻿using System;
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
            return View();
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

        //private bool Isvalid(Usuario ModeloUsuario)
        //{
        //    bool Isvalid = false;
        //    string pass = ModeloUsuario.pass;
        //    IList<RespuestaUsuario> respuesta = this.UsuarioService.BL_ValidaAcceso(ModeloUsuario);

        //    if (respuesta.Count() > 0)
        //    {
        //        string pass2 = respuesta[0].ResPass.ToString().Trim();
        //        if (pass == pass2)
        //        {
        //            Isvalid = true;
        //        }
        //    }
        //    return Isvalid;
        //}



        public ActionResult NewUser() {

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

    }
}