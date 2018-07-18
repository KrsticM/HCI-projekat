using Microsoft.Win32;
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
using System.Windows.Threading;
using System.Xml.Serialization;

namespace _4._2BVproject
{
    /// <summary>
    /// Klasa za dodavanje novog tipa vrste
    /// </summary>
    public partial class Window2 : Window 
    {
        private MainWindow mwin;
        private MainWindow mwToRefresh;

        private Boolean demoMode = false;

        public static TipVrste obradjivaniTip;
        public Window2()
        {
            this.DataContext = this;
            InitializeComponent();
            TipoviVrsta = MainWindow.TipoviVrsta;

            // Unos i validacija
            PotvrdiDugme.IsEnabled = false;

            // Zabrana unosa vrste bez ijednog tipa
            mwin = null;

            imgPhoto.Source = new BitmapImage(new Uri("images/kornjaca.png", UriKind.Relative));
            obradjivaniTip = null;
        }

        public Window2(MainWindow mw)
        {
            this.DataContext = this;
            InitializeComponent();
            TipoviVrsta = MainWindow.TipoviVrsta;

            // Unos i validacija
            PotvrdiDugme.IsEnabled = false;

            // Zabrana unosa vrste bez ijednog tipa
            mwin = mw;

            imgPhoto.Source = new BitmapImage(new Uri("images/kornjaca.png", UriKind.Relative));
            obradjivaniTip = null;
        }
        public Window2(TipVrste tv, MainWindow mwRFRSH)
        {
            this.DataContext = this;
            obradjivaniTip = tv;

            InitializeComponent();
            TipoviVrsta = MainWindow.TipoviVrsta;

            // Unos i validacija
            PotvrdiDugme.IsEnabled = false;

            mwin = null;
            imgPhoto.Source = new BitmapImage(new Uri(tv.ImagePath));
            xOznaka.Text = tv.Oznaka;
            xOpis.Text = tv.Opis;
            xIme.Text = tv.ImeVrste;

            mwToRefresh = mwRFRSH;
        }
        public static ObservableCollection<TipVrste> TipoviVrsta
        {
            get;
            set;
        }


        private string Path;
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
            }

        }
        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            imgPhoto.Source = new BitmapImage(new Uri("images/kornjaca.png", UriKind.Relative));
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }
        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (obradjivaniTip != null)
            {
                obradjivaniTip.Oznaka = xOznaka.Text;
                obradjivaniTip.ImeVrste = xIme.Text;
                obradjivaniTip.Opis = xOpis.Text;
                obradjivaniTip.ImagePath = imgPhoto.Source.ToString();

                mwToRefresh.xTree.ItemsSource = null;
                mwToRefresh.xTree.ItemsSource = TipoviVrsta;
            }
            else
            {
                TipVrste tv = new TipVrste { Oznaka = xOznaka.Text, ImeVrste = xIme.Text, Opis = xOpis.Text, ImagePath = imgPhoto.Source.ToString(), SadrzaneVrste = new ObservableCollection<UgrozenaVrsta>() };
                TipoviVrsta.Add(tv);
            }            
            if (mwin != null)
            {
                mwin.DodajVrstuButton.IsEnabled = true;
            }
            this.Close();

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
                  
                }
            }
        }
        // Za onemogucavanje dodavanja
        private bool oznakaOK = false;
        private bool imeOK = false;

        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(obradjivaniTip != null)
            {
                bool postoji = false;

                foreach (TipVrste tv in MainWindow.TipoviVrsta)
                {
                    if (tv.Oznaka.Equals(tb.Text) && !obradjivaniTip.Oznaka.Equals(tb.Text))
                    {
                        postoji = true;
                        break;
                    }

                }
                if (!postoji)
                {
                    if (tb.Text.Length >= 3)
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
                    oznakaOK = false;
                }
            }
            else
            {
                var postoji = MainWindow.TipoviVrsta.Where(c => c.Oznaka == tb.Text).ToArray();

                if (tb.Text.Length >= 3 && (postoji.Count() == 0))
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }
            

            if (oznakaOK && imeOK)
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

            if (oznakaOK && imeOK)
            {
                PotvrdiDugme.IsEnabled = true;
            }
            else
            {
                PotvrdiDugme.IsEnabled = false;
            }
        }
        #region Demo
        public Point getImePoint()
        {
            if (!demoMode) return new Point(0, 0);
            Point p2 = xIme.PointToScreen(new Point(0d, 0d));
            return p2;
        }

        public Point getOznakaPoint()
        {
            if (!demoMode) return new Point(0, 0);
            return xOznaka.PointToScreen(new Point(0d, 0d));
        }
       
        public Point getOpisPoint()
        {
            if (!demoMode) return new Point(0,0);
            return xOpisScroll.PointFromScreen(new Point(0d, 0d));
        }

        public Point getOdustaniPoint()
        {
            if (!demoMode) return new Point(0, 0);
            return xOdustani.PointToScreen(new Point(0d, 0d));
        }

        public void setIme(string ime)
        {
            Dispatcher.Invoke(new Action(() => {
                xIme.Text = ime;
            }), DispatcherPriority.ContextIdle);
            
        }
        public void beginDemo()
        {
            demoMode = true;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                Point p3 = getOznakaPoint();
                p3.Y += 5;
                p3.X += 50;
                LinearSmoothMove(p3, 100);
                System.Threading.Thread.Sleep(500);
 
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "O";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "Oz";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "Ozn";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "Ozna";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "Oznak";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOznaka.Text = "Oznaka";
               
            });
            if (!demoMode) return;

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(500);
                Point p2 = getImePoint();
                p2.Y += 5;
                p2.X += 50;
                LinearSmoothMove(p2, 100);
                System.Threading.Thread.Sleep(500);
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xIme.Text = "I";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xIme.Text = "Im";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xIme.Text = "Ime";
            });
            if (!demoMode) return;

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                Point p3 = getOpisPoint();
                p3.Y = 0 - p3.Y; // Ne znam zasto vraca negativno xD
                p3.X = 0 - p3.X;

                p3.X += 50;
                p3.Y += 10;
                Console.WriteLine("Debug: " + p3.X + " " + p3.Y);
                LinearSmoothMove(p3, 100);
                System.Threading.Thread.Sleep(500);
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOpis.Text = "O";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOpis.Text = "Op";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOpis.Text = "Opi";
            });
            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(100);
                xOpis.Text = "Opis";
            });
            if (!demoMode) return;
            // na odustani
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(500);
                Point p2 = getOdustaniPoint();
                p2.Y += 5;
                p2.X += 20;
                LinearSmoothMove(p2, 100);
                System.Threading.Thread.Sleep(500);
            });

            if (!demoMode) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                System.Threading.Thread.Sleep(2000);
                this.Close();
                Application.Current.MainWindow.Show();
            });
          
        }
        public void LinearSmoothMove(Point newPosition, int steps)
        {
            if(demoMode)
            {
                Point start = Win32.GetMousePosition();
                Point iterPoint = start;

                // Find the slope of the line segment defined by start and newPosition
                Point slope = new Point(newPosition.X - start.X, newPosition.Y - start.Y);

                // Divide by the number of steps
                slope.X = slope.X / steps;
                slope.Y = slope.Y / steps;

                // Move the mouse to each iterative point.
                for (int i = 0; i < steps; i++)
                {
                    if (!demoMode)
                    {
                        return;
                    }
                        iterPoint = new Point(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                        Win32.SetCursorPos((int)iterPoint.X, (int)iterPoint.Y);
                        System.Threading.Thread.Sleep(20);
                }

                // Move the mouse to the final destination.
                Win32.SetCursorPos((int)newPosition.X, (int)newPosition.Y);
            }
          
        }
        private void ExitDemo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(demoMode == true)
            {
                e.CanExecute = true;
            }
        }

        private void ExitDemo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            demoMode = false;
            this.Close();
            Application.Current.MainWindow.Show();
        }

        #endregion
    }

}
