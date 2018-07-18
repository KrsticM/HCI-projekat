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
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private MainWindow mains;
        public Window4(MainWindow mw)
        {
            mains = mw;
            InitializeComponent();
            this.DataContext = this;
    
                
            // Ucitavanje 
            ugrozeneVrste = MainWindow.ugrozeneVrste;
            TipoviVrsta = MainWindow.TipoviVrsta;

            // Pretraga
            ugrozeneVrsteSakriveneIme = new ObservableCollection<UgrozenaVrsta>();
            ugrozeneVrsteSakriveneOpis = new ObservableCollection<UgrozenaVrsta>();
            ugrozeneVrsteSakriveneOznaka = new ObservableCollection<UgrozenaVrsta>();

            selectedIndex = -1;

            Closing += OnWindowClosing;
        }

        private int selectedIndex; // Selektovano u DataGridu

        #region Kolekcije
        public static ObservableCollection<UgrozenaVrsta> ugrozeneVrste
        {
            get;
            set;
        }
        public static ObservableCollection<UgrozenaVrsta> ugrozeneVrsteSakriveneIme
        {
            get;
            set;
        }
        public static ObservableCollection<UgrozenaVrsta> ugrozeneVrsteSakriveneOpis
        {
            get;
            set;
        }
        public static ObservableCollection<UgrozenaVrsta> ugrozeneVrsteSakriveneOznaka
        {
            get;
            set;
        }

        public ObservableCollection<TipVrste> TipoviVrsta
        {
            get;
            set;
        }
        #endregion

        #region Dodavanje
        private void dodajAkcija(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.ShowDialog();
        }
        #endregion

        #region Brisanje
        private void obrisiAkcija(object sender, RoutedEventArgs e)
        {
            UgrozenaVrsta eta = (UgrozenaVrsta)dgrMain.SelectedItem;
            // Ako brisem vrstu uklonicu je iz tipova koji je sadrze
            foreach(TipVrste tv in MainWindow.TipoviVrsta)
            {
                foreach(UgrozenaVrsta uv in tv.SadrzaneVrste)
                {
                    if(uv == eta)
                    {
                        tv.SadrzaneVrste.Remove(uv);
                        break;
                    }
                }
            }
            MainWindow.ugrozeneVrste.Remove(eta);
            if(MainWindow.naMapi.Contains(eta))
            {
                MainWindow.naMapi.Remove(eta);
            }
            
        }
        #endregion

        private void dgrMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((DataGrid)sender).SelectedIndex;
            selectedIndex = index;
        }

        private void izmeniAkcija(object sender, RoutedEventArgs e)
        {
            if(dgrMain.SelectedItem != null)
            {
                UgrozenaVrsta izabrana = (UgrozenaVrsta)dgrMain.SelectedItem;
                Window1 izmenaVrste = new Window1(izabrana, mains);
                izmenaVrste.ShowDialog();
            }           
        }

        #region Pretraga
        private void Pretrazi_Click_1(object sender, RoutedEventArgs e)
        {
            String text = xIme.Text;

            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteSakriveneIme.Count; i++)
                {
                    ugrozeneVrste.Add(ugrozeneVrsteSakriveneIme[i]);
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneIme.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < ugrozeneVrste.Count; i++)
                {
                    bool b = ugrozeneVrste[i].Ime.Contains(text);
                    if (!b)
                    {
                        ugrozeneVrsteSakriveneIme.Add(ugrozeneVrste[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneIme)
                {
                    ugrozeneVrste.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteSakriveneIme.Count; i++)
                {
                    bool b = ugrozeneVrsteSakriveneIme[i].Ime.Contains(text);
                    if (b)
                    {
                        ugrozeneVrste.Add(ugrozeneVrsteSakriveneIme[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneIme.Remove(eti);
                }
            }
            text = xOpis.Text;// Opis ovde
            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteSakriveneOpis.Count; i++)
                {
                    ugrozeneVrste.Add(ugrozeneVrsteSakriveneOpis[i]);
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneOpis.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < ugrozeneVrste.Count; i++)
                {
                    bool b = ugrozeneVrste[i].Opis.Contains(text);
                    if (!b)
                    {
                        ugrozeneVrsteSakriveneOpis.Add(ugrozeneVrste[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOpis)
                {
                    ugrozeneVrste.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteSakriveneOpis.Count; i++)
                {
                    bool b = ugrozeneVrsteSakriveneOpis[i].Opis.Contains(text);
                    if (b)
                    {
                        ugrozeneVrste.Add(ugrozeneVrsteSakriveneOpis[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneOpis.Remove(eti);
                }
            }
            text = xOznaka.Text;
            if (text.Equals(""))
            {
                for (int i = 0; i < ugrozeneVrsteSakriveneOznaka.Count; i++)
                {
                    ugrozeneVrste.Add(ugrozeneVrsteSakriveneOznaka[i]);
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneOznaka.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < ugrozeneVrste.Count; i++)
                {
                    bool b = ugrozeneVrste[i].Oznaka.Contains(text);
                    if (!b)
                    {
                        ugrozeneVrsteSakriveneOznaka.Add(ugrozeneVrste[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOznaka)
                {
                    ugrozeneVrste.Remove(eti);
                }
                for (int i = 0; i < ugrozeneVrsteSakriveneOznaka.Count; i++)
                {
                    bool b = ugrozeneVrsteSakriveneOznaka[i].Oznaka.Contains(text);
                    if (b)
                    {
                        ugrozeneVrste.Add(ugrozeneVrsteSakriveneOznaka[i]);
                    }
                }
                foreach (UgrozenaVrsta eti in ugrozeneVrste)
                {
                    ugrozeneVrsteSakriveneOznaka.Remove(eti);
                }
            }
        }
        #endregion

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            if (ugrozeneVrsteSakriveneIme.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneIme)
                {
                    ugrozeneVrste.Add(eti);
                }
                for (int i = ugrozeneVrsteSakriveneIme.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteSakriveneIme.RemoveAt(i);
                }
            }
            if (ugrozeneVrsteSakriveneOpis.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOpis)
                {
                    ugrozeneVrste.Add(eti);
                }
                for (int i = ugrozeneVrsteSakriveneOpis.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteSakriveneOpis.RemoveAt(i);
                }
            }
            if (ugrozeneVrsteSakriveneOznaka.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOznaka)
                {
                    ugrozeneVrste.Add(eti);
                }
                for (int i = ugrozeneVrsteSakriveneOznaka.Count - 1; i >= 0; i--)
                {
                    ugrozeneVrsteSakriveneOznaka.RemoveAt(i);
                }
            }
        }
        // Da filtriranje i pretraga ne bi obrisali tipove..
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (ugrozeneVrsteSakriveneIme.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneIme)
                {
                    ugrozeneVrste.Add(eti);
                }
            }
            if (ugrozeneVrsteSakriveneIme.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneIme)
                {
                    ugrozeneVrste.Add(eti);
                }
            }
            if (ugrozeneVrsteSakriveneOpis.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOpis)
                {
                    ugrozeneVrste.Add(eti);
                }
            }
            if (ugrozeneVrsteSakriveneOznaka.Count != 0)
            {
                foreach (UgrozenaVrsta eti in ugrozeneVrsteSakriveneOznaka)
                {
                    ugrozeneVrste.Add(eti);
                }
            }

        }

        private void pomocDugme_Click(object sender, RoutedEventArgs e)
        {
            // pozvati metode za cuvanje svih vrsta, tipova vrsta i etiketa
            HelpViewer hw = new HelpViewer("PrikazUgrozenihVrsta");
            hw.ShowDialog();
        }
    }
}
