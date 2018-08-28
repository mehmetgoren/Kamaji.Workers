namespace Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Kamaji.Worker;
    using System.Linq;

    internal sealed class FakeScanRepository : IScanRepository
    {
        internal Dictionary<string, bool> Dic { get; } = new Dictionary<string, bool>();


        public Task AddChildScan(string parentAsset, IEnumerable<string> childAssetList)
        {
            if (null != childAssetList && childAssetList.Any() /*&& !this.Dic.ContainsKey(newAsset)*/)
            {
                foreach (var asset in childAssetList)
                {
                    if (!this.Dic.ContainsKey(asset))
                    {
                        this.Dic.Add(asset, false);
                    }
                }
            }

            this.Dic[parentAsset] = true;

            return Task.Delay(0);
        }


        public Task<IEnumerable<string>> GetResults(bool alsoGetParentResult, bool alsoGetChildsResults)
        {
            HashSet<string> ret = new HashSet<string>();
            foreach (var kvp in this.Dic)
            {
                if (!kvp.Value)
                    ret.Add(kvp.Key);
            }

            return Task.FromResult(ret as IEnumerable<string>);
        }

    }
}