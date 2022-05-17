using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        //datos simulados de las categorias de pasteles: frutas, de queso y de temporada
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Fruit Pies", Description = "Allfruit pies" },
                new Category { CategoryId = 2, CategoryName = "Cheese Cakes", Description = "Cheesy All The way" },
                new Category { CategoryId = 3, CategoryName = "Saesonal Pies", Description = "Get in the mood a seasonal pies" }

            };
    }
}
