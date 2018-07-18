using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace _4._2BVproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            var path = "C:\\Users\\Krstic\\Desktop\\Test\\test.xml";
            load(path);
            InitializeComponent();
            if (TipoviVrsta.Count == 0)
            {
                DodajVrstuButton.IsEnabled = false;
            }


            this.Closed += new EventHandler(MainWindow_Closed);

        }
        void MainWindow_Closed(object sender, EventArgs e)
        {
            var path = "C:\\Users\\Krstic\\Desktop\\Test\\test.xml";
            save(path);
        }
        public void load(String path)
        {

            if (File.Exists(path) == false)
            {
                Etikete = new ObservableCollection<Etiketa>();
                TipoviVrsta = new ObservableCollection<TipVrste>();
                ugrozeneVrste = new ObservableCollection<UgrozenaVrsta>();
                naMapi = new ObservableCollection<UgrozenaVrsta>();
                return;
            }

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                if (fs.Length == 0)
                {
                    Etikete = new ObservableCollection<Etiketa>();
                    TipoviVrsta = new ObservableCollection<TipVrste>();
                    ugrozeneVrste = new ObservableCollection<UgrozenaVrsta>();
                    naMapi = new ObservableCollection<UgrozenaVrsta>();
                    return;
                }

                DataContractSerializer dcs = new DataContractSerializer(typeof(Repo));
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                Repo ap = (Repo)dcs.ReadObject(reader);

                Etikete = ap.Etikete;
                TipoviVrsta = ap.TipoviVrsta;
                ugrozeneVrste = ap.ugrozeneVrste;
                naMapi = ap.naMapi;

                fs.Close();
            }
        }
        public void save(String path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                Repo ap = new Repo();
                ap.Etikete = Etikete;
                ap.TipoviVrsta = TipoviVrsta;
                ap.ugrozeneVrste = ugrozeneVrste;
                ap.naMapi = naMapi;
                var serializer = new DataContractSerializer(ap.GetType(), null, 0x7FFF, false, true, null);
                serializer.WriteObject(fs, ap);
                fs.Close();
            }
        }

        private void dodajVrstu_Click(object sender, RoutedEventArgs e)
        {
            Window1 novi = new Window1();
            novi.ShowDialog();
        }

        private void dodajTip_Click(object sender, RoutedEventArgs e)
        {
            Window2 novi = new Window2(this);
            novi.ShowDialog();
        }
        private void pregledVrsta_Click(object sender, RoutedEventArgs e)
        {
            Window4 novi = new Window4(this);
            novi.ShowDialog();
        }
        private void dodajEtiketu_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.ShowDialog();
        }
        private void pregledEtiketa_Click(object sender, RoutedEventArgs e)
        {
            WindowEtiketa we = new WindowEtiketa();
            we.ShowDialog();
        }
        private void pregledTip_Click(object sender, RoutedEventArgs e)
        {
            WindowTip wtp = new WindowTip(this);
            wtp.ShowDialog();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            // pozvati metode za cuvanje svih vrsta, tipova vrsta i etiketa
        }

        private void globalnaPomoc_Click(object sender, RoutedEventArgs e)
        {
            // pozvati metode za cuvanje svih vrsta, tipova vrsta i etiketa
            HelpViewer hw = new HelpViewer("PocetniProzor");
            hw.ShowDialog();
        }

        #region demo
        private void demo_Begin(object sender, RoutedEventArgs e)
        {
            demoMode = true;
            Point p = dodajTipDugme.PointToScreen(new Point(0d, 0d));
            p.X += 20;
            p.Y += 10;
            
            LinearSmoothMove(p, 100);

            Window2 w2 = new Window2(this);
            w2.Show();
            Thread.Sleep(500);
            Application.Current.Dispatcher?.BeginInvoke(new Action(() => {

                w2.beginDemo();
            }));


            //Win32.ClientToScreen(this.Handle, ref p);

        }

       

        public void LinearSmoothMove(Point newPosition, int steps)
        {
            if (demoMode)
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
                    if(!demoMode)
                    {
                        return;
                    }
                    iterPoint = new Point(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                    Win32.SetCursorPos((int)iterPoint.X, (int)iterPoint.Y);
                    Thread.Sleep(20);
                }

                // Move the mouse to the final destination.
                Win32.SetCursorPos((int)newPosition.X, (int)newPosition.Y);
            }
        }

        private Boolean demoMode = false;

        private void ExitDemo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (demoMode == true)
            {
                e.CanExecute = true;
            }
        }

        private void ExitDemo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            demoMode = false;
        }


        #endregion   
        private void Tree_DoubleClick(object sender, RoutedEventArgs e)
        {
            if(xTree.SelectedItem is UgrozenaVrsta)
            {
                UgrozenaVrsta uv = (UgrozenaVrsta)xTree.SelectedItem;
                Window1 w1 = new Window1(uv, this);
                w1.ShowDialog();
            }
            else if(xTree.SelectedItem is TipVrste)
            {
                TipVrste tv = (TipVrste)xTree.SelectedItem;
                Window2 w2 = new Window2(tv, this);
                w2.ShowDialog();
            }
        }
        public void Mapa_DoubleClick(object sender, RoutedEventArgs e)
        {
            if(NaMapi.SelectedItem is UgrozenaVrsta)
            {
                UgrozenaVrsta uv = (UgrozenaVrsta)NaMapi.SelectedItem;
                Window1 w1 = new Window1(uv, this);
                w1.ShowDialog();
                
            }
        }


        #region Podaci
        public static ObservableCollection<TipVrste> TipoviVrsta
        {
            get;
            set;
        }

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public static ObservableCollection<UgrozenaVrsta> ugrozeneVrste
        {
            get;
            set;
        }
        public static ObservableCollection<UgrozenaVrsta> naMapi
        {
            get;
            set;
        }
        #endregion
        #region Drag and Drop

        private Point startPoint = new Point();
        private Boolean isDragging = false;

        //sluzi da se preuzme pocetna tacka kada se klikne negde, ista moze i za mapu i za drvo
        private void Tree_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        //da ne bih morala da komplikujem kao oni da bih nasla TreeViewItem + njihovo cak i ne radi ako je redefinisan 
        //prikaz cvorova u drvetu
        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            xTree.Tag = e.OriginalSource;
        }

        //za drag iz drva. zapocinje drag ako je neko kliknuo na item u drvetu i vuce ga
        private void Tree_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(e);
                }
            }
        }

        //poziva se iz one iznad. Ovde je zapravo posao
        private void StartDrag(MouseEventArgs e)
        {
            //obavezno if! tipovi se ne mogu dragovati, a ovako ako je neko slucajno kliknuo negde na drvo ne moze ni to
            if (xTree.SelectedItem is UgrozenaVrsta)
            {
                isDragging = true;

                UgrozenaVrsta selectedItem = (UgrozenaVrsta)xTree.SelectedItem;
                TreeViewItem tvi = xTree.Tag as TreeViewItem;
                // Initialize the drag & drop operation                
                DataObject dragData = new DataObject("ugrozeniDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(tvi, dragData, DragDropEffects.Move);
                //ovde se dodje tek kada se spusti objekat
                isDragging = false;
            }
        }

        //ovo sluzi za pokretanje draga sa mape
        private void NaMapi_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDragMap(e);
                }
            }
        }

        //funkcija koja zapravo pokrene drag sa mape
        private void StartDragMap(MouseEventArgs e)
        {
            if (NaMapi.SelectedItem is UgrozenaVrsta) //zbog null, ako je neko krenuo da vuce po mapi bezveze
            {
                isDragging = true;
                UgrozenaVrsta selectedItem = (UgrozenaVrsta)NaMapi.SelectedItem;
                ListBoxItem lwi = (ListBoxItem)NaMapi.ItemContainerGenerator.ContainerFromItem(selectedItem);
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("ugrozeniDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(lwi, dragData, DragDropEffects.Move);
                isDragging = false;
            }
        }

        //ovo sluzi da prikaze da se na mapu moze spustiti objekat
        private void NaMapi_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag")) //ni slucajno od njih e.source == sender dodati. Onda ne moze po mapi da se pomera
            {
                e.Effects = DragDropEffects.None;
            }

        }

        //ovo sluzi da se prikaze da se na drvo moze spustiti objekat
        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ugrozeniDrag"))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else //ova komplikacija je da se lokali ne mogu uzeti iz drveta i vratiti u drvo, jer je glupo
            {
                UgrozenaVrsta uv = e.Data.GetData("ugrozeniDrag") as UgrozenaVrsta;
                if (uv.Point.X == -1)
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
        }

        //ubacuje lokal sa drveta na mapu
        private void NaMapi_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ugrozeniDrag"))
            {

                UgrozenaVrsta uv = e.Data.GetData("ugrozeniDrag") as UgrozenaVrsta;
                Console.WriteLine("Dropovan " + uv.Ime);
                uv.Point = e.GetPosition(NaMapi);
                if(!naMapi.Contains(uv))
                {
                    naMapi.Add(uv);
                }
                 //observable vezana za listu iz mape
                Console.WriteLine(naMapi.Count);
                //lokal.Tip.ukloniLokal(uv); //meni ova funkcija ukloni iz Observable kolekcije iz koje drvo uzima lokale za taj tip
                isDragging = false;
            }
        }

        private void Tree_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ugrozeniDrag"))
            {
                UgrozenaVrsta uv = e.Data.GetData("ugrozeniDrag") as UgrozenaVrsta;
                //one sve f-je iznad samo menjaju mis da korisnik vidi da ne moze drop, a ako ipak drop, ovo sprecava efekat 
                //kod mene je point(-1,-1) ako nesto nije na mapi             
                Console.WriteLine("Tree Drop");
                naMapi.Remove(uv);//observable vezana za listu iz mape
                Console.WriteLine("Obrisan: " + naMapi.Count);
                uv.Point = new Point(-1, -1);
                //lokal.Tip.dodajLokal(lokal); //ova funkcija mi dodaje u Observable iz kog drvo uzima lokale za tip
                isDragging = false;
            }
        }

        #endregion



    }
}
