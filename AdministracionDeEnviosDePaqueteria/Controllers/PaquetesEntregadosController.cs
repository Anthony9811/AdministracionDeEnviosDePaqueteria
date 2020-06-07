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
    public class PaquetesEntregadosController : Controller
    {
        private IAlmacenDePaquetes AlmacenDePaquetes;

        public PaquetesEntregadosController(IAlmacenDePaquetes repositorioDelConstructor)
        {
            AlmacenDePaquetes = repositorioDelConstructor;
        }

        // GET: PaquetesEntregados
        public ActionResult Listar()
        {
            List<Paquetes> laListaDePaquetes;
            laListaDePaquetes = AlmacenDePaquetes.PaquetesEntregados();
            return View(laListaDePaquetes);
        }

        // GET: PaquetesEntregados/Details/5
        public ActionResult Detalles(int id)
        {
            Paquetes paquetes;
            paquetes = AlmacenDePaquetes.ObtenerPorID(id);
            return View(paquetes);
        }
    }
}