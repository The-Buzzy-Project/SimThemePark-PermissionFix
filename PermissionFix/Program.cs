using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace PermissionFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Granting permission to Golden Ticket. This may take a few minutes...");
            Console.WriteLine("");
            Console.WriteLine("");

            changePermissions(Directory.GetCurrentDirectory());
            Console.WriteLine("Completed step 1/6");
            changePermissions(Directory.GetCurrentDirectory() + "\\data");
            Console.WriteLine("Completed step 2/6");
            changePermissions(Directory.GetCurrentDirectory() + "\\data\\levels\\fantasy");
            Console.WriteLine("Completed step 3/6");
            changePermissions(Directory.GetCurrentDirectory() + "\\data\\levels\\hallow");
            Console.WriteLine("Completed step 4/6");
            changePermissions(Directory.GetCurrentDirectory() + "\\data\\levels\\jungle");
            Console.WriteLine("Completed step 5/6");
            changePermissions(Directory.GetCurrentDirectory() + "\\data\\levels\\space");
            Console.WriteLine("Completed step 6/6");
        }
        static void changePermissions(string file)
        {
            DirectoryInfo dInfo = new DirectoryInfo(file);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
    }
}
