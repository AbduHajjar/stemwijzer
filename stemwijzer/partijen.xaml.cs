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
            //PartijLijst = new ObservableCollection<Partij>();
            //DataContext = this;
            FillPartijen();
        }

        public void FillPartijen()
        {
            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string SelectPartijen = "SELECT name FROM partijen";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(SelectPartijen, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string partij = reader.GetString("name");
                partijnLijst.Items.Add(partij);
            }
            connection.Close();
        }

        private void btnAddPartij_Click(object sender, RoutedEventArgs e)
        {
            if (txtPartij.Text == "")
            {
                MessageBox.Show("Vul een partij in.");
            }

            else if (partijnLijst.Items.Contains(txtPartij.Text.ToUpper()))
            {
                MessageBox.Show("Deze partij bestaat al.");
            }
            else
            {
                string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
                string InsertPartij = "INSERT INTO partijen (name) VALUES (@name)";

                MySqlConnection connection = new MySqlConnection(connectionString);
                partijnLijst.Items.Clear();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(InsertPartij, connection);
                cmd.Parameters.AddWithValue("@name", txtPartij.Text);
                cmd.ExecuteNonQuery();

                connection.Close();
                FillPartijen();
            }
        }


        private void btnUpdatePartij_Click(object sender, RoutedEventArgs e)
        {
            if (partijnLijst.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij.");
            }
            else if (txtPartij.Text == "")
            {
                MessageBox.Show("Vul een partij in.");
            }
            else
            {
                string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
                string UpdatePartij = "UPDATE partijen SET name = @name WHERE name = @selectedName";

                MySqlConnection connection = new MySqlConnection(connectionString);
                partijnLijst.Items.Clear();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(UpdatePartij, connection);
                cmd.Parameters.AddWithValue("@name", txtPartij.Text);
                cmd.Parameters.AddWithValue("@selectedName", partijnLijst.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                connection.Close();
                FillPartijen();
            }

        }

        private void btnDeletePartij_Click(object sender, RoutedEventArgs e)
        {
            if (partijnLijst.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een partij.");
                return;
            }

            string selectedPartij = partijnLijst.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedPartij))
            {
                MessageBox.Show("Ongeldige selectie.");
                return;
            }

            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string DeletePartij = "DELETE FROM partijen WHERE name = @name";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(DeletePartij, connection);
                    cmd.Parameters.AddWithValue("@name", selectedPartij);
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

        //private void btnDeletePartij_Click(object sender, RoutedEventArgs e)
        //{
        //    if (partijnLijst.SelectedItem == null)
        //    {
        //        MessageBox.Show("Selecteer een partij.");
        //        return;
        //    }
        //    else
        //    {
        //        string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
        //        string DeletePartij = "DELETE FROM partijen WHERE name = @name";

        //        MySqlConnection connection = new MySqlConnection(connectionString);
        //        partijnLijst.Items.Clear();
        //        connection.Open();
        //        MySqlCommand cmd = new MySqlCommand(DeletePartij, connection);
        //        if (partijnLijst.SelectedItem == null)
        //        {
        //            MessageBox.Show("Selecteer een partij.");
        //        }
        //        else
        //        {
        //            cmd.Parameters.AddWithValue("@name", partijnLijst.SelectedItem.ToString());
        //            cmd.ExecuteNonQuery();
        //        }

        //        connection.Close();
        //        FillPartijen();
        //    }
        //}
    }
}