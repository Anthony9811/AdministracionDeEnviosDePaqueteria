using AdministracionDeEnviosDePaqueteria.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdministracionDeEnviosDePaqueteria.BL
{
    public interface IAlmacenDePaquetes
    {
        List<Paquetes> PaquetesRecibidos();

        List<Paquetes> PaquetesEnTransito();

        List<Paquetes> PaquetesEntregados();

        List<Paquetes> PaquetesPerdidos();

        public void AgregarPaquete(Paquetes paquete);

        List<Paquetes> ObtenerDetalles(int id);

        public void Actualizar(Paquetes paquete);

        Paquetes ObtenerPorID(int id);

        public void EnviarPaquete(int id);

        public void MarcarComoPerdido(int id);

        public void EntregarPaquete(int id);
    }
}
