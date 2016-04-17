using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedTripsLib
{
    public interface ISortCards
    {
        IList<Cards> GetSortedCards(IList<Cards> cards);
    }
}
