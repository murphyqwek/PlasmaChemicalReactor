using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestMODBUS.Models.MessageBoxes;

namespace PlasmaChemicalReactor.Models.Presets
{
    public static class PresetSave
    {
        static public bool SavePreset(Preset Preset, string FilePath)
        {
            if(Preset == null) 
                throw new ArgumentNullException(nameof(Preset));

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
                ErrorMessageBox.Show("Не удалось сохранить пресет");
                return false;
            }

            return true;
        }
    }
}
