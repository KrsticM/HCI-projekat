using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace _4._2BVproject
{
    [DataContract]
    public class Etiketa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        [DataMember]
        private string _Oznaka;

        [DataMember]
        private int _Boja; // index u ComboxBox-u

        [DataMember]
        private string _Opis;
        
        public int Boja
        {
            get
            {
                return _Boja;
            }
            set
            {
                if (value != _Boja)
                {
                    _Boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        public String getBoja
        {
            get
            {
                if (_Boja == 0) return "Crna";
                else if (_Boja == 1) return "Žuta";
                else if (_Boja == 2) return "Narandžasta";
                else if (_Boja == 3) return "Zelena";
                else if (_Boja == 4) return "Plava";
                else if (_Boja == 5) return "Ljubičasta";
                else if (_Boja == 6) return "Bela";
                else return "Nepoznata";
            }
            set
            {

            }
        }

        [Browsable(false)]
        public string Oznaka
        {
            get
            {
                return _Oznaka;
            }
            set
            {
                if (value != _Oznaka)
                {
                    _Oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Opis
        {
            get
            {
                return _Opis;
            }
            set
            {
                if (value != _Opis)
                {
                    _Opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public ObservableCollection<String> Boje
        {
            get
            {
                ObservableCollection<String> _boje = new ObservableCollection<String>();
                _boje.Add("Crna");
                _boje.Add("Žuta");
                _boje.Add("Narandžasta");
                _boje.Add("Zelena");
                _boje.Add("Plava");
                _boje.Add("Ljubičasta");
                _boje.Add("Bela");  
                return _boje;
            }
        }
    }
}
