using PlasmaChemicalReactor.Models.INotifyModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaChemicalReactor.Models.Presets
{
    public class TokMode : INotifyModelBase.INotifyModelBase
    {
        private double contact;
        private double time;
        private double anodUp;
        private double anodDown;
        private int tok;

        #region Public Fields
        public double Contact { 
            get { return contact; } 
            set { contact = value; OnPropertyChanged(); } 
        }

        public double Time { 
            get { return time; } 
            set { time = value; OnPropertyChanged(); } 
        }

        public double AnodUp {  
            get { return anodUp; } 
            set { anodUp = value; OnPropertyChanged(); } 
        }

        public double AnodDown { 
            get { return anodDown; } 
            set { anodDown = value; OnPropertyChanged(); } 
        }

        public int Tok { 
            get { return tok; } 
            set {  tok = value; OnPropertyChanged(); } 
        }
        #endregion

        public TokMode(double contact, double time, double anodUp, double anodDown, int tok)
        {
            this.contact = contact;
            this.time = time;
            this.anodUp = anodUp;
            this.anodDown = anodDown;
            this.tok = tok;
        }

        public override string ToString()
        {
            return Tok.ToString() + " A";
        }
    }
}
