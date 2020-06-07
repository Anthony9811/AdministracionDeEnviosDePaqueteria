using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdministracionDeEnviosDePaqueteria.Model
{
    public class PaquetePerdido
    {
        public int ID { get; set; }

        [Display(Name = "Motivo De Pérdida")]
        [Required(ErrorMessage = "El campo Motivo De Pérdida es obligatorio")]
        public string MotivoPerdida { get; set; }
    }
}
