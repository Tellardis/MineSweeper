using MinerByAlex.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Core
{
    public class FieldConfig : ICloneable
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int MinesCount { get; set; }
        public RulesManager VictoryManager { get; set; }
        public IMinerFieldFiller FieldFiller { get; set; }
        public bool IsReadyToGame()
        {
            if (SizeX == 0) throw new MinerByAlexException(MinerStrings.SizeXZeroException);
            if (SizeY == 0) throw new MinerByAlexException(MinerStrings.SizeYZeroException);
            if (MinesCount == 0) throw new MinerByAlexException(MinerStrings.MinesCountZeroException);
            if (VictoryManager == null) throw new MinerByAlexException(MinerStrings.VictoryManagerNullReferenceException);
            if (FieldFiller == null) throw new MinerByAlexException(MinerStrings.FieldFillerNullReferenceException);
            return true;
        }

        public object Clone()
        {
            return new FieldConfig()
            {
                SizeX = SizeX,
                SizeY = SizeY,
                FieldFiller = FieldFiller,
                MinesCount = MinesCount,
                VictoryManager = VictoryManager
            };
        }
    }
}
