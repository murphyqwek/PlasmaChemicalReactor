using PlasmaChemicalReactor.Models.Port_Classes.Port_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Buses
{
    public class Bus : ISerialReadable
    {
        public ISerialReadable.WriteSerialBytes WriteBytes { get; set; }
        public ISerialReadable.WriteSerialString WriteString { get; set; }

        private Dictionary<string, ISerialReadable> modules = new Dictionary<string, ISerialReadable>();

        public Bus(Dictionary<string, ISerialReadable> Modules) 
        {
            if (Modules != null)
                modules = Modules;
        }

        private string getAddress(string data)
        {
            throw new NotImplementedException();
        }

        private string getPureData(string data)
        {
            throw new NotImplementedException();
        }

        public void SerialDataHandler(string data)
        {
            string address = getAddress(data);
            string pureData = getPureData(data);
            if(modules.TryGetValue(address, out var module))
            {
                module.SerialDataHandler(pureData);
            }
        }

        public bool AddModule(string adress, ISerialReadable module)
        {
            return modules.TryAdd(adress, module);
        }

        public void SerialPortDisconnect()
        {
            throw new NotImplementedException();
        }
    }
}
