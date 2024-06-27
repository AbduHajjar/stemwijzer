using System;
using System.Collections.Generic;
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

namespace stemwijzer
{
    /// <summary>
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();

            aboutList.Text = "Over Ons\r\n\r\nWij zijn een toonaangevend softwarebedrijf gespecialiseerd in het ontwikkelen van stemwijzer apps. Ons ervaren team combineert geavanceerde technologie met diepgaande kennis van politiek en gebruikerservaring om gebruiksvriendelijke en betrouwbare stemhulpen te creëren. Met onze op maat gemaakte oplossingen helpen we gebruikers bij het maken van weloverwogen keuzes tijdens verkiezingen. Vertrouw op ons voor innovatieve en efficiënte stemwijzer applicaties die bijdragen aan een transparanter democratisch proces.";
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow varMainwindow = new MainWindow();
            varMainwindow.Show();
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

        }

        private void btnBeheerder_Click(object sender, RoutedEventArgs e)
        {
            beheerder varBeheerder = new beheerder();
            varBeheerder.Show();
            this.Close();
        }
    }
}
