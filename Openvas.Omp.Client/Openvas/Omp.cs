namespace Openvas.Omp.Client
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    internal static class Omp
    {
        private static readonly Type ObjectType = typeof(Object);
        internal static async Task<T> QueryAsync<T>(string address, object request)
        {
            if (null != request)
            {
                string xml = XmlSerialize(request);
                if (xml.Length > 0)
                {
                    var model = new Request { Xml = xml };
                    RestClient client = new RestClient(address);
                    Response response = await client.PostAsync<Response>("openvas", model);
                    string json = response?.Result?.ToString();
                    if (!String.IsNullOrEmpty(json))
                    {
                        if (typeof(T) == ObjectType)
                        {
                            return (T)JsonConvert.DeserializeObject(json);
                        }

                        var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                        return JsonConvert.DeserializeObject<T>(dic[typeof(T).Name]?.ToString());
                    }
                }
            }

            return default(T);
        }

        private static readonly XmlSerializerNamespaces EmptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        private static readonly XmlWriterSettings Settings = new XmlWriterSettings()
        {
            Indent = true,
            OmitXmlDeclaration = true
        };
        private static string XmlSerialize<T>(T obj)
        {
            string ret = "";
            if (null != obj)
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, Settings))

                {
                    serializer.Serialize(writer, obj, EmptyNamespaces);
                    ret = stream.ToString();
                }
            }

            return ret;
        }


        private sealed class Request
        {
            [JsonProperty("xml")]
            public object Xml { get; set; }
        }


        private sealed class Response
        {
            [JsonProperty("result")]
            public object Result { get; set; }
        }
    }
}
