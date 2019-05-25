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
        public Brush Border
        {
            get { return _border; }
            set
            {
                _border = value;
                RaisePropertyChanged("Border");
            }
        }
        public Brush Background
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged("Background");
            }
        }
        public string Text { get; set; }
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
