using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IndependentProject
{ 
    public class Card
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public bool Set { get; set; }
        public bool SetLast { get; set; }

    }
}
