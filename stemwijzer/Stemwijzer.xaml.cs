using MySql.Data.MySqlClient;
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
    /// Interaction logic for Stemwijzer.xaml
    /// </summary>
    public partial class Stemwijzer : Window
    {
        private int HuidigeVraagIndex = 0;
        private int HuidigeScore = 0;
        private List<string> questions;
        private List<string> stellingen;
        string partij;

        public Stemwijzer()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayQuestion();
            NextQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<string>
            {
                "Immigratie",
                "Infrastructuur",
                "Europese Unie",
                "Belastingen",
                "Landbouw",
                "Justitie",
                "Cultuur",
                "Decentralisatie",
                "Milieu",
                "Energie",
                "Vluchtelingenbeleid",
                "Openbaar Vervoer"

            };

            stellingen = new List<string>
            {
                "Verplichte integratiecursussen voor nieuwkomers",
                "Nationalisering van de spoorwegen",
                "EU-lidmaatschap behouden",
                "Belastingen verhogen voor de rijkste 1%",
                "Subsidies voor landbouw verminderen",
                "Minimale straffen voor geweldsmisdrijven verhogen",
                "Hogere uitgaven aan kunst en cultuur",
                "Meer bevoegdheden naar lokale overheden",
                "Hogere btw op vleesproducten",
                "Verbod op fossiele brandstoffen vanaf 2040",
                "Beperking van het aantal vluchtelingen",
                "Meer investeringen in openbaar vervoer ten koste van autowegen",
            };
        }

        private void DisplayQuestion()
        {
            if (HuidigeVraagIndex < questions.Count)
            {
                txtVraag.Text = questions[HuidigeVraagIndex];
                txtStelling.Text = stellingen[HuidigeVraagIndex];
                txtNummer.Text = $"{HuidigeVraagIndex}/{questions.Count - 1}";
            }
            else
            {
                // Alle vragen zijn beantwoord, toon resultaat
                ShowResult();
            }
        }

        private void ShowResult()
        {
            string partij = DeterminePartij(HuidigeScore);
            //MessageBox.Show($"Je antwoorden passen het meest bij: {partij}");
            resultaat varResultaat = new resultaat(partij);
            varResultaat.Show();
            //txtVraag.Text = $"Je antwoorden passen het meest bij: {partij}";
            this.Close();

            HuidigeVraagIndex = 0;
            HuidigeScore = 0;
            DisplayQuestion();

        }

        private string DeterminePartij(int score)
        {
            string connectionString = "Server=localhost;Database=stemwijzer;Uid=root;Pwd=;";
            string query = "SELECT name, score FROM partijen";
            string closestParty = "Geen partij gevonden";
            int closestScoreDifference = int.MaxValue;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string partij = reader.GetString("name");
                        int partijScore = reader.GetInt32("score");
                        int scoreDifference = Math.Abs(partijScore - score);

                        if (scoreDifference < closestScoreDifference)
                        {
                            closestScoreDifference = scoreDifference;
                            closestParty = partij;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er is een fout opgetreden: " + ex.Message);
                }
            }

            return closestParty;
        }

        private void btnEens_Click(object sender, RoutedEventArgs e)
        {
            HuidigeScore += 1;
            NextQuestion();
        }

        private void btnOneens_Click(object sender, RoutedEventArgs e)
        {
            HuidigeScore -= 1;
            NextQuestion();
        }

        private void btnGeenantwoord_Click(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }

        private void NextQuestion()
        {
            HuidigeVraagIndex++;
            DisplayQuestion();
        }

        private void BtnArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            if (HuidigeVraagIndex > 1)
            {
                HuidigeVraagIndex--;
                DisplayQuestion();
            }
            else
            {
                MessageBox.Show("Dit is de eerste vraag, er zijn geen vorige vragen.");
            }
        }

        private void BtnArrowRight_Click(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow varMainwindow = new MainWindow();
            varMainwindow.Show();
            this.Close();
        }

        private void btnBeheerder_Click(object sender, RoutedEventArgs e)
        {
            beheerder varBeheerder = new beheerder();
            varBeheerder.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            about varAbout = new about();
            varAbout.Show();
            this.Close();
        }
    }
}