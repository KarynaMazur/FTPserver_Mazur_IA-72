using FTPapp.Exceptions;
using FTPappF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FTPapp
{
    public class FTPManager
    {
        private User _tempUser;
        private IState State { get; set; }
        public FTPManager(User user)
        {
            _tempUser = user;
        }
        public string ExecuteCommand(string command)
        {
            string response;
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
            string[] temp = command.Split();
            switch (temp[0].ToUpper())
            {
                case "MKD":
                    di.CreateSubdirectory(temp[1]);//command.Remove(0, 3));
                    response = "Directory created";
                    break;
                case "NLIST":
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(di.Name + ":" + '\n');
                    foreach (object s in di.GetFiles())
                    {
                        stringBuilder.Append(s);
                        stringBuilder.Append('\n');
                    }
                    foreach (object s in di.GetDirectories())
                    {
                        stringBuilder.Append(s);
                        stringBuilder.Append('\n');
                    }
                    response = stringBuilder.ToString();
                    break;
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
