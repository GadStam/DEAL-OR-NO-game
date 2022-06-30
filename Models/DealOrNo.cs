using System;
using System.Collections.Generic;

namespace MALETINES.Models
{
    public class DealOrNo{
        public static List<int> ImportesDescartados = new List<int>();

        private static Maletin[] _maletines;

        public static Maletin _maletinElegido;

        private static int _jugadas;

        private static int _turno;

        private static int[] _importes;

        private static double _oferta;

        private static int _acumular=0;

        private static int _cantMaletines=0;

        private static int _acumularBanca=0;

        public static void IniciarJuego(int maletinEle){
            ImportesDescartados.Clear();
            _acumularBanca=0;
            _jugadas=6;
            _turno=6;
            _maletines = new Maletin[26];
            _importes=new int [26] {1,5,10,15,25,50,75,100,200,300,400,500,750,1000,5000,10000,25000,50000,75000,100000,200000,300000,400000,500000,750000,1000000};
            for(int i=0;i<26;i++)
            {
                Random rnd=new Random();
                int nro = rnd.Next(0,26);
                while (_importes[nro]==-1)
                {
                    nro = rnd.Next(0,26);
                }
                Maletin MaletinTemporal = new Maletin(i,_importes[nro]);
                _maletines[i] = MaletinTemporal;
                _importes[nro] = -1;
            }
            _maletinElegido=_maletines[maletinEle];
            _maletinElegido.estado=true;
        }
    

        public static int AbrirMaletin(int Numero){
            if(_maletines[Numero].estado==false){
                _maletines[Numero].estado=true;
                _jugadas--;
                ImportesDescartados.Add(_maletines[Numero].importe);
                return _maletines[Numero].importe;
            }else{
                return -1;
            }
        }

        public static int JugadasRestantes(){
            return _jugadas;
        }

        public static double OfertaBanca(){
            _cantMaletines=0;
            _oferta=0;
            _acumular=0;
            if(_jugadas==0){
                for(int j=0;j<26;j++){
                    if(_maletines[j].estado==false){
                        _acumular=_maletines[j].importe + _acumular;
                        _cantMaletines++;
                    }
                }
                _acumularBanca++;
                _oferta=_acumular/_cantMaletines*0.85;
                return _oferta;
            }else{
                return -1;
            }
        }

        public static int DecisionOferta(string decision){
            if(decision=="true"){
                return _maletinElegido.importe;
            }else{
                _turno--;
                if(_turno<=0){
                    _jugadas=1;
                }else{
                    _jugadas=_turno;
                }
                return -1;
            }
        }
        public static Maletin[] DevolverListaMaletines(){
            return _maletines;
        }

        public static int[] ListaImportes(){
            _importes=new int [26] {1,5,10,15,25,50,75,100,200,300,400,500,750,1000,5000,10000,25000,50000,75000,100000,200000,300000,400000,500000,750000,1000000};
            return _importes;
        }

        public static int DevolverOf(){
            return _acumularBanca;
        }

        public static int DevolverImporteMaletinEle(){
            return _maletinElegido.importe;
        }
    }
}
