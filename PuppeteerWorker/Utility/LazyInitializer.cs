namespace PuppeteerWorker
{
    using System;

    public sealed class LazyInitializer
    {
        private readonly Action _func;

        public LazyInitializer(Action func)
        {
            this._func = func ?? throw new ArgumentNullException(nameof(func));
            this._syncRoot = new object();
            this.executed = false;
        }

        private readonly object _syncRoot;
        private bool executed;
        public void Execute()
        {
            if (!this.executed)
            {
                lock (this._syncRoot)
                {
                    if (!this.executed)
                    {
                        this._func();
                        this.executed = true;
                    }
                }
            }
        }

        public override string ToString()
        {
            return "Executed: " + this.executed;
        }
    }
}
