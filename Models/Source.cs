using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EVENTS.Models
{
    [Table(" Sources", Schema = "EC")]
    public class Source
    {

        [Key]
        [Display(Name = " Event Source Id")]
        public int SourceId { get; set; }

        [Required]
        [Display(Name = "Event Source Title")]
        [Column(TypeName = "varchar(250)")]
        public string SourceTitle { get; set; }

        [Required]
        [Display(Name = "Event Source Description")]
        [Column(TypeName = "varchar(500)")]
        public string SourceDescription { get; set; }

        public IEnumerable<Source>? sources { get; set; } = new List<Source>();
       public List<Event> Events { get; set; }
    }
}
