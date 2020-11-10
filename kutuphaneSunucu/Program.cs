using System;
using Grpc.Core;
using Kutuphane;
using kutuphaneSunucu.Servisler;

namespace kutuphaneSunucu
{
    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { KutuphaneService.BindService(new KutuphaneServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            
            Console.WriteLine("Kütüphane sunucusu " + Port +" nolu portta çalışıyor.");
            Console.WriteLine("Sunucuyu durdurmak için bir tuşa basın..");
            Console.ReadKey();
            server.ShutdownAsync().Wait();
        }
    }
}
