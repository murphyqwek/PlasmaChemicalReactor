using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PlasmaChemicalReactor.Models.Ports
{
    static class PortNamesList
    {
        public static ObservableCollection<string> AvailablePorts { get; private set; } = new ObservableCollection<string>();

        public const string NoAvaiblePortsString = "Нет доступных";

        public static bool IsAnyPortAvailable => AvailablePorts[0] != NoAvaiblePortsString;

        public static void UpdateAvailablePortList()
        {
            AvailablePorts.Clear();
            var serialPorts = SerialPort.GetPortNames();

            if (serialPorts.Length == 0)
            {
                AvailablePorts.Add(NoAvaiblePortsString);
                return;
            }

            foreach (var serialPort in serialPorts)
            {
                AvailablePorts.Add(serialPort);
            }
        }

        public static bool IsPortAvaible(string portName)
        {
            return AvailablePorts.Contains(portName);
        }

        public static string GetFirstAvailablePort()
        {
            if (AvailablePorts == null)
                return null;

            if (AvailablePorts.Count == 0)
                return null;

            if (AvailablePorts[0] == NoAvaiblePortsString)
                return null;

            return AvailablePorts[0];
        }
    }
}
