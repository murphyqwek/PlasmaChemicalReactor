using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Exceptions
{
    public class CannotSaveFileException : Exception
    {
        public CannotSaveFileException(string? FileName) : base("Не удалось сохранить " + FileName)
        {
        }

        public CannotSaveFileException(string? FileName, string? FilePath) : base("Не удалось сохранить " + FileName + "по пути" + FilePath)
        {
        }
    }
}
