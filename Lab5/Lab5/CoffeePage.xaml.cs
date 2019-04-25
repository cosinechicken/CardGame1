using System;
using System.Collections.Generic;
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

namespace Lab5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoffeePage : Page
    {
        string R = "";
        string S = "";
        string C = "";

        public CoffeePage()
        {
            this.InitializeComponent();
        }

        private void DisplayCoffee()
        {
            string str = "";
            if (!R.Equals(""))
            {
                str += R;
                if (!S.Equals(""))
                {
                    str += (" + " + S);
                }
                if (!C.Equals(""))
                {
                    str += (" + " + C);
                }
            }
            CoffeeTextBlock.Text = ("Coffee: " + str);
        }

        private void RoastNone(object sender, RoutedEventArgs e)
        {
            R = "";
            DisplayCoffee();
        }

        private void RoastDark(object sender, RoutedEventArgs e)
        {
            R = "Dark";
            DisplayCoffee();
        }

        private void RoastMedium(object sender, RoutedEventArgs e)
        {
            R = "Medium";
            DisplayCoffee();
        }

        private void SweetenerNone(object sender, RoutedEventArgs e)
        {
            S = "";
            DisplayCoffee();
        }

        private void SweetenerSugar(object sender, RoutedEventArgs e)
        {
            S = "Sugar";
            DisplayCoffee();
        }

        private void CreamNone(object sender, RoutedEventArgs e)
        {
            C = "";
            DisplayCoffee();
        }

        private void Cream2Milk(object sender, RoutedEventArgs e)
        {
            C = "2% Milk";
            DisplayCoffee();
        }

        private void CreamWholeMilk(object sender, RoutedEventArgs e)
        {
            C = "Whole Milk";
            DisplayCoffee();
        }
    }
}
