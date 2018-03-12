using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Core
{
    public class MinerByAlexException : Exception
    {
        public MinerByAlexException(string message) : base(message)
        { }
    }
}
