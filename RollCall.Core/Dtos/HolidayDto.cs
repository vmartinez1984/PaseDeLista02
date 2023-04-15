using System.ComponentModel.DataAnnotations;

namespace RollCall.Core.Dtos
{
    public class HolidayDto: HolidayDtoIn
    {
        public int Id { get; set; }
    }

    public class HolidayDtoIn
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public bool IsLaw { get; set; }
    }
}