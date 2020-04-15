using FTPappF;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp.MementoFolder
{
    public class Memento
    {
        public User ObjToSave; //что сохранять?

        public Memento(User vmc)
        {
            this.ObjToSave = vmc;
        }
    }
}
