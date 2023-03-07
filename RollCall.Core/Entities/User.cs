using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Entities
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        public virtual Person Person { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}