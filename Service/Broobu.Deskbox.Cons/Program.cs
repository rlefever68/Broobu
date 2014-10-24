using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Disco.Cons;
using Broobu.Engine.Cons;

namespace Broobu.Community.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            EngineRunner.Run(args);
            DiscoRunner.Run(args);
            Console.WriteLine("Press <Enter> to terminate.");
            Console.ReadLine();
            DiscoRunner.Terminate();
            EngineRunner.Terminate();
            Console.ReadLine();
        }
    }
}
