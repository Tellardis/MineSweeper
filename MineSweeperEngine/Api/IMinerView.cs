using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Api
{
    public interface IMinerView
    {
        void FieldRefresh();
        void Victory();
        void GameOver();
        void OnNewGame(object sender, EventArgs e);
        void StartGame();
        void SetPresenter(MinerPresenter minerPresenter);
        void FillNearMineCount();
    }
}
