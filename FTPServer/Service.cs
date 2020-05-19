using System;
using System.IO;
using System.Text;

// Сервис.

namespace FTPServer
{
    class Service
    {
        private IState State { get; set; }
        public string Send(string command)
        {
            string[] data = command.Split('%');
            string response;
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\Desktop\");
            string[] temp = data[0].Split();
            switch (temp[0].ToUpper())
            {
                case "MKD":
                    if (!data[1].Contains("w"))
                        response = "You have not enough permissions. You can " + data[1];
                    else
                    {
                        di.CreateSubdirectory(temp[1]);//command.Remove(0, 3));
                        response = "Directory created";
                    }
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
                    response = "unknown command";
                    break;
            }

            return response;
        }
    }
}
