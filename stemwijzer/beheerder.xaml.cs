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
    /// Interaction logic for beheerder.xaml
    /// </summary>
    public partial class beheerder : Window
    {
        public beheerder()
        {
            InitializeComponent();
        }

        string username = "admin";
        string password = "0000";

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                partijen partijen = new partijen();
                partijen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gebruikersnaam of wachtwoord is onjuist.");
            }
        }

    }
}
