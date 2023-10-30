using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Port_Classes.Port_Manager
{
    public class PortListener
    {
        private SerialPort port;
        private ISerialReadable Object;
        bool IsListening = false;

        public bool IsOpen { get => port.IsOpen; }
        public ISerialReadable SerialReadableObject { get => Object; }
        public string PortName { get => port.PortName; }

        public PortListener(ISerialReadable Object, SerialPort port)
        {
            this.port = port;
            this.Object = Object;

            SignToDelegates();
            port.Open();
        }

        public PortListener(ISerialReadable Object, string PortName, int PortSpeed) 
        {
            port = new SerialPort(PortName, PortSpeed);
            this.Object = Object;

            SignToDelegates();
            port.Open();
        }

        private void SignToDelegates()
        {
            this.Object.WriteBytes += WriteBytes;
            this.Object.WriteString += WriteString;
        }

        public void StopListen()
        {
            IsListening = false;
        }

        public void StartListen()
        {
            IsListening = true;
            Thread listenningThread = new Thread(Listen);
            listenningThread.Start();
        }

        public void Close()
        {
            StopListen();
            port.Close();
        }

        private void Listen()
        {
            try
            {
                while(Object != null && IsListening && port.IsOpen)
                {
                    string data = port.ReadLine();
                    Object.SerialDataHandler(data);
                }
            }
            catch(IOException)
            {
                PortManager.ClosePort(port.PortName);
                PortNamesList.UpdateAvailablePortList();
            }

            if(!port.IsOpen)
                Object?.SerialPortDisconnect();
        }

        private bool WriteBytes(byte[] data)
        {
            if (port == null)
                return false;
            if (!port.IsOpen)
                return false;

            try
            {
                port.Write(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool WriteString(string data)
        {
            if (port == null)
                return false;
            if (!port.IsOpen)
                return false;

            try
            {
                port.Write(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
