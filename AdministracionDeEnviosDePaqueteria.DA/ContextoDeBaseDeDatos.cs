using AdministracionDeEnviosDePaqueteria.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdministracionDeEnviosDePaqueteria.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {
        public DbSet<Paquetes> Paquetes { get; set; }

        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        {

        }
    }
}
