using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Model
{
    public class Field
    {
        public int MinesCount { get; set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public int Length
        {
            get
            {
                return SizeX * SizeY;
            }
        }

        private FieldConfig _fieldConfig;
        private MineButton[,] _field;
        public MineButton this[int x, int y]
        {
            get
            {
                return _field[x, y];
            }

            set
            {
                if (_field[x, y] != null) throw new MinerByAlexException(MinerStrings.MineButtonAllreadySet);
                _field[x, y] = value;
            }
        }

        public void Unsuspend()
        {
            if (_field[0, 0] == null) return;
            foreach (var item in _field)
            {
                item.StateChanged += Value_StateChanged;
            }
        }

        public void Suspend()
        {
            if (_field[0, 0] == null) return;
            foreach (var item in _field)
            {
                item.StateChanged -= Value_StateChanged;
            }
        }

        private void Value_StateChanged(object sender, EventArgs e)
        {
            var mineBtn = sender as MineButton;


            if (mineBtn.Type != MineButtonType.Mine && mineBtn.MineNear == 0)
            {
                Suspend();
                OpenNearCells(mineBtn.PosX, mineBtn.PosY);
                Unsuspend();
            }
            MinesStateChanged?.Invoke(this, null);
        }

        public event EventHandler MinesStateChanged;

        private void OpenNearCells(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 ||
                        j < 0 ||
                        i >= SizeX ||
                        j >= SizeY ||
                        (i == x && j == y) ||
                        _field[i, j].Type == MineButtonType.Mine ||
                        _field[i, j].State != MineButtonState.UnMarked)
                        continue;
                    _field[i, j].Detonate();
                    if (_field[i, j].MineNear == 0)
                        OpenNearCells(i, j);
                }
        }

        public void FastOpenCells(int x, int y)
        {
            Suspend();
            var mineNear = _field[x, y].MineNear;
            var mineMarked = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 ||
                        j < 0 ||
                        i >= SizeX ||
                        j >= SizeY ||
                        (i == x && j == y) ||
                        _field[i, j].State != MineButtonState.MarkAsMine)
                        continue;
                    mineMarked++;
                }
            if (mineMarked == mineNear)
                for (int i = x - 1; i <= x + 1; i++)
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i < 0 ||
                            j < 0 ||
                            i >= SizeX ||
                            j >= SizeY ||
                            (i == x && j == y) ||
                            _field[i, j].State != MineButtonState.UnMarked)
                            continue;
                        _field[i, j].Detonate();
                        if (_field[i, j].Type != MineButtonType.Mine && _field[i, j].MineNear == 0)
                            OpenNearCells(i, j);
                    }
            Unsuspend();
            MinesStateChanged?.Invoke(this, null);
        }

        public Field(FieldConfig fieldConfig)
        {
            SizeX = fieldConfig.SizeX;
            SizeY = fieldConfig.SizeY;
            MinesCount = fieldConfig.MinesCount;
            _fieldConfig = fieldConfig;
            if (_fieldConfig.IsReadyToGame())
            {
                _field = new MineButton[SizeX, SizeY];
            }
            MinesStateChanged += (e, a) => { _fieldConfig.VictoryManager.Check(); };
        }

        public void FillField(int x, int y)
        {
            //Suspend();
            _fieldConfig.FieldFiller.FillField(this, x, y);
            Unsuspend();
            FieldFilled?.Invoke(this, null);
        }


        public int GetNearMinesCount(int x, int y)
        {
            var result = 0;
            //Оптимизэйшон!
            if (_field[x, y].Type == MineButtonType.Mine) return result;

            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || j < 0 || i >= SizeX || j >= SizeY) continue;
                    if (_field[i, j].Type == MineButtonType.Mine)
                        result++;
                }

            return result;
        }
        public event EventHandler FieldFilled;
        public void MarkAllMines()
        {
            Suspend();
            for (var i = 0; i < SizeX; i++)
                for (var j = 0; j < SizeY; j++)
                {
                    if (_field[i, j] == null) continue;
                    if (_field[i, j].Type == MineButtonType.Mine)
                        _field[i, j].Mark(MineButtonState.MarkAsMine);
                }
            Unsuspend();
        }

        public void ExplodeAllMines()
        {
            Suspend();
            for (var i = 0; i < SizeX; i++)
                for (var j = 0; j < SizeY; j++)
                {
                    if (_field[i, j] == null) continue;
                    if (_field[i, j].Type == MineButtonType.Mine && _field[i, j].State == MineButtonState.UnMarked)
                        _field[i, j].Mark(MineButtonState.Exploded);
                }
            Unsuspend();
        }
    }
}
