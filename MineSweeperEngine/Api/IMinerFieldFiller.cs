using MinerByAlex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerByAlex.Api
{
    public interface IMinerFieldFiller
    {
        void FillField(Field field, int startX, int startY);
    }
}
