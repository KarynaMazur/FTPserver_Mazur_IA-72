using FTPapp;
using FTPapp.Exceptions;
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
            myService.Ping();

            string command;
            FTPManager fTPManager = new FTPManager();

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
            }
        }
    }
}
