using Hipicapp.Utils.Comparison;
using System;
using System.Threading;

namespace Hipicapp.Utils.Concurrent.Atomic
{
    [Serializable]
    public class AtomicReference<V> where V : class
    {
        private V CurrentValue;

        public AtomicReference(V initialValue)
        {
            CurrentValue = initialValue;
        }

        public V Get
        {
            get
            {
                return this.CurrentValue;
            }
        }

        public V Set(V newValue)
        {
            return Interlocked.Exchange<V>(ref CurrentValue, newValue);
        }

        public bool CompareAndSet(V expectedValue, V newValue)
        {
            return Interlocked.CompareExchange<V>(ref CurrentValue, newValue, expectedValue).Equals(expectedValue);
        }

        public V GetAndSet(V newValue)
        {
            while (true)
            {
                V x = this.Get;
                if (CompareAndSet(x, newValue))
                {
                    return x;
                }
            }
        }

        public override string ToString()
        {
            return ToStringBuilder.ReflectionToString(this.Get);
        }
    }
}