using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows;

namespace _4._2BVproject
{ 
    [DataContract]
    public class UgrozenaVrsta : INotifyPropertyChanged
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
        private string _Ime;
        [DataMember]
        private string _Opis;
        [DataMember]
        private int _StatusUgrozenosti;
        [DataMember]
        private int _OpasnoPoCoveka; // Da ili Ne
        [DataMember]
        private int _NaIUCNCrvenojListi;
        [DataMember]
        private int _UNaseljenomRegionu;
        [DataMember]
        private int _GodisnjiPrihod;
        [DataMember]
        private int _TuristickiStatus;
        [DataMember]
        private int _ValutaPrihoda;
        [DataMember]
        private string _DatumOtkrivanja;
        [DataMember]
        private string _imgUrl;
        [DataMember]
        private TipVrste _tipVrste;
        [DataMember]
        private ObservableCollection<Etiketa> _etikete;
        [DataMember]
        private Point _point;

        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                _etikete = value;
            }
        }

        public TipVrste TipVrste
        {
            get
            {
                return _tipVrste;
            }
            set
            {
                if (value != _tipVrste)
                {
                    _tipVrste = value;
                    OnPropertyChanged("TipVrste");
                }
            }
        }

        public Point Point
        {
            get
            {
                return _point;
            }
            set
            {
                if (value != _point)
                {
                    _point = value;
                    OnPropertyChanged("Point");
                }
            }
        }

        public string Ime
        {
            get
            {
                return _Ime;
            }
            set
            {
                if (value != _Ime)
                {
                    _Ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

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
        public int StatusUgrozenosti
        {
            get
            {
                return _StatusUgrozenosti;
            }
            set
            {
                if (value != _StatusUgrozenosti)
                {
                    _StatusUgrozenosti = value;
                    OnPropertyChanged("StatusUgrozenosti");
                }
            }
        }
        public int OpasnoPoCoveka
        {
            get
            {
                return _OpasnoPoCoveka;
            }
            set
            {
                if (value != _OpasnoPoCoveka)
                {
                    _OpasnoPoCoveka = value;
                    OnPropertyChanged("OpasnoPoCoveka");
                }
            }
        }
        public int NaIUCNCrvenojListi
        {
            get
            {
                return _NaIUCNCrvenojListi;
            }
            set
            {
                if (value != _NaIUCNCrvenojListi)
                {
                    _NaIUCNCrvenojListi = value;
                    OnPropertyChanged("NaIUCNCrvenojListi");
                }
            }
        }
        public int UNaseljenomRegionu
        {
            get
            {
                return _UNaseljenomRegionu;
            }
            set
            {
                if (value != _UNaseljenomRegionu)
                {
                    _UNaseljenomRegionu = value;
                    OnPropertyChanged("UNaseljenomRegionu");
                }
            }
        }        
        public string GodisnjiPrihod
        {
            get
            {
                return _GodisnjiPrihod.ToString(); 
            }
            set
            {
                if (!value.Equals(""))
                {
                    if (Int32.Parse(value) != _GodisnjiPrihod)
                    {
                        _GodisnjiPrihod = Int32.Parse(value);
                        OnPropertyChanged("GodisnjiPrihod");
                    }
                }
            }
        }
        public int TuristickiStatus
        {
            get
            {
                return _TuristickiStatus;
            }
            set
            {
                if (value != _TuristickiStatus)
                {
                    _TuristickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }
        public string DatumOtkrivanja
        {
            get
            {
                if(!_DatumOtkrivanja.Equals(""))
                {
                    string[] splitovano = _DatumOtkrivanja.Split(' ');
                    return splitovano[0];
                }
                else
                {
                    return "Nema";
                }
            }
            set
            {
                if (value != _DatumOtkrivanja)
                {
                    _DatumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }
        public int ValutaPrihoda
        {
            get
            {
                return _ValutaPrihoda;
            }
            set
            {
                if (value != _ValutaPrihoda)
                {
                    _ValutaPrihoda = value;
                    OnPropertyChanged("ValutaPrihoda");
                }
            }
        }
        public string imagePath
        {
            get
            {
                return _imgUrl;
            }
            set
            {
                if (value != _imgUrl)
                {
                    _imgUrl = value;
                    OnPropertyChanged("imagePath");
                    Ikonica = null;
                }
            }
        }
        public BitmapImage Ikonica
        {
            get
            {
                if(_imgUrl != null)
                {
                    BitmapImage bmpimg = null;
                    try
                    {
                        Uri uri = new Uri(_imgUrl);
                        bmpimg = new BitmapImage(uri);
                    }
                    catch (Exception e)
                    {

                    }                    
                    return bmpimg;
                }
                else
                {
                    Console.WriteLine("Nije pronadjena slika!");
                    return new BitmapImage(new Uri("images/kornjaca.png", UriKind.Relative)); ;
                }
            }
            set
            {
                OnPropertyChanged("Ikonica");
            }
        }
        private string _toolTip;
        public string TulTip
        {
            set
            {               
                Console.WriteLine("Ispaljen propery change");
                OnPropertyChanged("TulTip");
                _toolTip = null;
            }
            get
            {
                string str = "";
                foreach(Etiketa e in this.Etikete)
                {
                    str += "\n" + e.Oznaka; 
                }

                _toolTip = "Ime: " + Ime + "\n" + "Oznaka: " + Oznaka + "\n" + "Etikete: " + str;

                return _toolTip; 
            }
        }
    }
}