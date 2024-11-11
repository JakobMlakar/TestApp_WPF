using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class multimedijskaDatoteka
    {
        List<string> vseZvrsti = new List<string> { "Pop", "Rock", "Hip-Hop", "Jazz", "Klasična", "Elektronska", "Rap" };

        public string Zvrst
        {
            get { return _zvrst; }
            set 
            { 
                if (vseZvrsti.Contains(value))
                {  
                    _zvrst = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("Zvrst ne obstaja.");
            }
        }

        public string PotDoDatoteke
        {
            get { return _potDoDatoteke; }
            set
            {
                if (File.Exists(value))
                {
                    _potDoDatoteke = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("Datoteka ne obstaja.");
            }
        }

        public BitmapImage NaslovnaSlika
        {
            get { return _naslovnaSlika; }
            set 
            {
                if (value != null && value.UriSource != null)
                {
                    Uri uri = value.UriSource;
                    if (!Uri.IsWellFormedUriString(uri.AbsoluteUri, UriKind.Absolute))
                    {
                        throw new ArgumentException("Napačen URI format.");
                    }
                    if (uri.IsFile && !File.Exists(uri.LocalPath))
                    {
                        throw new ArgumentException("Datoteka na tem URI-ju ne obstaja.");
                    }
                }
                _naslovnaSlika = value;
            }
        }

        public string Avtor
        {
            get { return _avtor; }
            set { _avtor = value; }
        }

        public TimeSpan Dolzina
        {
            get { return _dolzina; }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("Dolzina je neveljavna.");
                }
                _dolzina = value;
            }
        }

        public int LetoNastanka
        {
            get { return _letoNastanka; }
            set
            {
                if(DateTime.Now.Year >= value)
                {
                    _letoNastanka = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("Leto nastanka ni veljavno.");
            }
        }

        public multimedijskaDatoteka(string zvrst, string potDoDatoteke, Uri naslovnaSlika, string avtor, TimeSpan dolzina, int letoNastanka) {
            Zvrst = zvrst;
            PotDoDatoteke = potDoDatoteke;
            NaslovnaSlika = new BitmapImage(naslovnaSlika);
            Avtor = avtor;
            Dolzina = dolzina;
            LetoNastanka = letoNastanka;
        }

        private string _zvrst = "";
        private string _potDoDatoteke = "";
        private BitmapImage _naslovnaSlika;
        private string _avtor = "";
        private TimeSpan _dolzina;
        private int _letoNastanka;
        private string _imeDatoteke;
    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void meniKlik(object sender, RoutedEventArgs args)
        {
            switch (sender) 
            {
                case MenuItem izhod:
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }
    }
}