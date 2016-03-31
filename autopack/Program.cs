using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace autopack
{
    class Program
    {
        static T Deserialize<T>(string nFileName)
        {
            T result_;
            using (FileStream fileStream_ = new FileStream(nFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer xmlSerializer_ = new XmlSerializer(typeof(T));
                result_ = (T)xmlSerializer_.Deserialize(fileStream_);
                fileStream_.Close();
            }
            return result_;
        }

        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("args < 3");
                Console.ReadKey(true);
                return;
            }
            if ("-a" == args[0])
            {
                ApkCommand apkCommand_ = Deserialize<ApkCommand>(args[1]);
                apkCommand_.runCommand(args[2]);
            }
            else if ("-u" == args[0])
            {
                UpdateCommand updateCommand_ = Deserialize<UpdateCommand>(args[1]);
                updateCommand_.runCommand(args[2]);
            }
            else if ("-b" == args[0])
            {
                BuildCommand buildCommand_ = Deserialize<BuildCommand>(args[1]);
                buildCommand_.runCommand(args[2]);
            }
            else if ("-f" == args[0])
            {
                FinishCommand finishCommand_ = Deserialize<FinishCommand>(args[1]);
                finishCommand_.runCommand(args[2]);
            }
            else if ("-p" == args[0])
            {
                PrintCommand printCommand_ = Deserialize<PrintCommand>(args[1]);
                printCommand_.runCommand(args[2]);
            }
        }
    }
}
