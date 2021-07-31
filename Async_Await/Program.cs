
using Async_Await.ClassMethol;
using Async_Await.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await
{
    class Program
    {

        static void Main(string[] args)
        {
            
            InsertData.Run();
            Console.ReadKey();
        }
    
        
    }
}
