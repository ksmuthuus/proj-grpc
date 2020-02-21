using Grpc.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer.Controller
{
    class EmployeeController : EmployeeService.EmployeeServiceBase
    {
        // Server side handler of the GetEmployeeName RPCpublic 
        public override Task<EmployeeName> GetEmployeeName(EmployeeNameRequest request, ServerCallContext context)
        {
            EmployeeData empData = new EmployeeData();
            return Task.FromResult(empData.GetEmployeeName(request) );
        }
}
}
