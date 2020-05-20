using FTPapp;
using FTPapp.Exceptions;
using FTPappF.Builder;
using FTPappF.Visitor;
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
            string command;
            MakeLog makeLog = new MakeLog();
            FTPManager fTPManager = new FTPManager(makeLog);

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
                    makeLog.VisitUnknownCommandException(ex); //visitor
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
