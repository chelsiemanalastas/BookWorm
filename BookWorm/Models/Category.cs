using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required]

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
