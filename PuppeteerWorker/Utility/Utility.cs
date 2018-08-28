namespace PuppeteerWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;

    public static class Utility
    {
        public static int GenerateAnAvailablePort()
        {
            int GetRandomPortNumber()
            {
                return new Random().Next(1, ushort.MaxValue);
            }

            var list = new HashSet<int>(IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Select(p => p.Port).OrderBy(p => p));

            int port;
            while (true)
            {
                port = GetRandomPortNumber();
                if (!list.Contains(port))
                    break;
            }

            return port;
        }

        public static IPAddress GetIpv4Address() => IPAddress.Parse("127.0.0.1");//linux ve windows için.
          //  => Dns.GetHostEntry(String.Empty).AddressList.FirstOrDefault(p => p.AddressFamily == AddressFamily.InterNetwork);
    }
}
