using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vista.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Index(ML.Usuario usuario)
        {
            if (usuario.Opcion == 1)
            {
                return RedirectToAction("Agregar");
            }
            else
            {
                ML.Result result = BL.Usuario.Add(usuario);
                if (result.Correct)
                {
                    usuario.Usuarios = result.Objects;

                }
                return View(usuario);

            }
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);
            return RedirectToAction("Index", "Usuario");
        }
    }
}