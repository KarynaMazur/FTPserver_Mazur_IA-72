using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp.Memento
{
    public class Memento
    {
        public object ObjToSave; //что сохранять?

        public Memento(object vmc)
        {
            this.ObjToSave = vmc;
        }
    }
}
