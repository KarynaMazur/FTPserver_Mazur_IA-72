using FTPappF;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp.MementoFolder
{
    class CareTaker
    {
        private Stack<Memento> History { get; set; }
        public CareTaker()
        {
            History = new Stack<Memento>();
        }

        public void SaveMemento(Memento memento)
        {
            History.Push(memento);
        }

        public User GetMemento()
        {
            return History.Pop().ObjToSave;
        }
    }
}
