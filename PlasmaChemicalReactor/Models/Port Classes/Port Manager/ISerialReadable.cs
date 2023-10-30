using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager
{
    public interface ISerialReadable
    {
        public delegate bool WriteSerialString(string data);
        public delegate bool WriteSerialBytes(byte[] data);

        public void SerialDataHandler(string data);
        public void SerialPortDisconnect();

        public WriteSerialBytes WriteBytes { get; set; }
        public WriteSerialString WriteString { get; set; }
    }
}
