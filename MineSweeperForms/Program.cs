using MinerByAlex;
using MinerByAlex.Api;
using MinerByAlex.VanilaGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerByAlexForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new MinerPresenter();
            VanilaGame vgame = new VanilaGame();
            presenter.ConnectGame(new ConfigItem(vgame.EasyConfig, "Легкий"));
            presenter.ConnectGame(new ConfigItem(vgame.NormalConfig, "Средний"));
            presenter.ConnectGame(new ConfigItem(vgame.HardConfig, "Тяжелый"));
            presenter.ConnectGame(new ConfigItem(vgame.AbsoluteConfig, "Абсолютный"));
            //TestCommnet
            presenter.SetView(new MainForm());
            presenter.StartGame();
        }
    }
}
