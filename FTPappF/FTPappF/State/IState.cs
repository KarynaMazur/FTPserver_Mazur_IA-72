using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp
{
    interface IState
    {
        string name { get; set; }

        string getName();
    }
}
