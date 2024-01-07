using PlasmaChemicalReactor.Exceptions;
using PlasmaChemicalReactor.Models.Ports.Port_Manager.PortListeners.Port_Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Ports.Port_Manager.PortListeners
{
    public static class PortFabric
    {
        public static Port CreatePort(ISerialModule serialConnector, SerialPort Port)
        {
            if (serialConnector == null)
                throw new ArgumentNullException();

            if (serialConnector is ISerialListener && serialConnector is ISerialWriter)
                return null;

            if (serialConnector is ISerialListener)
                return new OnlyListenPort(serialConnector, Port);

            if (serialConnector is ISerialWriter)
                return new OnlyWritePort(serialConnector, Port);

            throw new NoneTypeModule();
        }
    }
}
