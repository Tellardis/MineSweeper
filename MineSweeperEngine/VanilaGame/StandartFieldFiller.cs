using MinerByAlex.Api;
using MinerByAlex.Core;
using MinerByAlex.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.VanilaGame
{
    public class StandartFieldFiller : IMinerFieldFiller
    {
        public void FillField(Field field, int startX, int startY)
        {
            int[,] fieldTemplate = new int[field.SizeX, field.SizeY];
            for (var i = 0; i < field.MinesCount; i++)
            {
                var y = i / field.SizeX;
                var x = i % field.SizeX;
                fieldTemplate[x, y] = 1;
            }

            if (field.Length != field.MinesCount)
            {
                do
                {
                    Common.Shuffle(new Random(), fieldTemplate);
                } while (fieldTemplate[startX, startY] == 1);
            }

            for (var i = 0; i < field.SizeY; i++)
            {
                for (var j = 0; j < field.SizeX; j++)
                {
                    if (fieldTemplate[j, i] == 1)
                    {
                        field[j, i] = new MineButton(field, MineButtonType.Mine, j, i);
                    }
                    else
                    {
                        field[j, i] = new MineButton(field, MineButtonType.Clear, j, i);
                    }
                }
            }
        }
    }
}
