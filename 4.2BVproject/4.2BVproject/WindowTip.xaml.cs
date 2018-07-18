using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
    public partial class WindowTip : Window
    {
        private MainWindow mwin;
        private int selectedIndex;
        private Boolean pokrenutaPretraga;
        public WindowTip(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;

            // Ucitavanje
            ugrozeneVrsteTip = MainWindow.TipoviVrsta;
            // Pretraga
            ugrozeneVrsteTipSakriveneIme = new ObservableCollection<TipVrste>();
            ugrozeneVrsteTipSakriveneOznaka = new ObservableCollection<TipVrste>();
            ugrozeneVrsteTipSakriveneOpis = new ObservableCollection<TipVrste>();

            //Za onemogucavanje dodavanje kada nema tipova
            mwin = mw;

            //Polja za unos da budu onemogucena dok se ne izabere nacin
            pokrenutaPretraga = false;

            Closing += OnWindowClosing;
        }
        public ObservableCollection<TipVrste> ugrozeneVrsteTip
        {
            get;
            set;
        }

        public ObservableCollection<TipVrste> ugrozeneVrsteTipSakriveneIme
        {
            get;
            set;
        }

        public ObservableCollection<TipVrste> ugrozeneVrsteTipSakriveneOznaka
        {
            get;
            set;
        }

        public ObservableCollection<TipVrste> ugrozeneVrsteTipSakriveneOpis
        {
            get;
            set;
        }

        
        private void dodajAkcija(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
            this.Close();
        }
        private void obrisiAkcija(object sender, RoutedEventArgs e)
        {
            TipVrste tv = (TipVrste)dgrMainTip.SelectedItem;


            List<UgrozenaVrsta> ugrozenaVrstaSaTipom = MainWindow.ugrozeneVrste.Where(m => m.TipVrste.Equals(tv)).ToList();
            if (ugrozenaVrstaSaTipom.Count != 0)
            {
                Dijalog messageWindow = new Dijalog("Tip vrste se koristi kod barem jedne ugrozene vrste.\nDa li zelite da ga obrisete?");
                messageWindow.ShowDialog();

                if (messageWindow.answer == true)
                {
                    foreach (UgrozenaVrsta uv in ugrozenaVrstaSaTipom)
                    {
                        MainWindow.ugrozeneVrste.Remove(uv);
                        if(MainWindow.naMapi.Contains(uv))
                        {
                            MainWindow.naMapi.Remove(uv);
                        }
                    }
                    MainWindow.TipoviVrsta.Remove(tv);
                }

            }
            else
            {
                MainWindow.TipoviVrsta.Remove(tv);
            }

            if(MainWindow.TipoviVrsta.Count == 0)
            {
                mwin.DodajVrstuButton.IsEnabled = false;
            }
        }
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            TipVrste izabrani = (TipVrste)dgrMainTip.SelectedItem;
            Window2 izmenaTipa = new Window2(izabrani, mwin);
            izmenaTipa.ShowDialog();
        }   

        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Kliknuto pretrazi");
            String text = xIme.Text;
            Console.WriteLine(text);

            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteTipSakriveneIme.Count; i++)
                {
                    ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneIme[i]);
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                { 
                    ugrozeneVrsteTipSakriveneIme.Remove(eti);
                }
            }
            else
            {
                //Console.WriteLine("Ovde sam");
                for (int i = 0; i < ugrozeneVrsteTip.Count; i++)
                {
                    bool b = ugrozeneVrsteTip[i].Ime.Contains(text);
                    if (!b)
                    {
                        //Console.WriteLine("Ne sadrzi");
                        ugrozeneVrsteTipSakriveneIme.Add(ugrozeneVrsteTip[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneIme)
                {
                    ugrozeneVrsteTip.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteTipSakriveneIme.Count; i++)
                {
                    bool b = ugrozeneVrsteTipSakriveneIme[i].Ime.Contains(text);
                    if (b)
                    {
                        ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneIme[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                {
                    ugrozeneVrsteTipSakriveneIme.Remove(eti);
                }               
            }
            text = xOpis.Text;// Opis ovde
            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteTipSakriveneOpis.Count; i++)
                {
                    ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneOpis[i]);
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                {
                    ugrozeneVrsteTipSakriveneOpis.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < ugrozeneVrsteTip.Count; i++)
                {
                    bool b = ugrozeneVrsteTip[i].Opis.Contains(text);
                    if (!b)
                    {
                        ugrozeneVrsteTipSakriveneOpis.Add(ugrozeneVrsteTip[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOpis)
                {
                    ugrozeneVrsteTip.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteTipSakriveneOpis.Count; i++)
                {
                    bool b = ugrozeneVrsteTipSakriveneOpis[i].Opis.Contains(text);
                    if (b)
                    {
                        ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneOpis[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                {
                    ugrozeneVrsteTipSakriveneOpis.Remove(eti);
                }
            }
            text = xOznaka.Text;
            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteTipSakriveneOznaka.Count; i++)
                {
                    ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneOznaka[i]);
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                {
                    ugrozeneVrsteTipSakriveneOznaka.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < ugrozeneVrsteTip.Count; i++)
                {
                    bool b = ugrozeneVrsteTip[i].Oznaka.Contains(text);
                    if (!b)
                    {
                        ugrozeneVrsteTipSakriveneOznaka.Add(ugrozeneVrsteTip[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOznaka)
                {
                    ugrozeneVrsteTip.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteTipSakriveneOznaka.Count; i++)
                {
                    bool b = ugrozeneVrsteTipSakriveneOznaka[i].Oznaka.Contains(text);
                    if (b)
                    {
                        ugrozeneVrsteTip.Add(ugrozeneVrsteTipSakriveneOznaka[i]);
                    }
                }
                foreach (TipVrste eti in ugrozeneVrsteTip)
                {
                    ugrozeneVrsteTipSakriveneOznaka.Remove(eti);
                }
            }
        }

        // Da filtriranje i pretraga ne bi obrisali tipove..
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if(ugrozeneVrsteTipSakriveneIme.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneIme)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
            }
            if (ugrozeneVrsteTipSakriveneIme.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneIme)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
            }
            if (ugrozeneVrsteTipSakriveneOpis.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOpis)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
            }
            if (ugrozeneVrsteTipSakriveneOznaka.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOznaka)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
            }

        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            if (ugrozeneVrsteTipSakriveneIme.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneIme)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
                for (int i = ugrozeneVrsteTipSakriveneIme.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteTipSakriveneIme.RemoveAt(i);
                }
            }
            if (ugrozeneVrsteTipSakriveneOpis.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOpis)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
                for (int i = ugrozeneVrsteTipSakriveneOpis.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteTipSakriveneOpis.RemoveAt(i);
                }
            }
            if (ugrozeneVrsteTipSakriveneOznaka.Count != 0)
            {
                foreach (TipVrste eti in ugrozeneVrsteTipSakriveneOznaka)
                {
                    ugrozeneVrsteTip.Add(eti);
                }
                for (int i = ugrozeneVrsteTipSakriveneOznaka.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteTipSakriveneOznaka.RemoveAt(i);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                // pozvati metode za cuvanje svih vrsta, tipova vrsta i etiketa
                HelpViewer hw = new HelpViewer("PrikazTipovaUgrozenihVrsta");
                hw.ShowDialog();
        }
    }
}
