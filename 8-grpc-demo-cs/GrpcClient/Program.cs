﻿using Grpc.Core;
using System;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
                var client = new EmployeeService.EmployeeServiceClient(channel);
                EmployeeName empName = client.GetEmployeeName(new EmployeeNameRequest { EmpId = "1" });
                if (empName == null || string.IsNullOrWhiteSpace(empName.FirstName) || string.IsNullOrWhiteSpace(empName.LastName))
                {
                    Console.WriteLine("Employee not found.");
                }
                else
                {
                    Console.WriteLine($"The employee name is {empName.FirstName} {empName.LastName}.");
                }
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}
