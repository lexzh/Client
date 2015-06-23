namespace Library
{
    using System;
    using System.Net;

    public class IPAddressHelper
    {
        public static string GetIpAddress()
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            if (hostAddresses.Length > 1)
            {
                return hostAddresses[1].ToString();
            }
            return hostAddresses[0].ToString();
        }
    }
}

