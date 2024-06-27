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

namespace stemwijzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Stemwijzer varStemwijzer = new Stemwijzer();
            varStemwijzer.Show();
            this.Close();
        }

        private void btnStemwijzer_click(object sender, RoutedEventArgs e)
        {
            Stemwijzer varStemwijzer = new Stemwijzer();
            varStemwijzer.Show();
            this.Close();
        }

        private void btnOverons_Click(object sender, RoutedEventArgs e)
        {
            about varAbout = new about();
            varAbout.Show();
            this.Close();
        }

        private void btnBeheerder_Click(object sender, RoutedEventArgs e)
        {
            beheerder varBeheerder = new beheerder();
            varBeheerder.Show();
            this.Close();
        }

    }
}