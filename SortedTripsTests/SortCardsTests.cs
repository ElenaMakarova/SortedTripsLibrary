using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortedTripsLib;

namespace SortedTripsTests
{
    [TestClass]
    public class SortCardsTests
    {
        [TestMethod]
        public void GetGoodSortedList()
        {
            var cards = new List<Cards>();
            cards.Add(new Cards { From = "Berlin", To = "Keln" });
            cards.Add(new Cards { From = "London", To = "Berlin" });
            cards.Add(new Cards { From = "Keln", To = "Paris" });
            cards.Add(new Cards { From = "Moscow", To = "London" });

            var sortedCards = new List<Cards>();
            sortedCards.Add(new Cards { From = "Moscow", To = "London" });
            sortedCards.Add(new Cards { From = "London", To = "Berlin" });
            sortedCards.Add(new Cards { From = "Berlin", To = "Keln" });
            sortedCards.Add(new Cards { From = "Keln", To = "Paris" });

            var gettingCards = new SortCards().GetSortedCards(cards);

            Assert.IsTrue(sortedCards.Count == gettingCards.Count);
            Assert.IsTrue(IsEqualLists(sortedCards, gettingCards));
        }

        [TestMethod]
        public void GetDoubleLineList()
        {
            var cards = new List<Cards>();
            cards.Add(new Cards { From = "Berlin", To = "Keln" });
            cards.Add(new Cards { From = "London", To = "Berlin" });
            cards.Add(new Cards { From = "Keln", To = "Paris" });
            cards.Add(new Cards { From = "Keln", To = "Keln" });
            cards.Add(new Cards { From = "Moscow", To = "London" });
            
            var gettingCards = new SortCards().GetSortedCards(cards);

            Assert.IsTrue(cards.Count == (gettingCards.Count + 1));
        }

        private static bool IsEqualLists(IList<Cards> cards1, IList<Cards> cards2)
        {
            for (var i = 0; i < cards1.Count; i++)
            {
                if (cards1[i].From != cards2[i].From || cards1[i].To != cards2[i].To)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
