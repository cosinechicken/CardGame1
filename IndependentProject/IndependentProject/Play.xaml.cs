using IndependentProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Play : Page
    {
        private List<Card> Cards;

        public Play()
        {
            this.InitializeComponent();
        }
        // This is the number of pairs of cards in total. 
        private int PairNumber;
        // This is the number of cards which the user can choose on each turn. 
        private int ChooseNumber;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PairNumber = ((int[])e.Parameter)[0];
            ChooseNumber = ((int[])e.Parameter)[1];
            Cards = CardManager.GetCards(PairNumber);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content += "1";
        }
    }
}
