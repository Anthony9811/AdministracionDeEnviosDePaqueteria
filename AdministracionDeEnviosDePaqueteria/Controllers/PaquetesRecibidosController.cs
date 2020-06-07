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
    public class PaquetesRecibidosController : Controller
    {
        private IAlmacenDePaquetes AlmacenDePaquetes;

        public PaquetesRecibidosController(IAlmacenDePaquetes repositorioDelConstructor)
        {
            AlmacenDePaquetes = repositorioDelConstructor;
        }

        // GET: PaquetesRecibidos
        public ActionResult Listar()
        {
            List<Paquetes> laListaDePaquetes;
            laListaDePaquetes = AlmacenDePaquetes.PaquetesRecibidos();
            return View(laListaDePaquetes);
        }

        // GET: PaquetesRecibidos/Details/5
        public ActionResult Detalles(int id)
        {
            Paquetes paquetes;
            paquetes = AlmacenDePaquetes.ObtenerPorID(id);
            return View(paquetes);
        }

        // GET: PaquetesRecibidos/Create
        public ActionResult Agregar()
        {

            return View();
        }

        // POST: PaquetesRecibidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Paquetes paquete)
        {
                if (ModelState.IsValid)
                {
                    AlmacenDePaquetes.AgregarPaquete(paquete);
                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }
        }

        // GET: PaquetesRecibidos/Edit/5
        public ActionResult Editar(int id)
        {

            return View();
        }

        // POST: PaquetesRecibidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Paquetes paquete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlmacenDePaquetes.Actualizar(paquete);
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
        
        // GET: PaquetesRecibidos/Delete/5
        public ActionResult Enviar()
        {
                return View();
        }

        // POST: PaquetesRecibidos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enviar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlmacenDePaquetes.EnviarPaquete(id);
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
        

        // GET: PaquetesRecibidos/Delete/5
        public ActionResult Perdido()
        {
            return View();
        }

        // POST: PaquetesRecibidos/Delete/5
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