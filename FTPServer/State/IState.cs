using System;
using System.Collections.Generic;
using System.Text;

namespace FTPServer
{
    interface IState
    {
        string name { get; set; }

        string getName();
    }
}
