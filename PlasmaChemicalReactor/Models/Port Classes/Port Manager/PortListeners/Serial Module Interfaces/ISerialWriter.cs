using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager
{
    public interface ISerialWriter
    {
        public delegate bool WriteSerialString(string data, object sender);
        public delegate bool WriteSerialBytes(byte[] data, object sender);

        public WriteSerialString WriteStringDelegate { get; set; }
        public WriteSerialBytes WriteBytesDelegate { get; set; }
    }
}
