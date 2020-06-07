using AdministracionDeEnviosDePaqueteria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionDeEnviosDePaqueteria.Model
{
    public class PaqueteEnviado
    {
        public int ID;

        [Display(Name = "Empleado Encargado Del Envío")]
        [Required(ErrorMessage = "El campo Empleado Encargado Del Envío es obligatorio")]
        public string NombreEmpleadoEncargadoDeEnvio { get; set; }
    }
}
