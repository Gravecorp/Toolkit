using JHSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Toolkit.Connectivity
{
    public class DnsCheck
    {

        public static bool IsResolvingByDefaultDNS(string hostname)
        {
            bool ret = false;
            try
            {
                IPHostEntry hostEntry;

                hostEntry = Dns.GetHostEntry(hostname);

                if(hostEntry.AddressList.Count() > 0)
                {
                    ret = true;
                }

            }
            catch (Exception e)
            {

            }

            return (ret);
        }

        public static bool IsResolvingByGoogleDNS(string hostname)
        {
            bool ret = false;

            DnsClient.RequestOptions options = new DnsClient.RequestOptions();

            IPAddress firstGoogleDns = IPAddress.Parse("8.8.8.8");
            IPAddress secondGoogleDns = IPAddress.Parse("8.8.4.4");

            options.DnsServers = new IPAddress[] { firstGoogleDns, secondGoogleDns};

            IPAddress[] result = DnsClient.LookupHost(hostname, DnsClient.IPVersion.IPv4, options);

            if(result.Count() > 0)
            {
                ret = true;
            }

            return (ret);
        }

        public static bool IsResolvingByOpenDNS(string hostname)
        {
            bool ret = false;

            DnsClient.RequestOptions options = new DnsClient.RequestOptions();

            IPAddress firstGoogleDns = IPAddress.Parse("208.67.222.222");
            IPAddress secondGoogleDns = IPAddress.Parse("208.67.220.220");

            options.DnsServers = new IPAddress[] { firstGoogleDns, secondGoogleDns };

            IPAddress[] result = DnsClient.LookupHost(hostname, DnsClient.IPVersion.IPv4, options);

            if (result.Count() > 0)
            {
                ret = true;
            }

            return (ret);
        }
    }
}
