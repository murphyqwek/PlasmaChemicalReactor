using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager.PortListeners
{
    public interface IPortListener
    {
        public void StartListen();
        public void StopListen();
    }
}
