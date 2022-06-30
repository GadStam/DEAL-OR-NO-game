using System;

namespace MALETINES.Models
{
    public class Maletin
    {
        private int _numMaletin;
        private int _importe;
        public bool _estado;

        public int numMaletin { 
            get { return _numMaletin;}
        }
        public int importe { 
            get { return _importe;}
        }
        public bool estado {
            get { return _estado;}
            set { _estado = value;}
        }

        public Maletin(int numMaletin, int importe)
        {
            _estado = false;
            _importe = importe;
            _numMaletin=numMaletin;
        }
    }
}