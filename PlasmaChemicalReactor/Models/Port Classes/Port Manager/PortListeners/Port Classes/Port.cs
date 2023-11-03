using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager.PortListeners.Port_Classes
{
    public abstract class Port
    {
        public bool IsOpen => port.IsOpen;
        public ISerialModule Module => module;
        public string PortName => port.PortName;

        protected ISerialModule module;
        protected SerialPort port;

        public Port(ISerialModule Module, SerialPort Port)
        {
            if (Module == null)
                throw new ArgumentNullException();
            if (Port == null)
                throw new ArgumentNullException();

            module = Module;
            port = Port;
        }

        public void Close()
        {
            port.Close();
        }

        public void Disconnect()
        {
            port.Close();
            module.SerialPortDisconnect();
        }

        public void Open()
        {
            port.Open();
        }
    }
}
