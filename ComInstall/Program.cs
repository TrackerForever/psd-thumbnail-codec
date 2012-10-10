using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSShellExtThumbnailHandler;

namespace ComInstall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("entering:" + args.Length);
            if (args.Length <= 0)
                return;
            Console.WriteLine("creating projectinstaler");
            ProjectInstaller tmpInstaller = new ProjectInstaller();
            if (args[0] == "uninstall")
                tmpInstaller.Uninstall();
            else
            {
                Console.WriteLine("installing");
                tmpInstaller.Install();
            }
        }
    }
}
