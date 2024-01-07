using PlasmaChemicalReactor.Exceptions;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Ports.Port_Manager.PortListeners.Port_Classes
{
    internal class OnlyWritePort : Port
    {
        public OnlyWritePort(ISerialModule SerialWriter, SerialPort Port) : base(SerialWriter, Port)
        {
            if (SerialWriter is not ISerialWriter)
                throw new WrongTypeOfModuleException();

            ISerialWriter writerModule = module as ISerialWriter;

            writerModule.WriteStringDelegate += WriteString;
            writerModule.WriteBytesDelegate += WriteBytes;
            //writerModule.SetPlasmaChemicalReactor.Models.Port_Classes.Port_Manager.ISerialWriter.WriteBytes(writerModule.GetPlasmaChemicalReactor.Models.Port_Classes.Port_Manager.ISerialWriter.WriteBytes() + WriteBytes);

            module.SerialPortConnect();
        }

        private bool WriteString(string data, object sender)
        {
            if (port == null)
                return false;
            if (!port.IsOpen)
                return false;

            try
            {
                port.Write(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool WriteBytes(byte[] data, object sender)
        {
            if (port == null)
                return false;
            if (!port.IsOpen)
                return false;

            try
            {
                port.Write(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
