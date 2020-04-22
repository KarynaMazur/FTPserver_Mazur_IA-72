using System;
using System.Collections.Generic;
using System.Text;

namespace FTPServer
{
    class PassiveState : IState
    {
        public string name { get; set; }

        public PassiveState()
        {
            name = "Passive state";
        }

        public string getName()
        {
            return name;
        }
    }
}
