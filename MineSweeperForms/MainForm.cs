using MinerByAlex;
using MinerByAlex.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MinerByAlex.Core;

namespace MinerByAlexForms
{
    public partial class MainForm : Form, IMinerView
    {
        #region Fields
        private MinerPresenter _presenter;
        private FieldConfig _currentConfig;
        private bool gameOver = false;
        private List<MineButton> _buttons;
        #endregion

        #region CTOR
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region IMinerViewImplementation
        public void StartGame()
        {
            Application.Run(this);
        }
        public void OnNewGame(object sender, EventArgs e)
        {
            MaximumSize = new Size(0, 0);
            MinimumSize = new Size(0, 0);
            _buttons = new List<MineButton>();
            flp_field.Controls.Clear();
            gameOver = false;
            var tmp = Template.GetInstance;
            var size = tmp.GetButtonSize();
            var FieldButtonCount = _presenter.SizeX * _presenter.SizeY;
            var fieldWidth = size.Width * _presenter.SizeX;
            var fieldHeight = size.Height * _presenter.SizeY;
            Size = new Size(fieldWidth + 45, fieldHeight + 95);
            for (var i = 0; i < FieldButtonCount; i++)
            {
                var btn = new MineButton();
                btn.PosY = i / _presenter.SizeX;
                btn.PosX = i % _presenter.SizeX;
                btn.MouseDown += Btn_MouseClick;
                tmp.SetUnmarkedButtonView(btn);
                flp_field.Controls.Add(btn);
                _buttons.Add(btn);
            }
            MaximumSize = Size;
            MinimumSize = Size;
        }

        public void GameOver()
        {
            _presenter.ExplodeAllMines();
            MessageBox.Show("GameOver");
            gameOver = true;
        }

        public void Victory()
        {
            _presenter.MarkAllMines();
            MessageBox.Show("Victory");
            gameOver = true;
        }

        public void SetPresenter(MinerPresenter minerPresenter)
        {
            _presenter = minerPresenter;
        }

        public void FillNearMineCount()
        {
            foreach (var item in _buttons)
            {
                item.NearMinesCount = _presenter.GetCellNearMinesCount(item.PosX, item.PosY);
            }
        }
        public void FieldRefresh()
        {
            flp_field.SuspendLayout();
            var tmp = Template.GetInstance;
            foreach (var item in _buttons)
            {
                item.State = _presenter.GetCellState(item.PosX, item.PosY);
                switch (item.State)
                {
                    case MineButtonState.Deactivated:
                        tmp.SetDeactivatedButtonView(item);
                        break;
                    case MineButtonState.ExplodedPressed:
                        tmp.SetExplodedPressedButtonView(item);
                        break;
                    case MineButtonState.Exploded:
                        tmp.SetExplodedButtonView(item);
                        break;
                    case MineButtonState.MarkAsMine:
                        tmp.SetMarkedAsMineButtonView(item);
                        break;
                    case MineButtonState.Suspicious:
                        tmp.SetSuspiciousButtonView(item);
                        break;
                    case MineButtonState.UnMarked:
                        tmp.SetUnmarkedButtonView(item);
                        break;
                }
            }
            flp_field.ResumeLayout();
        }
        #endregion

        #region FormEvents
        private void button2_Click(object sender, EventArgs e)
        {
            new CustomSettings((x, y, count) => { _currentConfig = _presenter.NewCustomGame(_currentConfig, x, y, count); }).ShowDialog();
            comboBox1.Text = "Пользовательская";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(_presenter.ConfigItems);
            comboBox1.SelectedIndex = 0;
            _presenter.NewGame(_currentConfig);
        }
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameOver) return;
            var btn = sender as MineButton;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _presenter.DetonaiteMine(btn.PosX, btn.PosY);
                    break;
                case MouseButtons.Right:
                    RightButtonClick(btn);
                    break;
            }
        }

        private void RightButtonClick(MineButton btn)
        {
            switch (btn.State)
            {
                case MineButtonState.UnMarked:
                    _presenter.MarkMine(btn.PosX, btn.PosY, MineButtonState.MarkAsMine);
                    break;
                case MineButtonState.Suspicious:
                    _presenter.MarkMine(btn.PosX, btn.PosY, MineButtonState.UnMarked);
                    break;
                case MineButtonState.MarkAsMine:
                    _presenter.MarkMine(btn.PosX, btn.PosY, MineButtonState.Suspicious);
                    break;
                case MineButtonState.Deactivated:
                    _presenter.FastOpenCells(btn.PosX, btn.PosY);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.NewGame(_currentConfig);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentConfig = ((ConfigItem)comboBox1.SelectedItem).FieldConfig;
        }
        #endregion

        #region CheatCodes
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.ControlKey | Keys.Control))
            {
                if (!gameOver)
                    _presenter.MarkAllMines();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
