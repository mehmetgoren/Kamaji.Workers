namespace Dollars
{
    using Kamaji.Worker;
    using PuppeteerWorker;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class Worker : PuppeteerWorkerBase<Worker>
    {
        public override async Task<object> Run_Internal(ProxyObserver observer, RestClient http, string asset, IScanRepository repository, object args)
        {
            List<Result> result = await http.GetAsync<List<Result>>("getDollars");
            observer.Notify("Dollars", "got dollar values", null);
            return result;
        }

        private sealed class Result
        {
            private object _date;
            public object date
            {
                get
                {
                    if (null != this._date && !String.IsNullOrEmpty(this._date.ToString()))
                    {
                        try
                        {
                            DateTime d2 = DateTime.Parse(this._date.ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind);
                            return new DateTimeOffset(d2).LocalDateTime;
                        }
                        catch { }
                    }

                    return DateTime.MinValue;
                }
                set => this._date = value;
            }


            public string value { get; set; }
        }
    }
}
