using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Core
{
    public enum MineButtonState
    {
        UnMarked = 0,
        Deactivated,
        Suspicious,
        MarkAsMine,
        Exploded,
        ExplodedPressed
    }
}
