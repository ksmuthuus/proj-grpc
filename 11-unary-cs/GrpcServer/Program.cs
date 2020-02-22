using Grpc.Core;
using System;
using System.IO;

namespace GrpcServer
{
    class Program
    {
        const int port = 50051;
        static void Main(string[] args)
        {

            Server server = null;
            try
            {
                server = new Server()
                {
                    Ports = { new ServerPort("localhost", port, SslServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine($"Server running at port {port}");
                Console.ReadKey();    
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failed to start server for {ex.Message}");
                throw;
            }
            finally
            {
                if(server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}
