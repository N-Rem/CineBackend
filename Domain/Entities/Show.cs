using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("MovieId")]  // Foreign Key
        public int MovieId {  get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string StartTime { get; set; }

        [Column(TypeName = "nvarchar(20)")] 
        public string Date { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Price { get; set; }

        [Column(TypeName = "number(2)")]
        public int DirectorId { get; set; }

        [Column(TypeName = "boolean")]
        public bool IsNational { get; set; }

        public Show() { }

        public Show(string startTime, string date, string price, int movieId, int directorId, bool isNational) 
        { 
            StartTime = startTime;
            Date = date;
            Price = price;
            MovieId = movieId;
            DirectorId = directorId;
            IsNational = isNational;
        }

    }
}
