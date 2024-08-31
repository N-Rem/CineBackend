using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class CeateShowDto
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public bool IsNational { get; set; }
    }
}
