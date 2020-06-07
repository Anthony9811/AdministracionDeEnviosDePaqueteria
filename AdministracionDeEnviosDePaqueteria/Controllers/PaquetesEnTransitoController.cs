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
    public class PaquetesEnTransitoController : Controller
    {
        private IAlmacenDePaquetes AlmacenDePaquetes;

        public PaquetesEnTransitoController(IAlmacenDePaquetes repositorioDelConstructor)
        {
            AlmacenDePaquetes = repositorioDelConstructor;
        }

        // GET: PaquetesEnTransito
        public ActionResult Listar()
        {
            List<Paquetes> laListaDePaquetes;
            laListaDePaquetes = AlmacenDePaquetes.PaquetesEnTransito();
            return View(laListaDePaquetes);
        }

        // GET: PaquetesEnTransito/Details/5
        public ActionResult Detalles(int id)
        {
            Paquetes paquetes;
            paquetes = AlmacenDePaquetes.ObtenerPorID(id);
            return View(paquetes);
        }

        
        public ActionResult Entregado(int id)
        {
            AlmacenDePaquetes.EntregarPaquete(id);
            return RedirectToAction(nameof(Listar));
        }

        // GET: PaquetesEnTransito/Edit/5
        public ActionResult Perdido()
        {
            return View();
        }

        // POST: PaquetesEnTransito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Perdido(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlmacenDePaquetes.MarcarComoPerdido(id);
                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}