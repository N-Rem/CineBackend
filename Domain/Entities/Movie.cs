using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        //public int IdDirector { get; set; }
        [Required]
        [ForeignKey("DirectorId")]
        public Director DirectorMovie { get; set; } 

        public List<Show> Shows { get; set; }

    }
}
