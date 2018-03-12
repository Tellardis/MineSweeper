using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Model
{
    public class MineButton
    {
        public MineButtonType Type { get; private set; }
        private MineButtonState _state;
        public MineButtonState State
        {
            get
            {
                return _state;
            }
            private set
            {
                if (State == MineButtonState.Deactivated) return;
                _state = value;
                StateChanged?.Invoke(this, null);
            }
        }
        public int MineNear { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        private Field _field;
        public MineButton(Field field, MineButtonType type, int x, int y)
        {
            _field = field;
            Type = type;
            _state = MineButtonState.UnMarked;
            PosX = x;
            PosY = y;
            field.FieldFilled += Field_FieldFilled;
        }

        private void Field_FieldFilled(object sender, EventArgs e)
        {
            MineNear = _field.GetNearMinesCount(PosX, PosY);
        }

        public void Mark(MineButtonState state)
        {
            if (state == MineButtonState.ExplodedPressed || state == MineButtonState.Deactivated) return;
            State = state;
        }

        public void Detonate()
        {
            if (State == MineButtonState.MarkAsMine) return;
            if (Type == MineButtonType.Mine)
            {
                State = MineButtonState.ExplodedPressed;
            }
            else
            {
                State = MineButtonState.Deactivated;
            }
        }

        public event EventHandler StateChanged;
    }
}
