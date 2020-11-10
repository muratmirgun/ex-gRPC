using System;
using Grpc.Core;
using Kutuphane;

namespace kutuphaneIstemci
{
    class Program
    {
        public static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new KutuphaneService.KutuphaneServiceClient(channel);

            /* 
            KutuphaneServiceRequest istek=new KutuphaneServiceRequest();
            istek.Id=1;
            var sonucum = client.KitapGetirID(istek);
            Console.WriteLine(sonucum.StatusMessage);
            Console.WriteLine(sonucum.Sonuclar[0].KitapAdi);
            */   
            
            channel.ShutdownAsync().Wait();
            Console.WriteLine("İstemciyi durdurmak için bir tuşa basın..");
            Console.ReadKey();
        }
    }
}
