using PublicClass;
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;

namespace Remoting
{
    public class RemotingManager
    {
        private const string _ChannelName = "GpsClientChannel";

        private const int _timeOut = 120000;

        private static bool HasRegChannel
        {
            get
            {
                IChannel[] registeredChannels = ChannelServices.RegisteredChannels;
                for (int i = 0; i < (int)registeredChannels.Length; i++)
                {
                    if ("GpsClientChannel".Equals(registeredChannels[i].ChannelName))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public RemotingManager()
        {
        }

        public static void OffRegHttpChannel()
        {
            IChannel[] registeredChannels = ChannelServices.RegisteredChannels;
            for (int i = 0; i < (int)registeredChannels.Length; i++)
            {
                ChannelServices.UnregisterChannel(registeredChannels[i]);
            }
        }

        public static void RegChannel()
        {
            if (RemotingManager.HasRegChannel)
            {
                return;
            }
            Hashtable hashtables = new Hashtable();
            hashtables["name"] = "GpsClientChannel";
            hashtables["timeout"] = 120000;
            ChannelServices.RegisterChannel(new TcpChannel(hashtables, null, null), false);
            bool hasRegChannel = RemotingManager.HasRegChannel;
        }

        public static void RegHttpChannel()
        {
            if (RemotingManager.HasRegChannel)
            {
                return;
            }
            BinaryClientFormatterSinkProvider binaryClientFormatterSinkProvider = new BinaryClientFormatterSinkProvider();
            IDictionary hashtables = new Hashtable();
            hashtables["name"] = "GpsClientChannel";
            hashtables["timeout"] = 120000;
            hashtables["ProxyName"] = Variable.sHttpProxyIp;
            hashtables["ProxyPort"] = Variable.sHttpProxyPort;
            ChannelServices.RegisterChannel(new HttpClientChannel(hashtables, null), false);
        }

        public static void UnRegChannel()
        {
            IChannel[] registeredChannels = ChannelServices.RegisteredChannels;
            for (int i = 0; i < (int)registeredChannels.Length; i++)
            {
                IChannel channel = registeredChannels[i];
                if ("1".Equals(channel.ChannelName) || "2".Equals(channel.ChannelName))
                {
                    ChannelServices.UnregisterChannel(channel);
                }
            }
        }
    }
}