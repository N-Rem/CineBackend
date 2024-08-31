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
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        [ForeignKey("DirectorId")]
        public int DirectorId { get; set; }

        public bool IsNational { get; set; }

        public List<Show> Shows { get; set; }

        

    }
}
