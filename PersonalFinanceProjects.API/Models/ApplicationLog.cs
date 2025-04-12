using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProjects.API.Models
{
    [Table("tbl_t_application_log")]
    public class ApplicationLog
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string OperationName { get; set; } = string.Empty;
        [StringLength(512)]
        public string RequestBody { get; set; } = string.Empty;
        public string ResponseBody { get; set; } = string.Empty;
        public DateTime DATETIME { get; set; } = DateTime.Now;
        public string ExceptionMessage { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
