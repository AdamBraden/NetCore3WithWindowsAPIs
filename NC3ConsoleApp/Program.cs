using System;
using System.Diagnostics;
using System.IO;

namespace NC3ConsoleApp
{
    class Program
    {
        public static string PackageId;
        public static string PackageDirectory;
        public static bool HasPackageIdentity { get; private set; }
        public static string ExecutableDirectory;

        static void Main(string[] args)
        {

            ExecutableDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName).ToLowerInvariant();

            //Packaging APIs
            try
            {
                var package = Windows.ApplicationModel.Package.Current;
                PackageId = package.Id.FullName;
                PackageDirectory = package.InstalledLocation.Path.ToLowerInvariant();
            }

            // App is running without being packaged at all
            catch (Exception ex) when (ex.HResult == -2147009196)
            {
                PackageId = "Not packaged";
                PackageDirectory = "Not packaged";
                HasPackageIdentity = false;
            }
            Console.WriteLine($"My name is {PackageId}");
            Console.WriteLine($"My path is {PackageDirectory}");
            Console.Write("Press key to continue");
            Console.ReadLine();
        }
    }
}
