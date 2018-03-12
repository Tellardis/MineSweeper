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
    public partial class Template : Form
    {
        private static Template _instance;
        public static Template GetInstance
        {
            get
            {
                if (_instance == null) _instance = new Template();
                return _instance;
            }
        }

        public void SetUnmarkedButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = Mine.FlatStyle;
            btn.Text = "";
            btn.BackColor = Mine.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }

        public void SetMarkedAsMineButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = MineMarkAsMine.FlatStyle;
            btn.Text = MineMarkAsMine.Text;
            btn.BackColor = MineMarkAsMine.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }

        public Size GetButtonSize()
        {
            return Mine.Size;
        }
        private Template()
        {
            InitializeComponent();
        }

        public void SetDeactivatedButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = btn_deactivated.FlatStyle;
            btn.Font = btn_deactivated.Font;
            btn.FlatAppearance.BorderColor = Color.FromArgb(255, 235, 204, 172);
            btn.FlatAppearance.BorderSize = 1;
            if (btn.NearMinesCount == 0)
            {
                btn.Text = "";
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.Text = btn.NearMinesCount.ToString();
                switch (btn.NearMinesCount)
                {
                    case 1: btn.ForeColor = Color.Blue; break;
                    case 2: btn.ForeColor = Color.ForestGreen; break;
                    case 3: btn.ForeColor = Color.Red; break;
                    case 4: btn.ForeColor = Color.DarkBlue; break;
                    case 5: btn.ForeColor = Color.DarkRed; break;
                    case 6: btn.ForeColor = Color.Cyan; break;
                    case 7: btn.ForeColor = Color.Magenta; break;
                    case 8: btn.ForeColor = Color.Black; break;
                }
            }

            btn.BackColor = btn_deactivated.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }



        internal void SetSuspiciousButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = btn_suspicious.FlatStyle;
            btn.Text = btn_suspicious.Text;
            btn.BackColor = btn_suspicious.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }

        internal void SetExplodedButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = btn_exploded.FlatStyle;
            btn.Text = btn_exploded.Text;
            btn.BackColor = btn_exploded.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }
        internal void SetExplodedPressedButtonView(MineButton btn)
        {
            btn.Size = GetButtonSize();
            btn.FlatStyle = btn_exploded_pressed.FlatStyle;
            btn.Text = btn_exploded_pressed.Text;
            btn.BackColor = btn_exploded_pressed.BackColor;
            btn.Margin = new Padding(0);
            btn.Padding = new Padding(0);
        }

        private void Template_Load(object sender, EventArgs e)
        {

        }
    }
}
