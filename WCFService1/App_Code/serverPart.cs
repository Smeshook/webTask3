using System.ServiceModel;
using System;

class serverPart
{
    static void Main(string[] args)
    {
        var host = new ServiceHost(typeof(Service), new Uri("net.tcp://127.0.0.1:10000/cleverSearch"));
        var serverBilding = new NetTcpBinding();
        host.AddServiceEndpoint(typeof(IService), serverBilding, "");
        host.Open();

        Console.ReadKey();
    }
}