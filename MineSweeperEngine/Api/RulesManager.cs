using MinerByAlex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Api
{
    public abstract class RulesManager
    {
        protected Field _field;
        public void SetField(Field field)
        {
            _field = field;
        }
        public void Check()
        {
            if (IsEndOfGame())
            {
                if (IsVictory())
                {
                    Victory?.Invoke(this, null);
                }
                else
                {
                    GameOver?.Invoke(this, null);
                }
                return;
            }
            CheckCompleted?.Invoke(this, null);
        }

        public event EventHandler Victory;
        public event EventHandler GameOver;
        public event EventHandler CheckCompleted;
        public abstract bool IsEndOfGame();
        public abstract bool IsVictory();
    }
}
