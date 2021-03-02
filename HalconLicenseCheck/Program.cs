namespace HalconLicenseCheck
{
     using System;
     using HalconDotNet;

     class Program
     {
          static void Main(string[] args)
          {
               Console.WriteLine("Checking HALCON status...");
               try
               {
                    var halconRoot = Environment.GetEnvironmentVariable("HALCONROOT");
                    var halconArch = Environment.GetEnvironmentVariable("HALCONARCH");
                    if (string.IsNullOrEmpty(halconRoot) || string.IsNullOrEmpty(halconArch))
                    {
                         Console.WriteLine("HALCONROOT or HALCONARCH environment variables are not set.");
                    }
                    else
                    {
                         Console.WriteLine($@"HALCONROOT = {halconRoot}; HALCONARCH = {halconArch}.");
                    }                    
                    Console.WriteLine($@"HALCON version is {HSystem.GetSystemInfo("version")};{Environment.NewLine}" +
                         $@"available license files are {HSystem.GetSystemInfo("available_license_files")}'{Environment.NewLine}" +
                         $@"current license info is {HSystem.GetSystemInfo("current_license_info")};{Environment.NewLine}" +
                         $@"available hostids are {HSystem.GetSystemInfo("hostids")}.");
               }
               catch (HOperatorException hEx)
               {
                    Console.WriteLine($"HALCON unable to initialize. Please check if license and dongle are installed correctly.{Environment.NewLine}{hEx.Message}", "HALCON Exception");
                    Environment.Exit(hEx.GetErrorCode());
               }
          }
     }
}
