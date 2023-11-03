using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models
{
    public static class FileHelper
    {
        static public bool IsFileOpen(string FilePath)
        {
            if (!File.Exists(FilePath))
                return false;

            StreamReader reader;
            try
            {
                reader = new StreamReader(FilePath);
                reader.Close();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
