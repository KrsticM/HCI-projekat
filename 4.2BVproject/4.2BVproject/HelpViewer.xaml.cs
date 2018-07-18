using System;
using System.Collections.Generic;
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

namespace _4._2BVproject
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        //private JavaScriptControlHelper ch;

        public HelpViewer(string key)
        {
            InitializeComponent();
            string path = String.Format(@"C:\Users\Krstic\Desktop\HCI projekat\4.2BVproject\4.2BVproject\Help\{0}.html", key);
            if (!File.Exists(path))
            {
                Console.WriteLine("Fajl ne postoji!");
                key = "error";
            }
            Uri u = new Uri(String.Format(@"C:\Users\Krstic\Desktop\HCI projekat\4.2BVproject\4.2BVproject\Help\{0}.html", key));
            wbHelp.Navigate(u);
        }
    }
}
