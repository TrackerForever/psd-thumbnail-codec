using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using CSShellExtThumbnailHandler;

namespace InstallAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult Install(Session session)
        {
            session.Log("Begin Install");
            //ThumbCreator.ThumbCreator a = new ThumbCreator.ThumbCreator(); 
            // Call RegistrationServices.RegisterAssembly to register the classes in 
            // the current managed assembly to enable creation from COM.
            RegistrationServices regService = new RegistrationServices();
            regService.RegisterAssembly(
                
                typeof(ThumbCreator.ThumbCreator).Assembly,
                AssemblyRegistrationFlags.SetCodeBase);
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult UnInstall(Session session)
        {
            session.Log("Begin UnInstall");
            // Call RegistrationServices.UnregisterAssembly to unregister the classes 
            // in the current managed assembly.
            RegistrationServices regService = new RegistrationServices();
            regService.UnregisterAssembly(typeof(ThumbCreator.ThumbCreator).Assembly);
            return ActionResult.Success;
        }
    }
}
