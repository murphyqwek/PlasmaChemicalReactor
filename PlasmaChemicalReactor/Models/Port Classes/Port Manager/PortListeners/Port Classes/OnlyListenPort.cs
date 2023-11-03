using PlasmaChemicalReactor.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager.PortListeners.Port_Classes
{
    public class OnlyListenPort : Port, IPortListener
    {
        private Thread listenThread;
        private bool isListening = false;

        public OnlyListenPort(ISerialModule Module, SerialPort Port) : base(Module, Port)
        {
            if (Module is not ISerialListener)
                throw new WrongTypeOfModuleException();

            module = Module;
            port = Port;
            module.SerialPortConnect();
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
