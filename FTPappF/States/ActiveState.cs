using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp
{
    class ActiveState : IState
    {
        public string name { get; set; }

        public ActiveState()
        {
            name = "Active state";
        }
    }
}
