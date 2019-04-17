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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
            InnerFrame.Navigate(typeof(Financial));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinancialListBoxItem.IsSelected)
            {
                InnerFrame.Navigate(typeof(Financial));
                BackButton.Visibility = Visibility.Collapsed;
                Title.Text = "Financial";
            }
            else if (FoodListBoxItem.IsSelected)
            {
                InnerFrame.Navigate(typeof(Food));
                BackButton.Visibility = Visibility.Visible;
                Title.Text = "Food";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (InnerFrame.CanGoBack)
            {
                InnerFrame.GoBack();
                BackButton.Visibility = Visibility.Collapsed;
                Title.Text = "Financial";
            }
        }
    }
}
