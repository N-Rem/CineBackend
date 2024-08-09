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

        public string Title { get; set; }
        [Required]
        [ForeignKey("IdDirector")]
        public int IdDirector { get; set; }

        public Director DirectorMovie { get; set; } 

        public List<Show> SHows { get; set; }


        public Movie() { }
    }
}
