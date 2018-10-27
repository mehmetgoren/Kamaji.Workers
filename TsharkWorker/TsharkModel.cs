namespace TsharkWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    public sealed class TsharkModel
    {
        private static readonly List<PropertyInfo> props = typeof(TsharkModel).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

        public static IList<TsharkModel> Deserialize(string csv)
        {
            List<TsharkModel> ret = new List<TsharkModel>();

            string[] arr = csv.Split('\n');
            if (arr.Length > 1)
            {
                for (int j = 1; j < arr.Length; ++j)//header' ı atayıruz.
                {
                    string item = arr[j];
                    if (!String.IsNullOrEmpty(item))
                    {
                        string[] fields = item.Split(';');
                        if (fields.Length == props.Count)
                        {
                            TsharkModel model = new TsharkModel();
                            for (int k = 0; k < fields.Length; ++k)
                            {
                                PropertyInfo pi = props[k];
                                pi.SetValue(model, fields[k]);
                            }
                            ret.Add(model);
                        }
                    }
                }
            }

            return ret;
        }

        public string FrameNumber { get; set; }
        public string FrameTime { get; set; }
        public string EthSrc { get; set; }
        public string EthDst { get; set; }
        public string IpSrc { get; set; }
        public string IpDst { get; set; }
        public string IpProto { get; set; }
    }
}
