using PlasmaChemicalReactor.Models.Ports.Port_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Buses
{
    public class Bus : ISerialModule, ISerialListener, ISerialWriter
    {
        public ISerialWriter.WriteSerialString WriteStringDelegate { get; set; }
        public ISerialWriter.WriteSerialBytes WriteBytesDelegate { get; set; }


        private Dictionary<string, ISerialModule> modules = new Dictionary<string, ISerialModule>();

        public Bus(Dictionary<string, ISerialModule> Modules) 
        {
            if (Modules != null)
                modules = Modules;

            foreach(var Module in modules.Values)
            {
                if(Module is ISerialWriter)
                {
                    ((ISerialWriter)Module).WriteBytesDelegate += WriteModuleBytesData;
                    ((ISerialWriter)Module).WriteStringDelegate += WriteModuleStringData;
                }
            }
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
            ISerialModule module;

            if (!modules.TryGetValue(address, out module))
                return;

            if(module == null)
            {
                modules.Remove(address);
                return;
            }

            if (module is not ISerialListener)
                return;

            string pureData = getPureData(data);

            ISerialListener moduleListener = (ISerialListener)module;
            moduleListener.SerialDataHandler(pureData);
        }

        public bool AddModule(string address, ISerialModule module)
        {
            if(!modules.TryAdd(address, module))
                return false;

            ((ISerialWriter)module).WriteBytesDelegate += WriteModuleBytesData;
            ((ISerialWriter)module).WriteStringDelegate += WriteModuleStringData;

            return true;
        }

        public void SerialPortDisconnect()
        {
            throw new NotImplementedException();
        }

        public void SerialPortConnect()
        {
            throw new NotImplementedException();
        }

        private void AddAddress(ref string data, ISerialModule module)
        {
            throw new NotImplementedException();
        }

        private void AddAddress(ref byte[] data, ISerialModule module)
        {
            throw new NotImplementedException();
        }

        private bool WriteModuleStringData(string data, object sender)
        {
            AddAddress(ref data, (ISerialModule)sender);
            return WriteStringDelegate(data, this);
        }

        private bool WriteModuleBytesData(byte[] data, object sender)
        {
            AddAddress(ref data, (ISerialModule)sender);
            return WriteBytesDelegate(data, this);
        }

    }
}
