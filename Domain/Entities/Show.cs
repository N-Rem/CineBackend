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
        public Movie Movie { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string StartTime { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Date { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Price { get; set; }


        public Show() { }

        public Show(string startTime, string date, string price) 
        { 
            StartTime = startTime;
            Date = date;
            Price = price;
        }

    }
}
