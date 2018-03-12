using MinerByAlex.Api;
using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.VanilaGame
{
    public class VanilaGame
    {
        public FieldConfig GetFieldConfigVanilaTemplate
        {
            get
            {
                var victoryManager = new StandartRulesManager();
                var minerFieldFiller = new StandartFieldFiller();
                var fieldConfig = new FieldConfig();
                fieldConfig.FieldFiller = minerFieldFiller;
                fieldConfig.VictoryManager = victoryManager;
                return fieldConfig;
            }
        }
        public FieldConfig EasyConfig
        {
            get
            {
                var fieldConfig = GetFieldConfigVanilaTemplate;
                fieldConfig.SizeX = 9;
                fieldConfig.SizeY = 9;
                fieldConfig.MinesCount = 10;
                return fieldConfig;
            }
        }

        public FieldConfig AbsoluteConfig
        {
            get
            {
                var fieldConfig = GetFieldConfigVanilaTemplate;
                fieldConfig.SizeX = 16;
                fieldConfig.SizeY = 10;
                fieldConfig.MinesCount = 15;
                return fieldConfig;
            }
        }

        public FieldConfig NormalConfig
        {
            get
            {
                var fieldConfig = GetFieldConfigVanilaTemplate;
                fieldConfig.SizeX = 16;
                fieldConfig.SizeY = 16;
                fieldConfig.MinesCount = 40;
                return fieldConfig;
            }
        }

        public FieldConfig HardConfig
        {
            get
            {
                var fieldConfig = GetFieldConfigVanilaTemplate;
                fieldConfig.SizeX = 30;
                fieldConfig.SizeY = 16;
                fieldConfig.MinesCount = 99;
                return fieldConfig;
            }
        }

    }
}
