using System;
using System.IO;
using System.ServiceModel;
using System.Text;

namespace FTPServer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            Uri address = new Uri("http://localhost:4000/IContract");  // адреса

            BasicHttpBinding binding = new BasicHttpBinding();      //  привязка

            Type contract = typeof(IContract);                 // Указание контракта.       

            var host = new ServiceHost(typeof(Service)); // Создание провайдера Хостинга с указанием Сервиса.

            
            host.AddServiceEndpoint(contract, binding, address);

            
            host.Open();


            Console.WriteLine("Приложение готово к приему сообщений.");
            Console.ReadKey();


            // Завершение ожидания прихода сообщений.
            host.Close();
        }
    }
}
