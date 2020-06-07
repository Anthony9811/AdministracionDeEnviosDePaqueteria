using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdministracionDeEnviosDePaqueteria.Model
{
    public class Paquetes
    {
        public int Id { get; set; }

        [Display(Name = "Persona Que Envía")]
        [Required(ErrorMessage = "El campo Persona Que Envía es obligatorio")]
        public string NombrePersonaEnvia { get; set; }

        [Display(Name = "Persona Que Recibe")]
        [Required(ErrorMessage = "El campo Persona Que Recibe es obligatorio")]
        public string NombrePersonaRecibe { get; set; }

        [Display(Name = "Fecha De Recepción")]
        public DateTime FechaDeRecepcion { get; set; }
        public Estado Estado { get; set; }

        [Display(Name = "Dirección De Envío")]
        [Required(ErrorMessage = "El campo Dirección De Envío es obligatorio")]
        public string DirrecionEnvio { get; set; }

        [Display(Name = "Encargado Del Envío")]
        public string? NombreEmpleadoEncargadoDeEnvio { get; set; }

        [Display(Name = "Fecha De Envío")]
        public DateTime? FechaEnvio { get; set; }

        [Display(Name = "Motivo De Pérdida")]
        public string? MotivoPerdida { get; set; }

        [Display(Name = "Fecha De Entrega")]
        public DateTime? FechaDeEntrega { get; set; }
    }
}
