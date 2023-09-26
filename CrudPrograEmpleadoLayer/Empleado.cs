using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudPrograEmpleadoLayer
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio.")]
        [DataType(DataType.Date, ErrorMessage = "La Fecha de nacimiento no es válida.")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage ="El Email que ha ingresado no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Departamento es obligatorio.")]
        public Departamento Departamento { get; set; }

        [Required(ErrorMessage = "El campo Puesto es obligatorio.")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "El campo Sueldo es obligatorio.")]
        public decimal Sueldo { get; set; }

        [Required(ErrorMessage = "El campo Fecha de contrato es obligatorio.")]
        [DataType(DataType.Date, ErrorMessage = "La Fecha de contrato no es válida.")]
        public string FechaContrato { get; set; }

        [Required(ErrorMessage = "El campo Activo es obligatorio.")]
        public bool Activo { get; set; }
    }
}
