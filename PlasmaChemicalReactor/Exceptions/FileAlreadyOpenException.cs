using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Exceptions
{
    public class FileAlreadyOpenException : Exception
    {
        public FileAlreadyOpenException(string? FilePath) : base("Файл по пути " + FilePath + " открыт в другой программе")
        {
        }
    }
}
