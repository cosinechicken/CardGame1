using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
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
    /// Code is from the following URL: https://www.youtube.com/watch?v=545NoF7Sab4&t=12s
    /// </summary>
    public sealed partial class Settings : Page, INotifyPropertyChanged
    {
        private int _pairNumber=1;
        public int PairNumber
        {
            get { return _pairNumber; }
            set
            {
                if (_pairNumber != value)
                {
                    _pairNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _chooseNumber=1;
        public int ChooseNumber
        {
            get { return _chooseNumber; }
            set
            {
                if (_chooseNumber != value)
                {
                    _chooseNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public Settings()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool UpdatedSettings = false;

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Play), new int[] { PairNumber, ChooseNumber} );
        }
    }
}
