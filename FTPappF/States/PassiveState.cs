using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp
{
    class PassiveState : IState
    {
        public string name { get; set; }

        public PassiveState()
        {
            name = "Passive state";
        }
    }
}
