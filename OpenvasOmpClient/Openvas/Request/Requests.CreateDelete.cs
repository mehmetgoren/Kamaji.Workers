namespace OpenvasOmpClient
{
    using System.Xml.Serialization;


    partial class Requests
    {
        public struct UUID
        {
            [XmlAttribute("id")]
            public string Id { get; set; }

            public static implicit operator UUID(string id) => new UUID { Id = id };
        }


        public class create_credential
        {
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("login")]
            public string Login { get; set; }

            [XmlElement("password")]
            public string Password { get; set; }

            [XmlElement("comment")]
            public string Comment { get; set; }
        }
        public class delete_credential
        {
            [XmlAttribute("credential_id")]
            public string CredentialId { get; set; }

            [XmlAttribute("ultimate")]
            public int Ultimate { get; set; } = 1;
        }



        public class create_target
        {
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("comment")]
            public string Comment { get; set; }

            [XmlElement("hosts")]
            public string Hosts { get; set; }


            [XmlElement("ssh_lsc_credential")]
            public UUID SshLscCredential { get; set; }

            [XmlElement("smb_lsc_credential")]
            public UUID SmbLscCredential { get; set; }

            [XmlElement("esxi_lsc_credential")]
            public UUID EsxiLscCredential { get; set; }



            [XmlElement("alive_tests")]
            public string AliveTests { get; set; }

            [XmlElement("reverse_lookup_only")]
            public string ReverseLookupOnly { get; set; }

            [XmlElement("reverse_lookup_unify")]
            public string ReverseLookupUnify { get; set; }

            [XmlElement("port_range")]
            public string PortRange { get; set; }

            [XmlElement("port_list")]
            public UUID PortList { get; set; }
        }
        public class delete_target
        {
            [XmlAttribute("target_id")]
            public string TargetId { get; set; }

            [XmlAttribute("ultimate")]
            public int Ultimate { get; set; } = 1;
        }



        public class create_task
        {
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("comment")]
            public string Comment { get; set; }

            [XmlElement("alterable")]
            public int Alterable { get; set; } = 1;

            [XmlElement("config")]
            public UUID Config { get; set; }

            [XmlElement("target")]
            public UUID Target { get; set; }

            [XmlElement("scanner")]
            public UUID Scanner { get; set; }
        }
        public class delete_task
        {
            [XmlAttribute("task_id")]
            public string TaskId { get; set; }

            [XmlAttribute("ultimate")]
            public int Ultimate { get; set; } = 1;
        }
    }
}
