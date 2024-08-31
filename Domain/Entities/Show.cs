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
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public Show() { }

        public Show(DateTime date, decimal price, Movie movie) 
        { 
            Date = date;
            Price = price;
            Movie = movie;
        }

    }
}
