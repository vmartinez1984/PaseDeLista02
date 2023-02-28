using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RollCall.Core.Dtos
{
    public class PagerDtoIn
    {
        public string Search { get; set; }

        [DefaultValue(1)]
        public int PageCurrent { get; set; } = 1;

        [Range(10, 50)]
        [DefaultValue(10)]
        public int RecordsPerPage { get; set; } = 10;


        [DefaultValue("Id")]
        public string SortColumn { get; set; } = "Id";

        [DefaultValue("DESC")]
        public string SortColumnDir { get; set; } = "DESC";
    }

    public class PagerDto : PagerDtoIn
    {
        public int TotalRecords { get; set; }

        public int CountPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalRecordsFiltered / RecordsPerPage);
            }
        }

        public int TotalRecordsFiltered { get; set; }

        public object List { get; set; }
    }
}
