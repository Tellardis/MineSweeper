using MinerByAlex;
using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerByAlexForms
{
    public partial class CustomSettings : Form
    {
        private Action<int, int, int> _action;
        public CustomSettings(Action<int, int, int> action)
        {
            InitializeComponent();
            _action = action;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _action((int)npd_SizeX.Value, (int)npd_SizeY.Value, (int)npd_MinesCount.Value);
            Close();
        }
    }
}
