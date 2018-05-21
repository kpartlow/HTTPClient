using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client
{
    public class AsyncCorrelation
    {
        private static readonly AsyncLocal<Guid> CorrelationId = new AsyncLocal<Guid>();

        /**
         * Stores the correlationId in an AsyncLocal for access without having to pass the correlationId around.
         */
        public static Guid StoreCorrelationId(Guid correlationId)
        {
            return CorrelationId.Value = correlationId;
        }

        public static Guid CreateCorrelationId()
        {
            return StoreCorrelationId(Guid.NewGuid());
        }

        /**
         * Retrieves the correlationId from the AsyncLocal.
         */
        public static Guid RetrieveCorrelationId()
        {
            return CorrelationId.Value;
        }

        public static string RetrieveCorrelationIdAsString()
        {
            return CorrelationId.Value.ToString("N");
        }

    }
}
