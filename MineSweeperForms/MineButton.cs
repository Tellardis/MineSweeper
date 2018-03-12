using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerByAlexForms
{
    public class MineButton : Button
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int NearMinesCount { get; set; }
        public MineButtonState State { get; set; }
    }
}
