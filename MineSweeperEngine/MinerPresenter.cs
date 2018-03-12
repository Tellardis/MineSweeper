using MinerByAlex.Api;
using MinerByAlex.Core;
using MinerByAlex.Model;
using MinerByAlex.VanilaGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex
{
    public class MinerPresenter
    {
        public MinerPresenter()
        {
            _configItems = new List<IConfigItem>();
        }
        private IMinerView _view;
        private Field _field;
        private RulesManager _victoryManager;
        private IMinerFieldFiller _minerFieldFiller;
        private List<IConfigItem> _configItems;
        public IConfigItem[] ConfigItems
        {
            get
            {
                return _configItems.ToArray();
            }
        }
        public void ConnectGame(IConfigItem item)
        {
            _configItems.Add(item);
        }


        private bool _isNewGame = false;
        public int SizeX { get; private set; }
        public void StartGame()
        {
            _view.StartGame();
        }
        public int SizeY { get; private set; }
        public int MineCount { get; private set; }
        public void SetView(IMinerView view)
        {
            _view = view;
            _view.SetPresenter(this);

            NewGameStart += _view.OnNewGame;
        }
        public void NewGame(FieldConfig fieldConfig)
        {
            if (_victoryManager != null && _victoryManager == fieldConfig.VictoryManager)
                Unsubscribe();

            _victoryManager = fieldConfig.VictoryManager;
            _minerFieldFiller = fieldConfig.FieldFiller;

            SizeX = fieldConfig.SizeX;
            SizeY = fieldConfig.SizeY;

            MineCount = fieldConfig.MinesCount;
            _field = new Field(fieldConfig);
            _victoryManager.SetField(_field);
            _field.MinesStateChanged += VictoryManager_CheckCompleted;
            _victoryManager.GameOver += VictoryManager_GameOver;
            _victoryManager.Victory += VictoryManager_Victory;
            _isNewGame = true;
            NewGameStart?.Invoke(this, null);
        }

        public FieldConfig NewCustomGame(FieldConfig fieldConfig, int SizeX, int SizeY, int MineCount)
        {
            var fieldConfigCustom = (FieldConfig)fieldConfig.Clone();
            fieldConfigCustom.SizeX = SizeX;
            fieldConfigCustom.SizeY = SizeY;
            fieldConfigCustom.MinesCount = MineCount;
            NewGame(fieldConfigCustom);
            return fieldConfigCustom;
        }
        private void Unsubscribe()
        {
            _field.MinesStateChanged -= VictoryManager_CheckCompleted;
            _victoryManager.GameOver -= VictoryManager_GameOver;
            _victoryManager.Victory -= VictoryManager_Victory;
        }
        private void VictoryManager_Victory(object sender, EventArgs e)
        {
            Unsubscribe();
            _view.Victory();
        }
        private void VictoryManager_GameOver(object sender, EventArgs e)
        {

            Unsubscribe();
            _view.GameOver();
        }
        private void VictoryManager_CheckCompleted(object sender, EventArgs e)
        {
            _view.FieldRefresh();
        }
        public void MarkMine(int x, int y, MineButtonState state)
        {
            if (_field[x, y] == null) return;
            _field[x, y].Mark(state);
        }
        public MineButtonState GetCellState(int posX, int posY)
        {
            if (_field[posX, posY] == null) return MineButtonState.UnMarked;
            return _field[posX, posY].State;
        }
        public int GetCellNearMinesCount(int x, int y)
        {
            if (_field[x, y] == null) return -1;
            return _field[x, y].MineNear;
        }
        public event EventHandler NewGameStart;
        public void MarkAllMines()
        {
            _field.MarkAllMines();
            _view.FieldRefresh();
        }
        public void ExplodeAllMines()
        {
            _field.ExplodeAllMines();
            _view.FieldRefresh();
        }
        public void FastOpenCells(int x, int y)
        {
            _field.FastOpenCells(x, y);
        }
        public void DetonaiteMine(int x, int y)
        {

            if (_isNewGame)
            {
                _field.FillField(x, y);
                _view.FillNearMineCount();
                _isNewGame = false;
            }
            _field[x, y].Detonate();
        }
    }
}
