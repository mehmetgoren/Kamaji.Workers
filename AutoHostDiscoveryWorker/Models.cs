namespace AutoHostDiscoveryWorker
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    internal sealed class OrginalXmlModel
    {
        public sealed class Verbose
        {
            public string level { get; set; }
        }

        public sealed class Debugging
        {
            public string level { get; set; }
        }

        public sealed class Status
        {
            public string state { get; set; }
            public string reason { get; set; }
            public string reason_ttl { get; set; }
        }

        public sealed class Address
        {
            public string addr { get; set; }
            public string addrtype { get; set; }
        }

        public sealed class Host
        {
            public Status status { get; set; }
            public  List<Address> address { get; set; }
            public string hostnames { get; set; }
        }

        public sealed class Finished
        {
            public string time { get; set; }
            public string timestr { get; set; }
            public string elapsed { get; set; }
            public string summary { get; set; }
            public string exit { get; set; }
        }

        public sealed class Hosts
        {
            public string up { get; set; }
            public string down { get; set; }
            public string total { get; set; }
        }

        public sealed class Runstats
        {
            public Finished finished { get; set; }
            public Hosts hosts { get; set; }
        }

        public sealed class Nmaprun
        {
            public string scanner { get; set; }
            public string args { get; set; }
            public string start { get; set; }
            public string startstr { get; set; }
            public string version { get; set; }
            public string xmloutputversion { get; set; }
            public Verbose verbose { get; set; }
            public Debugging debugging { get; set; }
            public List<Host> host { get; set; }
            public Runstats runstats { get; set; }
        }


        public Nmaprun nmaprun { get; set; }
    }




    internal sealed class AddresListModel
    {
        [JsonProperty("addressList")]
        public AddressListInfo AddressList { get; set; }

        internal sealed class AddressListInfo
        {
            [JsonProperty("address")]
            public Address[] Address { get; set; }
        }

        internal sealed class Address
        {
            [JsonProperty("addr")]
            public string Addr { get; set; }

            [JsonProperty("addrtype")]
            public string Addrtype { get; set; }

            [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
            public string Vendor { get; set; }
        }
    }



    public sealed class AutoDiscoveryModel : IEquatable<AutoDiscoveryModel>
    {
        public string Address { get; set; }
       // public string AddressType { get; set; }
        public string Vendor { get; set; }
        public string Mac { get; set; }


        public bool Equals(AutoDiscoveryModel other) => String.Equals(this.Address, other?.Address);

        public override bool Equals(object obj) => this.Equals(obj as AutoDiscoveryModel);

        public override int GetHashCode() => this.Address?.GetHashCode() ?? 0;

        public override string ToString() => this.Address;
    }
}
