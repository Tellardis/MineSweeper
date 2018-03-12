using MinerByAlex.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.VanilaGame
{
    class StandartRulesManager : RulesManager
    {
        bool _isVictory = false;
        public override bool IsEndOfGame()
        {
            _isVictory = false;
            bool result = false;
            int deactivatedCells = 0;
            var sx = _field.SizeX;
            var sy = _field.SizeY;
            var emptyCells = _field.Length - _field.MinesCount;
            for (var i = 0; i < sx; i++)
            {
                for (var j = 0; j < sy; j++)
                {
                    result = _field[i, j].State == Core.MineButtonState.ExplodedPressed;
                    if (result) return true;
                    if (_field[i, j].State == Core.MineButtonState.Deactivated) deactivatedCells++;
                }
            }
            if (emptyCells == deactivatedCells)
            {
                _isVictory = true;
                return true;
            }
            return false;
        }

        public override bool IsVictory()
        {
            return _isVictory;
        }


    }
}
