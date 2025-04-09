using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApp.Models
{

    [Table("Item", Schema = "db")]  
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ItemId")]
        public int Id { get; set; }
        
        [Required]
        [Column("ItemName")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "please enter the price")] // Not Null
        [Range(10, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
