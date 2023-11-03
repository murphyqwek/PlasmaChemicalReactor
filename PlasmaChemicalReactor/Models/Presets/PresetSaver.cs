using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestMODBUS.Models.MessageBoxes;
using System.Windows.Documents;
using PlasmaChemicalReactor.Exceptions;

namespace PlasmaChemicalReactor.Models.Presets
{
    public static class PresetSaver
    {
        static public void SavePreset(Preset Preset, string FilePath)
        {
            if(Preset == null) 
                throw new ArgumentNullException(nameof(Preset));

            if (File.Exists(FilePath) && FileHelper.IsFileOpen(FilePath))
                throw new FileAlreadyOpenException(FilePath);

            string presetSerialaized = JsonConvert.SerializeObject(Preset);

            try
            {
                using (FileStream fstream = new FileStream(FilePath, FileMode.Create))
                {
                    byte[] buffer = Encoding.Default.GetBytes(presetSerialaized);
                    fstream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                throw new CannotSaveFileException("пресет");
            }
        }
    }
}
