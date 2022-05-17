using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication.Models
{
    public class MockPieRepository: IPieRepository
    {
        private readonly ICategoryRepository _CategoryRepository = new MockCategoryRepository();
        public IEnumerable<Pie> AllPies =>
           new List<Pie>
           {
                new Pie {PieId = 1, Name = "Strawberry Pie", Price=15.95m, ShortDescription = "Lorem Opsum1", LongDescription="Longdescription1"},
                new Pie {PieId = 2, Name = "Cheese Cake", Price=18.95m, ShortDescription = "Lorem Opsum2", LongDescription="Longdescription2" },           
               new Pie {PieId = 3, Name = "Rhubarb Pie", Price=15.95m, ShortDescription = "Lorem Opsum3", LongDescription="Longdescription1" },
                new Pie {PieId = 3, Name = "Pumpkin Pie",Price=12.95m, ShortDescription = "Lorem Opsum3", LongDescription="Longdescription3"},
                new Pie { PieId = 4, Name = "Pumpkin PieA", Price = 12.95m, ShortDescription = "Lorem Opsum4", LongDescription = "Longdescription4"}
           };

        public IEnumerable<Pie> PiesOfTheWeek { get; }
        public Pie GetPieById(int pieId)
        {
         return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
