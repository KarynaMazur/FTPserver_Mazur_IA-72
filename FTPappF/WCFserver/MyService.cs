using FTPServer.WCFserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF.WCFserver
{
    public class MyService
    {
        BasicHttpBinding binding;
        EndpointAddress endpoint;

        public MyService()
        {
            Uri address = new Uri("http://localhost:4000/IContract"); 
            binding = new BasicHttpBinding();
            endpoint = new EndpointAddress(address);
        }

        public string Send(string command, string rights)
        {
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, endpoint);
            IContract channel = factory.CreateChannel();
            return channel.Send(command, rights);            
        }
    }
}
