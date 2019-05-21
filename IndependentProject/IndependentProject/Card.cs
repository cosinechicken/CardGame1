using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IndependentProject
{
    public class Card : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Button Button { get; } = new Button();
        public bool Set { get; set; } = false;
        public bool SetLast { get; set; } = false;

    }
}
