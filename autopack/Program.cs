using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace autopack
{
    class Program
    {
        static void runInitCommand()
        {
            mAbstractCommands[]
        }

        static void runCommand(string nCommand, string nBundleXml)
        {
        }

        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("args < 3");
                Console.ReadKey(true);
                return;
            }
            runCommand(args[0], args[1], args[2]);
        }

        static Dictionary<string, AbstractCommand> mAbstractCommands = new Dictionary<string, AbstractCommand>();
    }
}
