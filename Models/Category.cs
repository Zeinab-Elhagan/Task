using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EVENTS.Models
{
    [Table("Catogories", Schema = "EC")]
    public class Category
    {
        [Key]
        [Display(Name = " EventCatogory Id")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Event Category Name")]
        [Column(TypeName = "varchar(250)")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Category Description")]
        [Column(TypeName = "varchar(500)")]
        public string CategoryDescription { get; set; }

        public ICollection<Event> _Events { get; set; }

        //public IEnumerable<Event> _events { get; set; }
        //public IEnumerable<Category>? Categories { get; set; } = new List<Category>();
    }
}
