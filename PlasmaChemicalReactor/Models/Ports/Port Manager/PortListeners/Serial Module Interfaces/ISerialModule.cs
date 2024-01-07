using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Ports.Port_Manager
{
    public interface ISerialModule
    {
        public void SerialPortDisconnect();
        public void SerialPortConnect();
    }
}
