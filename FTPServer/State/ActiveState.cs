using System;
using System.Collections.Generic;
using System.Text;

namespace FTPServer
{
    class ActiveState : IState
    {
        public string name { get; set; }

        public ActiveState()
        {
            name = "Active state";
        }
        
        public string getName()
        {
            return name;
        }
    }
}
