using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EVENTS.Models
{
    [Table(" photoalbums", Schema = "EC")]
    public class album
    {
        [Key]
        [Display(Name = " photoalbum Id")]
        public int photoalbumId { get; set; }

        [Required]
        [Display(Name = " photoalbum Title")]
        [Column(TypeName = "varchar(250)")]
        public string photoalbumTitle { get; set; }

        [Display(Name = " Multiphoto albums")]
        //[]
        public byte[] Multiphotoalbums { get; set; }

        public int? EventId { get; set; }
        public Event _Event { get; set; }
    }
}
