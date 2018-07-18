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
    public partial class WindowEtiketa : Window
    {
        #region Konsturktor
        public WindowEtiketa()
        {
            InitializeComponent();
            this.DataContext = this;

            //Filtriranje        
            sakriveneEtiketeOpis = new ObservableCollection<Etiketa>();
            sakriveneEtiketeOznaka = new ObservableCollection<Etiketa>();
            sakriveneEtiketeBoja = new ObservableCollection<Etiketa>();

            //Ucitavanje 
            etikete = MainWindow.Etikete;

            Closing += OnWindowClosing;
        }
        #endregion

        #region Kolekcije
        public ObservableCollection<Etiketa> etikete
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> sakriveneEtiketeOpis
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> sakriveneEtiketeOznaka
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> sakriveneEtiketeBoja
        {
            get;
            set;
        }

        #endregion

        #region Akcija dodavanja
        private void dodajAkcija(object sender, RoutedEventArgs e)
        {
            Window3 winEtiketaUnos = new Window3();
            winEtiketaUnos.ShowDialog();
        }
        #endregion

        #region Akcija brisanja
        private void obrisiAkcija(object sender, RoutedEventArgs e)
        {
            Etiketa eta = (Etiketa)dgrMainTip.SelectedItem;

            //List<UgrozenaVrsta > ugrozenaVrstaSaOznakom = MainWindow.ugrozeneVrste.Where(m => m.Etikete.Contains(eta)).ToList();

            bool postoji = false;

            foreach(UgrozenaVrsta uv in MainWindow.ugrozeneVrste)
            {
                foreach(Etiketa et in uv.Etikete)
                {
                    if(et.Oznaka == eta.Oznaka)
                    {
                        Console.WriteLine("Postoji!");
                        postoji = true;
                        break;
                    }
                }
            }

            if (postoji)
            {
                Dijalog messageWindow = new Dijalog("Etiketa se koristi kod barem jedne ugrozene vrste.\n\t    Da li zelite da je obrisete?");
                messageWindow.ShowDialog();

                if (messageWindow.answer == true)
                {
                    foreach (UgrozenaVrsta uv in MainWindow.ugrozeneVrste)
                    {
                        uv.Etikete.Remove(eta);
                    }
                    MainWindow.Etikete.Remove(eta);
                }

            }
            else
            {
                MainWindow.Etikete.Remove(eta);
            }
        }
        #endregion

        #region Akcija izmeni
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Etiketa izabrana = (Etiketa)dgrMainTip.SelectedItem;
            Window3 izmenaEtikete = new Window3(izabrana);
            izmenaEtikete.ShowDialog();
        }
        #endregion

        #region Akcija pretrage        

        private void Pretrazi_Click_1(object sender, RoutedEventArgs e)
        {

            String text = xOznaka.Text;        
            if (text.Equals(""))
            {
                for (int i = 0; i < sakriveneEtiketeOznaka.Count; i++)
                {
                    etikete.Add(sakriveneEtiketeOznaka[i]);
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeOznaka.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < etikete.Count; i++)
                {
                    bool b = etikete[i].Oznaka.Contains(text);
                    if (!b)
                    {
                        sakriveneEtiketeOznaka.Add(etikete[i]);
                    }
                }
                foreach (Etiketa eti in sakriveneEtiketeOznaka)
                {
                    etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketeOznaka.Count; i++)
                {
                    bool b = sakriveneEtiketeOznaka[i].Oznaka.Contains(text);
                    if (b)
                    {
                        etikete.Add(sakriveneEtiketeOznaka[i]);
                    }
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeOznaka.Remove(eti);
                }
            }
            text = xOpis.Text;// Opis ovde
            if (text.Equals(""))
            {
                for (int i = 0; i < sakriveneEtiketeOpis.Count; i++)
                {
                    etikete.Add(sakriveneEtiketeOpis[i]);
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeOpis.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < etikete.Count; i++)
                {
                    bool b = etikete[i].Opis.Contains(text);
                    if (!b)
                    {
                        sakriveneEtiketeOpis.Add(etikete[i]);
                    }
                }
                foreach (Etiketa eti in sakriveneEtiketeOpis)
                {
                    etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketeOpis.Count; i++)
                {
                    bool b = sakriveneEtiketeOpis[i].Opis.Contains(text);
                    if (b)
                    {
                        etikete.Add(sakriveneEtiketeOpis[i]);
                    }
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeOpis.Remove(eti);
                }
            }
            int selectedColor = xColor.SelectedIndex;
            if (selectedColor == 7 || selectedColor == -1)
            {
                for (int i = 0; i < sakriveneEtiketeBoja.Count; i++)
                {
                    etikete.Add(sakriveneEtiketeBoja[i]);
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeBoja.Remove(eti);
                }
            }
            else
            {
                for (int i = 0; i < etikete.Count; i++)
                {
                    bool b = etikete[i].Boja == selectedColor;
                    if (!b)
                    {
                        sakriveneEtiketeBoja.Add(etikete[i]);
                    }
                }
                foreach (Etiketa eti in sakriveneEtiketeBoja)
                {
                    etikete.Remove(eti);
                }
                for (int i = 0; i < sakriveneEtiketeBoja.Count; i++)
                {
                    bool b = sakriveneEtiketeBoja[i].Boja == selectedColor;
                    if (b)
                    {
                        etikete.Add(sakriveneEtiketeBoja[i]);
                    }
                }
                foreach (Etiketa eti in etikete)
                {
                    sakriveneEtiketeBoja.Remove(eti);
                }
            }
        }
        #endregion

        #region Akcija poništi pretragu
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            if (sakriveneEtiketeBoja.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeBoja)
                {
                    etikete.Add(eti);
                }
                for (int i = sakriveneEtiketeBoja.Count - 1; i >= 0; i--)
                {
                    sakriveneEtiketeBoja.RemoveAt(i);
                }
            }
            if (sakriveneEtiketeOpis.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeOpis)
                {
                    etikete.Add(eti);
                }
                for (int i = sakriveneEtiketeOpis.Count - 1; i >= 0; i--)
                {
                    sakriveneEtiketeOpis.RemoveAt(i);
                }
            }
            if (sakriveneEtiketeOznaka.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeOznaka)
                {
                    etikete.Add(eti);
                }
                for (int i = sakriveneEtiketeOznaka.Count - 1; i >= 0; i--)
                {
                    sakriveneEtiketeOznaka.RemoveAt(i);
                }
            }
        }
        private void xColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xColor.SelectedIndex == 7)
            {
                xColor.SelectedIndex = -1;
            }
        }
        #endregion

        #region Zatvaranje prozora
        // Da filtriranje i pretraga ne bi obrisali tipove..
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (sakriveneEtiketeBoja.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeBoja)
                {
                    etikete.Add(eti);
                }
            }
            if (sakriveneEtiketeOpis.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeOpis)
                {
                    etikete.Add(eti);
                }
            }
            if (sakriveneEtiketeOznaka.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeOznaka)
                {
                    etikete.Add(eti);
                }
            }
            
        }
        #endregion

        private void pomocDugme_Click(object sender, RoutedEventArgs e)
        {

                // pozvati metode za cuvanje svih vrsta, tipova vrsta i etiketa
                HelpViewer hw = new HelpViewer("PrikazEtiketaUgrozenihVrsta");
                hw.ShowDialog();
    
        }
    }
}
