using FTPapp;
using FTPapp.Exceptions;
using FTPappF.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer;

namespace FTPappF
{
    class Program
    {
        static void Main(string[] args)
        {
            var myService = new MyService();
            if (!myService.Ping())
                return;

            User user = Authorization();

            Console.WriteLine("Hi, {0}! You can {1}", user.Name, user.Rights);

            string command;
            FTPManager fTPManager = new FTPManager(user);

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите команду FTP: ");
                    command = Console.ReadLine();

                    Console.WriteLine(fTPManager.ExecuteCommand(command));
                    Console.WriteLine();
                }
                catch (UnknownCommandException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        private static User Authorization()
        {
            Console.WriteLine("Your name: ");
            string name = Console.ReadLine();
            if (name == "admin")
                return new UserBuilder().SetName(name).CreateAdmin().Build();
            else
                return new UserBuilder().SetName(name).SetRights("r").Build();
        }
    }
}
