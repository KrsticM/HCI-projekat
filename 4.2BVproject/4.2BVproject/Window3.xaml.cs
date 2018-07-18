using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public static Etiketa obradjivanaEtiketa;
        public Window3()
        {
            this.DataContext = this;
            Etikete = MainWindow.Etikete;
            obradjivanaEtiketa = null;

            InitializeComponent();
            xBoja.SelectedIndex = 0;
            PotvrdiDugme.IsEnabled = false;
            
        }

        public Window3(Etiketa eta)
        {
            this.DataContext = this;
            Etikete = MainWindow.Etikete;
            obradjivanaEtiketa = eta;

            InitializeComponent();
            PotvrdiDugme.IsEnabled = false;

            xOznaka.Text = eta.Oznaka;
            xBoja.SelectedIndex = eta.Boja;
            xOpis.Text = eta.Opis;


        }

        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
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

                }
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {

            if (obradjivanaEtiketa == null)
            {
                Etiketa et = new Etiketa { Oznaka = xOznaka.Text, Boja = xBoja.SelectedIndex, Opis = xOpis.Text };
                MainWindow.Etikete.Add(et);
            }
            else
            {
                obradjivanaEtiketa.Opis = xOpis.Text;
                obradjivanaEtiketa.Boja = xBoja.SelectedIndex;
                obradjivanaEtiketa.Oznaka = xOznaka.Text;
            }
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private bool oznakaOK = false;

        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (obradjivanaEtiketa != null)
            {
                bool postoji = false;

                foreach (Etiketa eta in MainWindow.Etikete)
                {
                    if (eta.Oznaka.Equals(tb.Text) && !obradjivanaEtiketa.Oznaka.Equals(tb.Text))
                    {
                        postoji = true;
                        break;
                    }

                }
                if (!postoji && tb.Text.Length >= 3)
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
                var postoji = MainWindow.Etikete.Where(c => c.Oznaka == tb.Text).ToArray();

                if (tb.Text.Length >= 3 && (postoji.Count() == 0))
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }


            if (oznakaOK)
            {
                PotvrdiDugme.IsEnabled = true;
            }
            else
            {
                PotvrdiDugme.IsEnabled = false;
            }
        }
    }
}
