using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos
{
    public  class AddressDtoIn
    {
        [Required(ErrorMessage = "La calle y numero no puede ser vacio")]
        [StringLength(255)]
        [Display(Name = "Calle y número")]
        public string StreetAndNumber { get; set; }

        [Required(ErrorMessage = "La colonia no puede ser vacia")]
        [StringLength(255)]
        [Display(Name = "Colonia")]
        public string Settlement { get; set; }

        [Required(ErrorMessage = "La {0} no puede ser vacio")]
        [StringLength(255)]
        [Display(Name = "Alcaldia")]
        public string Town { get; set; }

        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [StringLength(255)]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [StringLength(255)]
        [Display(Name = "Código postal")]
        public string ZipCode { get; set; }
    }
}
