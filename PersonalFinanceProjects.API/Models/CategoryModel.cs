using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProjects.API.Models
{
    [Table("tbl_m_Category")]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(UserModel))]
        public int UserId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<TransactionModel> Transactions { get; set; }
        public UserModel UserModel { get; set; }
    }
}
