using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedTripsLib
{
    public class SortCards : ISortCards
    {
        // sorting of the list; algorithm complexity - O(n^2) + O(n^2)
        public IList<Cards> GetSortedCards(IList<Cards> cards)
        {
            // this is a sorted list
            var sortedCards = new List<Cards>();

            // the first line in the cards
            var first = cards.Where(x => !cards.Where(a => a.To == x.From).Any()).ToList();

            // find the first "To" city
            var townTo = first.FirstOrDefault().To;
            sortedCards.Add(new Cards { From = first.FirstOrDefault().From, To = townTo });

            // search for the "To" city in order set an order
            for (var i = 0; i < cards.Count; i++)
            {
                for (var j = 0; j < cards.Count; j++)
                {
                    if (cards[j].From == townTo)
                    {
                        sortedCards.Add(cards[j]);
                        townTo = cards[j].To;
                        break;
                    }
                }
            }
            return sortedCards;
        }
    }
}
