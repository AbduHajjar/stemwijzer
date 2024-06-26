using MySql.Data.MySqlClient;
using stemwijzer.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for partijen.xaml
    /// </summary>
    public partial class partijen : Window
    {
        //public ObservableCollection<Partij> PartijLijst { get; set; }
        public partijen()
        {
            InitializeComponent();
            FillPartijen();
        }

        public void FillPartijen()
        {
            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string SelectPartijen = "SELECT name, score FROM partijen";


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(SelectPartijen, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string partij = reader.GetString("name");
                string score = reader.GetInt32("score").ToString();
                partijnLijst.Items.Add($"{partij} - Score: {score}");
            }
            connection.Close();
        }

        private void btnAddPartij_Click(object sender, RoutedEventArgs e)
        {
            if (txtPartij.Text == "" || txtScore.Text == "")
            {
                MessageBox.Show("Vul een partij en score in.");
                return;
            }
            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string InsertPartij = "INSERT INTO partijen (name, score) VALUES (@name, @score)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(InsertPartij, connection);
                    cmd.Parameters.AddWithValue("@name", txtPartij.Text);
                    cmd.Parameters.AddWithValue("@score", txtScore.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Partij toegevoegd.");
                    txtPartij.Text = "";
                    txtScore.Text = "";
                    partijnLijst.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    FillPartijen();
                }
            }
        }

        private void partijnLijst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = partijnLijst.SelectedItem;
            if (selectedItem != null)
            {
                string[] parts = selectedItem.ToString().Split(new string[] { " - Score: " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    txtPartij.Text = parts[0]; // Partij name
                    txtScore.Text = parts[1];  // Score
                }
                else
                {
                    MessageBox.Show("Ongeldige selectie.");
                }
            }
        }

        private void btnUpdatePartij_Click(object sender, RoutedEventArgs e)
        {
            if (partijnLijst.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij.");
                return;
            }

            if (txtPartij.Text == "" || txtScore.Text == "")
            {
                MessageBox.Show("Vul een partij en score in.");
                return;
            }

            string selectedItem = partijnLijst.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new string[] { " - Score: " }, StringSplitOptions.None);
            if (parts.Length != 2)
            {
                MessageBox.Show("Ongeldige selectie.");
                return;
            }

            string selectedPartij = parts[0];
            int selectedScore;
            if (!int.TryParse(parts[1], out selectedScore))
            {
                MessageBox.Show("Ongeldige score.");
                return;
            }

            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string UpdatePartij = "UPDATE partijen SET name = @name, score = @score WHERE name = @selectedPartij AND score = @selectedScore";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(UpdatePartij, connection);
                    cmd.Parameters.AddWithValue("@name", txtPartij.Text);
                    cmd.Parameters.AddWithValue("@score", txtScore.Text);
                    cmd.Parameters.AddWithValue("@selectedPartij", selectedPartij);
                    cmd.Parameters.AddWithValue("@selectedScore", selectedScore);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Partij bijgewerkt.");
                    txtPartij.Text = "";
                    txtScore.Text = "";
                    partijnLijst.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    FillPartijen();
                }
            }
          
        }

        private void btnDeletePartij_Click(object sender, RoutedEventArgs e)
        {
            if (partijnLijst.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij.");
                return;
            }

            string selectedItem = partijnLijst.SelectedItem.ToString();
            string[] parts = selectedItem.Split(new string[] { " - Score: " }, StringSplitOptions.None);
            if (parts.Length != 2)
            {
                MessageBox.Show("Ongeldige selectie.");
                return;
            }

            string selectedPartij = parts[0];
            int selectedScore;
            if (!int.TryParse(parts[1], out selectedScore))
            {
                MessageBox.Show("Ongeldige score.");
                return;
            }

            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string DeletePartij = "DELETE FROM partijen WHERE name = @name AND score = @score";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(DeletePartij, connection);
                    cmd.Parameters.AddWithValue("@name", selectedPartij);
                    cmd.Parameters.AddWithValue("@score", selectedScore);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Partij verwijderd.");
                    partijnLijst.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    FillPartijen();
                }
            }
        }

       

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow varMainwindow = new MainWindow();
            varMainwindow.Show();
            this.Close();
        }

        private void btnStemwijzer_Click(object sender, RoutedEventArgs e)
        {
            Stemwijzer varStemwijzer = new Stemwijzer();
            varStemwijzer.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
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