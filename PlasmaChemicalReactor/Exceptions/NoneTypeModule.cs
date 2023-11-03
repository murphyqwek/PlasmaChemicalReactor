using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Exceptions
{
    public class NoneTypeModule : Exception
    {
        public NoneTypeModule() : base("Модуль не имеет тип")
        {
        }
    }
}
