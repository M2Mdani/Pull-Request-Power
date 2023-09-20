using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiddleLibrary;

namespace ConsumerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We call other library(.dll) to call the WCF
            // Only 1 App.config 
            Proxy pr = new Proxy();
            pr.Write();
        }
    }
}
