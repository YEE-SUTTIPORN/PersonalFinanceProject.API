using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceProjects.API.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
