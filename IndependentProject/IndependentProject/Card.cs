using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace IndependentProject
{ 
    public class Card : INotifyPropertyChanged
    {
        private Brush _border;
        private Brush _background;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public Brush Border { get; set; }
        public Brush Background { get; set; }
        public string Text { get; set; }
    }
}
