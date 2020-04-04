using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp.Memento
{
    class CareTaker
    {
        public Stack<Memento> History { get; set; }
        public CareTaker()
        {
            History = new Stack<Memento>();
        }
    }
}
