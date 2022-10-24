using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EVENTS.Models
{    

    public class Event
    {
        [Key]
        [Display(Name = "ID")]
        public int? EventId { get; set; }

        [Required]
        [Display(Name = " Title")] 
        [Column(TypeName = "varchar(250)")]
        public string EventTitle { get; set; }


        [Display(Name = " Content")]
        [Column(TypeName = "varchar(1000)")]
        public string EventContent { get; set; }


        [Display(Name = " Address")]
        [Column(TypeName = "varchar(250)")]
        public string EventAddress { get; set; }


        [Display(Name = " StartDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime EventStartDate { get; set; }

        //[Required]
        [Display(Name = " EndDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime EventEndDate { get; set; }

        [Display(Name = "Cover photo")]
        [Column(TypeName = "varchar(250)")]
        public string EventCoverphoto { get; set; }

        [Display(Name = "Source")]
        [Column(TypeName = "varchar(250)")]
        public string source { get; set; }

 
        [Display(Name = "photo album")]
        public string albums { get; set; }

        [Display(Name = "Category")]
        [Column(TypeName = "varchar(250)")]
        public string Category { get; set; }

        //navigation properties
        public album Photoalbum { get; set; }

 
        public int SourceId { get; set; }
       public Source Sources { get; set; }

        public ICollection<Category> Categories { get; set; } //= new List<Catogory>();   






    }
}
