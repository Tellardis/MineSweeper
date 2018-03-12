using MinerByAlex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Api
{
    public interface IConfigItem
    {
        FieldConfig FieldConfig { get; set; }
    }
}
