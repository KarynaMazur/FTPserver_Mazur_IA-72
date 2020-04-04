using FTPapp.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp
{
    public class FTPManager
    {
        private IState State { get; set; }
        public FTPManager()
        {

        }
        public string ExecuteCommand(string command)
        {
            string response;
            switch (command)
            {
                case "PASV":
                    State = new PassiveState();
                    response = "State Changed";
                    break;
                case "PORT":
                    State = new ActiveState();
                    response = "State Changed";
                    break;
                case "STATE":
                    response = State.getName();
                    break;
                default:
                    throw new UnknownCommandException("Command doesn`t exist");
            }
            return response;

        }
    }
}
