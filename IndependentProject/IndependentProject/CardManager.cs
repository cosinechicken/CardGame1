using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace IndependentProject
{
    public class CardManager
    {
        public static ObservableCollection<Card> GetCards(int PairNumber)
        {
            var cards = new ObservableCollection<Card>();

            for (int i = 0; i < 2*PairNumber; i++)
            {
                cards.Add(new Card { Id = i, Background = new SolidColorBrush(Windows.UI.Colors.LightBlue), Border = new SolidColorBrush(Windows.UI.Colors.White), Text = "Card" });
            }
            return cards;
        }
    }
}