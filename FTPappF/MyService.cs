using FTPapp.Exceptions;
using FTPappF.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF.WCFserver
{
    public class MyService
    {
        private MakeLog _makeLog;
        public MyService(MakeLog makeLog)
        {
            _makeLog = makeLog;
        }
        public string Send(string command)
        {
            try
            {
                string answer = SendMessageFromSocket(11000, command);
                if (answer == "unknown command")
                {
                    var ex = new UnknownCommandException(answer);
                    _makeLog.VisitUnknownCommandException(ex);
                    throw ex;
                }
                return answer;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }        
        }

        static string SendMessageFromSocket(int port, string command)
        {
            
            byte[] bytes = new byte[1024];

            

            
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            string message = command;

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            
            int bytesSent = sender.Send(msg);

            // ответ от сервера
            int bytesRec = sender.Receive(bytes);

            //Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
            
           
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return Encoding.UTF8.GetString(bytes, 0, bytesRec);
        }
    }
}
