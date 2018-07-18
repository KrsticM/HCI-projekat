using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace _4._2BVproject
{
    // PROZOR ZA DODAVANJE NOVE UGROZENE VRSTE
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public static UgrozenaVrsta obradjivana;

        private bool mojaSlika = false;
        private MainWindow mains;

        // Za onemogucavanje dodavanja
        private bool oznakaOK = false;
        private bool imeOK = false;
        private bool prihodOK = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private Image _MyImage;
        private string _path;
        public Window1() // KONSTRUKTOR
        {
            this.DataContext = this;
            this.TipoviVrsta = MainWindow.TipoviVrsta;
            this.Etikete = MainWindow.Etikete;
            this.ugrozeneVrste = MainWindow.ugrozeneVrste;
            NekorisceneEtikete = new ObservableCollection<Etiketa>();
            IskorisceneEtikete = new ObservableCollection<Etiketa>();

            foreach(Etiketa et in MainWindow.Etikete)
            {
                NekorisceneEtikete.Add(et);
            }

            InitializeComponent();
            tip.SelectedIndex = 0;
            tip_SelectionChanged(null, null);
            PotvrdiDugme.IsEnabled = false;

            TipVrste temp = (TipVrste)tip.SelectedItem;
            Path = temp.ImagePath;

            obradjivana = null;
        }
        public Window1(UgrozenaVrsta uv, MainWindow mw)
        {
            mains = mw;
            this.DataContext = this;
            this.TipoviVrsta = MainWindow.TipoviVrsta;
            this.Etikete = MainWindow.Etikete;
            this.ugrozeneVrste = MainWindow.ugrozeneVrste;
            NekorisceneEtikete = new ObservableCollection<Etiketa>();

            IskorisceneEtikete = uv.Etikete;

            foreach (Etiketa et in MainWindow.Etikete)
            {
                NekorisceneEtikete.Add(et);
            }


            foreach(Etiketa et in uv.Etikete)
            {
                NekorisceneEtikete.Remove(et);

            }

            //Console.WriteLine("Obradjivana postavljena");
            obradjivana = uv;

            InitializeComponent();
            

            // Preuzimanje parametara od ugrozene vrste
            xOznaka.Text = uv.Oznaka;
            xIme.Text = uv.Ime;
            xOpis.Text = uv.Opis;
            xStatus.SelectedIndex = uv.StatusUgrozenosti;
            if(uv.OpasnoPoCoveka == 1) // DA
            {
                opasnoPoCovekaDA.IsChecked = true;
            }
            else if(uv.OpasnoPoCoveka == -1) // NE
            {
                opasnoPoCovekaNE.IsChecked = true;
            }

            if(uv.NaIUCNCrvenojListi == 1) // DA
            {
                crvenoDA.IsChecked = true;
            }
            else
            {
                crvenoNE.IsChecked = true;
            }

            if(uv.UNaseljenomRegionu == 1)
            {
                naseljenoDA.IsChecked = true;
            }
            else
            {
                naseljenoNE.IsChecked = true;
            }
            xGodisnje.Text = uv.GodisnjiPrihod;
            xTurista.SelectedIndex = uv.TuristickiStatus;
            xDatum.SelectedDate = DateTime.Parse(uv.DatumOtkrivanja);
            xValuta.SelectedIndex = uv.ValutaPrihoda;
            Path = uv.imagePath;

            imgPhoto.Source = new BitmapImage(new Uri(Path));
            mojaSlika = true;

            tip_SelectionChanged(null, null);
            PotvrdiDugme.IsEnabled = true;
            tip.SelectedItem = uv.TipVrste;
            this.Title = "Izmena vrste";
        }



        public Image MyImage
        {
            get
            {
                return _MyImage;
            }
            set
            {
                _MyImage = value;
                OnPropertyChanged("MyImage_Changed");
            }
        }
        private double _prihod;
        public double Prihod
        {
            get
            {
                return _prihod;
            }
            set
            {
                if (value != _prihod)
                {
                    _prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged("Path");
                }
            }
        }
        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        private ObservableCollection<UgrozenaVrsta> myVrste = new ObservableCollection<UgrozenaVrsta>();
        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int opasnost;
            if (opasnoPoCovekaDA.IsChecked == true)
            {
                opasnost = 1;
            }
            else
            {
                opasnost = -1;
            }

            int crveno;
            if (crvenoDA.IsChecked == true)
            {
                crveno = 1;
            }
            else
            {
                crveno = -1;
            }

            int naseljeno;
            if(naseljenoDA.IsChecked == true)
            {
                naseljeno = 1;
            }
            else
            {
                naseljeno = -1;
            }

            if (obradjivana == null)
            {
                
                UgrozenaVrsta temp = new UgrozenaVrsta
                {
                    Ime = xIme.Text,
                    Oznaka = xOznaka.Text,
                    Opis = xOpis.Text,
                    StatusUgrozenosti = xStatus.SelectedIndex,
                    OpasnoPoCoveka = opasnost,


                    NaIUCNCrvenojListi = crveno,
                    UNaseljenomRegionu = naseljeno,
                    GodisnjiPrihod = xGodisnje.Text,
                    TuristickiStatus = xTurista.SelectedIndex,
                    DatumOtkrivanja = xDatum.ToString(),
                    ValutaPrihoda = xValuta.SelectedIndex,
                    imagePath = Path,
                    Etikete = IskorisceneEtikete,
                    TipVrste = (TipVrste)tip.SelectedItem
                };
                TipVrste dodat = (TipVrste)tip.SelectedItem;
                dodat.SadrzaneVrste.Add(temp);
                MainWindow.ugrozeneVrste.Add(temp);

            }
            else // Ako se vrsi izmena neke
            {


                obradjivana.Ime = xIme.Text;
                obradjivana.Oznaka = xOznaka.Text;
                obradjivana.Opis = xOpis.Text;
                obradjivana.StatusUgrozenosti = xStatus.SelectedIndex;
                obradjivana.OpasnoPoCoveka = opasnost;
                obradjivana.NaIUCNCrvenojListi = crveno;
                obradjivana.UNaseljenomRegionu = naseljeno; 
                obradjivana.GodisnjiPrihod = xGodisnje.Text;
                obradjivana.TuristickiStatus = xTurista.SelectedIndex;
                obradjivana.DatumOtkrivanja = xDatum.ToString();
                obradjivana.ValutaPrihoda = xValuta.SelectedIndex;
                obradjivana.imagePath = Path;
                obradjivana.Etikete = IskorisceneEtikete;
                obradjivana.TipVrste.SadrzaneVrste.Remove(obradjivana);
                obradjivana.TipVrste = (TipVrste)tip.SelectedItem;
                obradjivana.TipVrste.SadrzaneVrste.Add(obradjivana);
                mains.xTree.ItemsSource = null;
                mains.xTree.ItemsSource = TipoviVrsta;
                // Dodato za tultip 
                obradjivana.TulTip = "aa";

            }
            this.Close();
        }



        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void DodajUKoriscene_Click(object sender, RoutedEventArgs e)
        {
            if (NeupotrebljeneEtikete.SelectedValue != null)
            {
                Etiketa et = (Etiketa)NeupotrebljeneEtikete.SelectedValue;
                IskorisceneEtikete.Add(et);
                NekorisceneEtikete.Remove(et);
            }
        }
        private void DodajUNeiskoriscene_Click(object sender, RoutedEventArgs e)
        {
            if (UpotrebljeneEtikete.SelectedValue != null)
            {
                Etiketa et = (Etiketa)UpotrebljeneEtikete.SelectedValue;
                NekorisceneEtikete.Add(et);
                IskorisceneEtikete.Remove(et);
            }
        }
        private void btnOdaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Odaberite sliku";
            op.Filter = "Podržani formati|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                Path = op.FileName;
                mojaSlika = true;
            }
        }
        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            if(tip.SelectedValue != null)
            {
                TipVrste tipa = (TipVrste)tip.SelectedValue;
                imgPhoto.Source = tipa.Ikonica;
                mojaSlika = false;
                Path = tipa.ImagePath;
            }
        }

        public ObservableCollection<Etiketa> NekorisceneEtikete
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> IskorisceneEtikete
        {
            get;
            set;
        }

        public ObservableCollection<TipVrste> TipoviVrsta
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public ObservableCollection<UgrozenaVrsta> ugrozeneVrste
        {
            get;
            set;
        }
        private void tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tip.SelectedValue != null && imgPhoto != null && mojaSlika == false)
            {
                TipVrste type = (TipVrste)tip.SelectedValue;
                imgPhoto.Source = type.Ikonica;
                Path = type.ImagePath;
            }
        }

        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(obradjivana != null)
            {
                bool postoji = false;

                foreach (UgrozenaVrsta uv in MainWindow.ugrozeneVrste)
                {
                    if (uv.Oznaka.Equals(tb.Text) && !obradjivana.Oznaka.Equals(tb.Text))
                    {
                        postoji = true;
                        break;
                    }
                    
                }
                if(!postoji && tb.Text.Length >= 3)
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }
            else
            {
                var postoji = MainWindow.ugrozeneVrste.Where(c => c.Oznaka == tb.Text).ToArray();

                if (tb.Text.Length >= 3 && (postoji.Count() == 0))
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }            

            if(oznakaOK && imeOK && prihodOK)
            {
                PotvrdiDugme.IsEnabled = true;
            }
            else
            {
                PotvrdiDugme.IsEnabled = false;
            }
        }

        private void xIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length < 3)
            {
                imeOK = false;
            }
            else
            {
                imeOK = true;
            }

            if (oznakaOK && imeOK && prihodOK)
            {
                PotvrdiDugme.IsEnabled = true;
            }
            else
            {
                PotvrdiDugme.IsEnabled = false;
            }

        }

        private void xGodisnje_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            string prihod = tb.Text;

            prihod = prihod.Trim();

            int n;
            bool isNumeric = int.TryParse(prihod, out n);

            if (!isNumeric)
            {
                prihodOK = false;   
            }
            else
            {
                prihodOK = true;
            }
            if (PotvrdiDugme != null)
            {
                if (oznakaOK && imeOK && prihodOK)
                {
                    PotvrdiDugme.IsEnabled = true;
                }
                else
                {
                    PotvrdiDugme.IsEnabled = false;
                }
            }            
        }

        private void xGodisnje_GotFocus(object sender, RoutedEventArgs e)
        {
            if(xGodisnje != null)
            {
                if(xGodisnje.Text.Equals("0"))
                {
                    xGodisnje.Text = "";
                }
            }
        }
    }
}
