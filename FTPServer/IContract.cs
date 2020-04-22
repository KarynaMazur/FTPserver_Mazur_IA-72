using System.ServiceModel;

// Контракт.

namespace FTPServer
{    
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        string Send(string command, string rights);
    }
}


