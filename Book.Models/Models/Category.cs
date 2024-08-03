using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(1, 1000)]
        public int DisplayOrder { get; set; }
    }
}
