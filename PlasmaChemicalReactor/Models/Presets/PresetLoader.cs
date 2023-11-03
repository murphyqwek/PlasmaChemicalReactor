using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestMODBUS.Models.MessageBoxes;

namespace PlasmaChemicalReactor.Models.Presets
{
    public static class PresetLoader
    {
        public static Preset LoadPreset(string FilePath)
        {
            try
            {
                string presetSerialized = GetPresetText(FilePath);
                return JsonConvert.DeserializeObject<Preset>(presetSerialized);
            }
            catch  
            {
                return null;
            }
        }

        private static string GetPresetText(string FilePath)
        {
            using (FileStream fstream = new FileStream(FilePath, FileMode.Open))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                return Encoding.Default.GetString(buffer);
            }
        }
    }
}
