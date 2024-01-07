using PlasmaChemicalReactor.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Ports.Port_Manager.PortListeners.Port_Classes
{
    public class UniversalPort : Port, IPortListener
    {
        private Thread listenThread;
        private bool isListening = false;

        public UniversalPort(ISerialModule Module, SerialPort Port) : base(Module, Port)
        {
            if (Module is not ISerialWriter && Module is not ISerialListener)
                throw new WrongTypeOfModuleException();

            ISerialWriter writerModule = module as ISerialWriter;

            writerModule.WriteStringDelegate += WriteString;
            writerModule.WriteBytesDelegate += WriteBytes;

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

        public void StartListen()
        {
            isListening = true;

            listenThread = new Thread(Listen);
            listenThread.Start();
        }

        public void StopListen()
        {
            isListening = false;
        }

        private void Listen()
        {
            ISerialListener moduleListener = module as ISerialListener;
            try
            {
                while (module != null && isListening && port.IsOpen)
                {
                    string data = port.ReadLine();
                    moduleListener.SerialDataHandler(data);
                }
            }
            catch (IOException)
            {
                PortManager.DisconnectPort(port.PortName);
                PortNamesList.UpdateAvailablePortList();
            }
        }
    }
}
