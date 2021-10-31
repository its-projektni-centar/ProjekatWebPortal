using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Projekat.Models
{
    [Table("Forum_Message")]
    public class Forum_Message
    {
        [Key]
        public int Id_message { get; set; }

        [Required(ErrorMessage ="polje je obavezno")]
        public string messagePost { get; set; }

        public DateTime messageDate { get; set; }

        public string odobrenje { get; set; }

        public Forum_Post Forum_Post { get; set; }

        [Required]
        [ForeignKey("Forum_Post")]
        public int Id_post { get; set; }
    }
}