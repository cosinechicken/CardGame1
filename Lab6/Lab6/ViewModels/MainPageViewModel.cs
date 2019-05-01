using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;

namespace Lab6.ViewModels
{
    [ImplementPropertyChanged]
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string LocationName { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<string> AutoCompleteNames { get; set; }
    }
}
