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
        private static Dictionary<string, PortListener> PortListeners = new Dictionary<string, PortListener>();
        
        public static bool SignClassToSerialPort(ISerialReadable Object, string PortName, int PortSpeed)
        {
            if(Object == null) 
                throw new ArgumentNullException(nameof(Object));
            if(PortName == null)
                throw new ArgumentNullException(nameof(PortName));

            PortNamesList.UpdateAvailablePortList();
            if(!PortNamesList.IsPortAvaible(PortName))
                return false;

            PortListener portListener = new PortListener(Object, PortName, PortSpeed);

            ClosePortListnenerContainsSerialReadableObject(Object);
                
            PortListeners.Add(PortName, portListener);

            return true;
        }

        static private void ClosePortListnenerContainsSerialReadableObject(ISerialReadable SerialReadableObejct)
        {
            foreach(var PortListener in PortListeners.Values)
            {
                if(PortListener.SerialReadableObject == SerialReadableObejct)
                {
                    PortListener.StopListen();
                    ClosePort(PortListener.PortName);
                }
            }
        }

        public static void ClosePort(string PortName)
        {
            PortListener portListener;

            if (!PortListeners.TryGetValue(PortName, out portListener))
                return;

            portListener.Close();

            PortListeners.Remove(PortName);
        }

        public static void RunAllPortListeners()
        {
            foreach(var portListener in PortListeners.Values)
            {
                portListener.StartListen();
            }
        }

        public static void RunPortListener(string PortName)
        {
            if(PortListeners.TryGetValue(PortName, out PortListener portListener))
            {
                portListener.StartListen();
            }
        } 

        public static void StopAllPortListeners()
        {
            foreach (var portListener in PortListeners.Values)
            {
                portListener.StopListen();
            }
        }

        public static void StopPortListener(string PortName)
        {
            if (PortListeners.TryGetValue(PortName, out PortListener portListener))
            {
                portListener.StopListen();
            }
        }
    }
}
