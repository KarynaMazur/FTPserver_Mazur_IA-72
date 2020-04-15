using FTPapp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace WebServer
{
    /// <summary>
    /// Summary description for MyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        private IState State { get; set; }

        public void Init()
        {
        }
 
        [WebMethod]
        public string Send(string command, string rights)
        {
            string response;
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\Desktop\");
            string[] temp = command.Split();
            switch (temp[0].ToUpper())
            {
                case "MKD":
                    if (!rights.Contains("w"))
                        response = "You have not enough permissions. You can " + rights;
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
