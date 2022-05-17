using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication.Models
{
    //Interface con dos propiedades y un método
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies {get;}
        IEnumerable<Pie> PiesOfTheWeek { get; }
        //metodo que al pasar el Id devolverá un pastel
        Pie GetPieById(int PieId);
    }
}
