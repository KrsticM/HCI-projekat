using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace _4._2BVproject
{   
    [DataContract]
    public class TipVrste : INotifyPropertyChanged
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
        private string _ImagePath;

        [DataMember]
        private ObservableCollection<UgrozenaVrsta> _sadrzaneVrste; 

        public ObservableCollection<UgrozenaVrsta> SadrzaneVrste
        {
            get
            {
                return _sadrzaneVrste;
            }
            set
            {
                if (value != _sadrzaneVrste)
                {
                    _sadrzaneVrste = value;
                    OnPropertyChanged("SadrzaneVrste");
                }
            }
        }

        public string ImeVrste
        {
            get
            {
                return _Ime;
            }
            set
            {
                _Ime = value;
                OnPropertyChanged("Ime");
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

        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                if (value != _ImagePath)
                {
                    _ImagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        public BitmapImage Ikonica
        {
            get
            {
                Uri uri = new Uri(_ImagePath);
                BitmapImage bmpimg = null;
                try
                {
                    bmpimg = new BitmapImage(uri);
                }
                catch(Exception e)
                {

                }
                return bmpimg;
            }
        }

        public string Ime
        {
            get
            {
                return _Ime;
            }
        }
    }
}
