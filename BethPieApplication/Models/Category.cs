using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication.Models
{
    // Clase categoria y sus atributos
    public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String Description { get; set; }
        //contendrá una lista de pasteles
        public List<Pie> Pies { get; set; }
    }
}
