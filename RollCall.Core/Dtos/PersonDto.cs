using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos
{
    public class PersonDto: PersonDtoIn
    {
        public int Id { get; set; }

        [Display(Name = "Registro")]
        public DateTime DateRegistration { get; set; }

        //public bool IsActive { get; set; }
        
    }

    public class PersonDtoIn : AddressDtoIn
    {
        public int AddressId { get; set; } 

        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los {0} no puede ser vacios")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La {0} no puede ser vacio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [Display(Name = "Genero")]
        public string Genere { get; set; }
    }
}
