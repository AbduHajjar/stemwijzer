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
    /// Interaction logic for StartPagina.xaml
    /// </summary>
    public partial class StartPagina : Window
    {
        public StartPagina()
        {
            InitializeComponent();
        }

        private void BtnStart2_Click(object sender, RoutedEventArgs e)
        {
            Stemwijzer StemwijzerStart = new Stemwijzer();
            StemwijzerStart.Show();
            this.Close();
        }
    }
}
