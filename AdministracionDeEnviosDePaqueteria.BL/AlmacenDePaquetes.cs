using AdministracionDeEnviosDePaqueteria.DA;
using AdministracionDeEnviosDePaqueteria.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdministracionDeEnviosDePaqueteria.BL
{
    public class AlmacenDePaquetes : IAlmacenDePaquetes
    {
        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;

        public AlmacenDePaquetes(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;
        }

        public void Actualizar(Paquetes paquete)
        {
            Paquetes paqueteAEditar;
            paqueteAEditar = ObtenerPorID(paquete.Id);
            paqueteAEditar.NombrePersonaEnvia = paquete.NombrePersonaEnvia;
            paqueteAEditar.NombrePersonaRecibe = paquete.NombrePersonaRecibe;
            paqueteAEditar.DirrecionEnvio = paquete.DirrecionEnvio;
            ElContextoDeBaseDeDatos.Paquetes.Update(paqueteAEditar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarPaquete(Paquetes paquete)
        {
            DateTime horaYFechaActual = DateTime.Now;
            paquete.Estado = Estado.Registrado;
            paquete.FechaDeRecepcion = horaYFechaActual;
            ElContextoDeBaseDeDatos.Paquetes.Add(paquete);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarPaqueteARegistroDeEnvios(Paquetes paquete)
        {
            PaqueteEnviado paqueteARegistro = new PaqueteEnviado();
            paqueteARegistro.NombreEmpleadoEncargadoDeEnvio = paquete.NombreEmpleadoEncargadoDeEnvio;
        }

        public void EnviarPaquete(int id)
        {
            Paquetes paqueteParaEnviar;
            paqueteParaEnviar = ObtenerPorID(id);
            AgregarPaqueteARegistroDeEnvios(paqueteParaEnviar);

            paqueteParaEnviar.FechaEnvio = DateTime.Now;
            paqueteParaEnviar.Estado = Estado.EnTransito;

            ElContextoDeBaseDeDatos.Paquetes.Update(paqueteParaEnviar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarPaqueteARegistroDePerdidos(Paquetes paquete)
        {
            PaquetePerdido paqueteARegistro = new PaquetePerdido();
            paqueteARegistro.ID = paquete.Id;
            paqueteARegistro.MotivoPerdida = paquete.MotivoPerdida;
        }

        public void MarcarComoPerdido(int id)
        {
            Paquetes paquetePerdido;
            paquetePerdido = ObtenerPorID(id);
            AgregarPaqueteARegistroDePerdidos(paquetePerdido);
            paquetePerdido.Estado = Estado.Perdido;

            ElContextoDeBaseDeDatos.Paquetes.Update(paquetePerdido);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public List<Paquetes> ObtenerDetalles(int id)
        {
            var Resultado = from c in ElContextoDeBaseDeDatos.Paquetes
                            where c.Id == id
                            select c;
            return Resultado.ToList();
        }

        public Paquetes ObtenerPorID(int id)
        {
            Paquetes paquete;
            paquete = ElContextoDeBaseDeDatos.Paquetes.Find(id);
            return paquete;
        }

        public List<Paquetes> PaquetesEnTransito()
        {
            var Resultado = from c in ElContextoDeBaseDeDatos.Paquetes
                            where c.Estado == Estado.EnTransito
                            select c;

            return Resultado.ToList();
        }

        public List<Paquetes> PaquetesRecibidos()
        {
            var Resultado = from c in ElContextoDeBaseDeDatos.Paquetes
                            where c.Estado == Estado.Registrado
                            select c;

            return Resultado.ToList();
        }

        public void EntregarPaquete(int id)
        {
            Paquetes paqueteParaEntregar;
            paqueteParaEntregar = ObtenerPorID(id);
            paqueteParaEntregar.Estado = Estado.Entregado;
            paqueteParaEntregar.FechaDeEntrega = DateTime.Now;

            ElContextoDeBaseDeDatos.Paquetes.Update(paqueteParaEntregar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public List<Paquetes> PaquetesEntregados()
        {
            var Resultado = from c in ElContextoDeBaseDeDatos.Paquetes
                            where c.Estado == Estado.Entregado
                            select c;

            return Resultado.ToList();
        }

        public List<Paquetes> PaquetesPerdidos()
        {
            var Resultado = from c in ElContextoDeBaseDeDatos.Paquetes
                            where c.Estado == Estado.Perdido
                            select c;

            return Resultado.ToList();
        }
    }
}
