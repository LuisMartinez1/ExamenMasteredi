using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMasteredi.Ejercicio2.Domain.Entities
{
    public class EmisorEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])([A-Z]|[0-9]){2}([A]|[0-9]){1})?$", ErrorMessage = "El campo {0} no cumple con los requisitos")]
        public string Rfc { get; set; }
        [Required]
        public DateTime FechaInicioOperacion { get; set; }
        [Required]
        public decimal Capital { get; set; }

    }
}
