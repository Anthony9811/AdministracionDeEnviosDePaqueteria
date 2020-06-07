using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionDeEnviosDePaqueteria.BL;
using AdministracionDeEnviosDePaqueteria.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionDeEnviosDePaqueteria.UI.Controllers
{
    public class PaquetesPerdidosController : Controller
    {
        private IAlmacenDePaquetes AlmacenDePaquetes;

        public PaquetesPerdidosController(IAlmacenDePaquetes repositorioDelConstructor)
        {
            AlmacenDePaquetes = repositorioDelConstructor;
        }

        // GET: PaquetesPerdidos
        public ActionResult Listar()
        {
            List<Paquetes> laListaDePaquetes;
            laListaDePaquetes = AlmacenDePaquetes.PaquetesPerdidos();
            return View(laListaDePaquetes);
        }

        // GET: PaquetesPerdidos/Details/5
        public ActionResult Detalles(int id)
        {
            Paquetes paquetes;
            paquetes = AlmacenDePaquetes.ObtenerPorID(id);
            return View(paquetes);
        }
    }
}