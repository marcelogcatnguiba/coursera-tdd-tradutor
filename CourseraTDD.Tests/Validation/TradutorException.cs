using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CourseraTDD.Tests.Validation
{
    public class TradutorException : Exception
    {
        public TradutorException(string message) : base(message)
        {

        }

        public static void Quando(bool esseErro, string message)
        {
            if (esseErro)
            {
                throw new TradutorException(message);
            }
        }
    }
}