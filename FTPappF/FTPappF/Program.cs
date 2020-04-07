using FTPapp;
using FTPapp.Exceptions;
using FTPappF.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace FTPappF
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.MyService local = new localhost.MyService();

            string command;
            FTPManager fTPManager = new FTPManager(local);

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

    }
}
