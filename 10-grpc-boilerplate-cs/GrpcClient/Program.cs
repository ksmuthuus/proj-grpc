using Dummy;
using Grpc.Core;
using System;

namespace GrpcClient
{
    class Program
    {
        const String target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Channel channel = null;

            try
            {
                channel = new Channel(target, ChannelCredentials.Insecure);
                channel.ConnectAsync().ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        Console.WriteLine("Client Connection Success!!!");
                    }
                });

                var client = new DummyService.DummyServiceClient(channel);
                channel.ShutdownAsync().Wait();
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed for reason",ex.Message);
                throw;
            }
        }
    }
}
