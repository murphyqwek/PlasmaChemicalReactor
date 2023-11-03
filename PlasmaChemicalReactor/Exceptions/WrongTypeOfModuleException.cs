using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Exceptions
{
    public class WrongTypeOfModuleException : Exception
    {
        public WrongTypeOfModuleException() : base("Модуль не подходит для порта")
        {
        }
    }
}
