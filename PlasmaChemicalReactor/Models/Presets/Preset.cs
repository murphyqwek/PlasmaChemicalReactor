using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Presets
{
    public class Preset
    {
        public ObservableCollection<Preset> Presets { get; set; } = new ObservableCollection<Preset>();

        [JsonConstructor]
        public Preset(ObservableCollection<Preset> presets) 
        {
            Presets = presets;
        }
    }
}
