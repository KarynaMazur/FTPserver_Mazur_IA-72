using System.ServiceModel;

// Контракт.

namespace FTPServer.WCFserver
{    
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Send(string command, string rights);
    }
}


