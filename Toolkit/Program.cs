using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Toolkit.Connectivity;
using Toolkit.Drives.ExtentionMethods;

namespace Toolkit
{
    public class Program
    {
        public Program()
        {

        }

        public void RunTest1()
        {
            DriveInfo[] dArray = DriveInfo.GetDrives();
            foreach(DriveInfo di in dArray)
            {
                if(di.DriveType == DriveType.Fixed)
                {
                    Console.WriteLine(string.Format("Name: {0}", di.Name));
                    Console.WriteLine(string.Format("Total size in GB: {0}", di.GetTotalSize(DriveInfoExtentionMethods.UnitSize.GigaByte)));
                    Console.WriteLine(string.Format("Total space free in GB: {0}", di.GetTotalFreeSpace()));
                    Console.WriteLine(string.Format("Percent free: {0}%", di.GetPercentFree()));
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        public void RunTest2()
        {
            Console.WriteLine("Checking resolve of www.google.com, default dns.");
            bool succes = DnsCheck.IsResolvingByDefaultDNS("www.google.com");
            Console.WriteLine("Succes: " + succes.ToString());

            Console.WriteLine("Checking resolve of www.google.com, google dns.");
            succes = DnsCheck.IsResolvingByGoogleDNS("www.google.com");
            Console.WriteLine("Succes: " + succes.ToString());

            Console.WriteLine("Checking resolve of www.google.com, open dns.");
            succes = DnsCheck.IsResolvingByOpenDNS("www.google.com");
            Console.WriteLine("Succes: " + succes.ToString());

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.RunTest1();
            p.RunTest2();
        }
    }
}
