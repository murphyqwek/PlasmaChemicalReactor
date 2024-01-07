using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Ports.Port_Manager
{
    public interface ISerialListener
    {
        public void SerialDataHandler(string data);
    }
}
