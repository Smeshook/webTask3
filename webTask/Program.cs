using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
class Client
{
    static void Main(string[] args)
    {
        Uri tcpUri = new Uri("net.tcp://127.0.0.1:10000/cleverSearch");
        EndpointAddress address = new EndpointAddress(tcpUri);
        NetTcpBinding clientBinding = new NetTcpBinding();
        ChannelFactory<IService> factory = new ChannelFactory<IService>(clientBinding, address);
        var service = factory.CreateChannel();

        Console.WriteLine("Enter path to book");
        string pathToBook = Console.ReadLine();
        string pathToUniqueWords = @".\uniqueWordsPublic.txt";

        try
        {
            StreamReader fileText = new StreamReader(pathToBook);
            string fileString = fileText.ReadToEnd();

            Dictionary<string, int> totalDictionary = service.GetText(fileString);

            StreamWriter uniqeWords = new StreamWriter(pathToUniqueWords);
            foreach (var word in totalDictionary.OrderByDescending(x => x.Value))
                uniqeWords.WriteLine($"{word.Key}\t {word.Value}");
            Console.ReadKey();
        }

        catch
        {
            Console.WriteLine("Error");
            Console.ReadKey();
        }
        
    }
}
