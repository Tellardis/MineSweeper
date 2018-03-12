using MinerByAlex.Api;
using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlexForms
{
    class ConfigItem : IConfigItem
    {
        public ConfigItem(FieldConfig f, string n)
        {
            FieldConfig = f;
            Name = n;
        }
        public FieldConfig FieldConfig { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
