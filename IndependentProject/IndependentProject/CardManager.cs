using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IndependentProject
{
    public class CardManager
    {
        public static List<Card> GetCards(int PairNumber)
        {
            var cards = new List<Card>();

            for (int i = 0; i < 2*PairNumber; i++)
            {
                cards.Add(new Card {Set = false, SetLast = false });
            }

            return cards;
        }
    }
}
