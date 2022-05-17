using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication.Models
{
    public interface ICategoryRepository
    {
        //esta propiedad devolverá todas las categorías, mientras no trabajemos con una base de datos
        IEnumerable<Category> AllCategories { get; }

    }
}
