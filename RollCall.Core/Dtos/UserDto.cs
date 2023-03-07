using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos
{
    public class UserDto : UserDtoIn
    {
        public int Id { get; set; }
        public string RoleName { get; internal set; }
    }

    public class UserDtoIn
    {
        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La {0} no puede ser vacia")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El {0} no puede ser vacio")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

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