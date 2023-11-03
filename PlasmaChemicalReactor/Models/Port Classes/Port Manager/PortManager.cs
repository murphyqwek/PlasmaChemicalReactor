using PlasmaChemicalReactor.Models.Port_Classes.Port_Manager.PortListeners;
using PlasmaChemicalReactor.Models.Port_Classes.Port_Manager.PortListeners.Port_Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager
{
    public static class PortManager
    {
        private static Dictionary<string, Port> PortListeners = new Dictionary<string, Port>();
        
        public static bool SignClassToSerialPort(ISerialModule Module, string PortName, int PortSpeed)
        {
            if(Module == null) 
                throw new ArgumentNullException(nameof(Module));
            if(PortName == null)
                throw new ArgumentNullException(nameof(PortName));

            PortNamesList.UpdateAvailablePortList();
            if(!PortNamesList.IsPortAvaible(PortName))
                return false;

            var Port = PortFabric.CreatePort(Module, new SerialPort(PortName, PortSpeed));

            DisconnectPortByModule(Module);
                
            PortListeners.Add(PortName, Port);

            return true;
        }

        static private void DisconnectPortByModule(ISerialModule Module)
        {
            foreach(var Port in PortListeners.Values)
            {
                if(Port.Module == Module)
                {
                    DisconnectPort(Port.PortName);
                    break;
                }
            }
        }

        public static void DisconnectPort(string PortName)
        {
            Port portListener;

            if (!PortListeners.TryGetValue(PortName, out portListener))
                return;

            portListener.Disconnect();

            PortListeners.Remove(PortName);
        }

        public static void RunAllPortListeners()
        {
            foreach(var port in PortListeners.Values)
            {
                var portListener = (IPortListener)port;
                portListener.StartListen();
            }
        }

        public static void RunPortListener(string PortName)
        {
            if(PortListeners.TryGetValue(PortName, out var port))
            {
                var portListener = (IPortListener)port;
                portListener.StartListen();
            }
        } 

        public static void StopAllPortListeners()
        {
            foreach (var port in PortListeners.Values)
            {
                var portListener = (IPortListener)port;
                portListener.StopListen();
            }
        }

        public static void StopPortListener(string PortName)
        {
            if (PortListeners.TryGetValue(PortName, out var port))
            {
                if(port is IPortListener)
                {
                    var portListener = (IPortListener)port;
                    portListener.StopListen();
                }
            }
        }
    }
}
