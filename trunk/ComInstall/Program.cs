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
            if (args.Length <= 1)
                return;
            ProjectInstaller tmpInstaller = new ProjectInstaller();            
            if (args[1] == "uninstall")
              tmpInstaller.Uninstall();
            else
              tmpInstaller.Install();
        }
    }
}
