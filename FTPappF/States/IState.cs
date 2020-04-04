using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp
{
    interface IState
    {
        public string name { get; set; }

        public string getName()
        {
            return name;
        }
    }
}
