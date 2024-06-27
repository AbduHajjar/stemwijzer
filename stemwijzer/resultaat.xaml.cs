using stemwijzer.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for resultaat.xaml
    /// </summary>
    public partial class resultaat : Window
    {
        public string Partij; 
        Stemwijzer uitslag = new Stemwijzer();
        public resultaat(string prt)
        {
            InitializeComponent();
            this.DataContext = this;
            Partij = prt;
            resultaatPartij.Text = Partij;
            Standpunten();
        }

        public void Standpunten()
        {
            switch (Partij)
            {
                case "VVD":
                    standPunten.Text = "VVD standpunten:\r\n" +
                           "Immigratie: Strenge controle en beperking van immigratie om integratie te bevorderen.\r\n" +
                           "Infrastructuur: Investeren in slimme infrastructuur voor een efficiënter wegennet.\r\n" +
                           "Europese Unie: Actieve en kritische deelname binnen de EU met behoud van nationale soevereiniteit.\r\n" +
                           "Belastingen: Verlaging van belastingen om economische groei te stimuleren.\r\n" +
                           "Landbouw: Innovatie in de landbouwsector voor duurzame productie.\r\n" +
                           "Justitie: Zwaardere straffen voor criminaliteit en efficiëntere rechtspraak.\r\n" +
                           "Cultuur: Cultuursector stimuleren als belangrijke economische en sociale factor.\r\n" +
                           "Decentralisatie: Meer verantwoordelijkheden naar lokale overheden voor maatwerk.\r\n" +
                           "Milieu: Balans tussen economische groei en milieubescherming.\r\n" +
                           "Energie: Investeren in duurzame energiebronnen en energietransitie.\r\n" +
                           "Vluchtelingenbeleid: Strikte selectie en integratie van vluchtelingen op basis van behoefte.\r\n" +
                           "Openbaar Vervoer: Modernisering en uitbreiding van openbaar vervoersnetwerken.\r\n"; ;
                    break;
                case "PVV":
                    standPunten.Text = "PVV standpunten:\r\n\r\n" +
                           "Immigratie: Grenzen dicht voor immigratie uit islamitische landen.\r\n\r\n" +
                           "Infrastructuur: Nationale infrastructuur verbeteren voor meer veiligheid en efficiëntie.\r\n\r\n" +
                           "Europese Unie: Nederland moet de EU verlaten voor meer zelfstandigheid.\r\n\r\n" +
                           "Belastingen: Verlaging van belastingen voor de gemiddelde Nederlander.\r\n\r\n" +
                           "Landbouw: Nederlandse boeren beschermen tegen oneerlijke concurrentie.\r\n\r\n" +
                           "Justitie: Harder optreden tegen criminelen met strengere straffen.\r\n\r\n" +
                           "Cultuur: Behoud van Nederlandse cultuur en tradities.\r\n\r\n" +
                           "Decentralisatie: Minder macht naar Brussel, meer naar Nederland.\r\n\r\n" +
                           "Milieu: Milieuplannen niet ten koste van de Nederlandse economie.\r\n\r\n" +
                           "Energie: Geen subsidies voor wind- en zonne-energie, focus op kernenergie.\r\n\r\n" +
                           "Vluchtelingenbeleid: Geen opvang van vluchtelingen in Nederland.\r\n\r\n" +
                           "Openbaar Vervoer: Goedkoop en efficiënt openbaar vervoer voor Nederlanders.\r\n";
                    break;
                case "CDA":
                    standPunten.Text = "CDA standpunten:\r\n\r\n" +
                           "Immigratie: Integratie bevorderen door strikte maar eerlijke immigratieregels.\r\n\r\n" +
                           "Infrastructuur: Verbeteren van infrastructuur om bereikbaarheid te vergroten.\r\n\r\n" +
                           "Europese Unie: Constructieve samenwerking binnen de EU met oog voor Nederlandse belangen.\r\n\r\n" +
                           "Belastingen: Eerlijk belastingstelsel met oog voor gezinnen en bedrijven.\r\n\r\n" +
                           "Landbouw: Duurzame en innovatieve landbouwsector stimuleren.\r\n\r\n" +
                           "Justitie: Rechtvaardig en effectief justitieel systeem voor veiligheid en recht.\r\n\r\n" +
                           "Cultuur: Ondersteuning van culturele initiatieven en erfgoedbehoud.\r\n\r\n" +
                           "Decentralisatie: Krachtige lokale overheden voor betere dienstverlening.\r\n\r\n" +
                           "Milieu: Sterke focus op milieubehoud en duurzame ontwikkeling.\r\n\r\n" +
                           "Energie: Stimuleren van hernieuwbare energie en energiebesparing.\r\n\r\n" +
                           "Vluchtelingenbeleid: Humane opvang en integratie van vluchtelingen.\r\n\r\n" +
                           "Openbaar Vervoer: Toegankelijk en efficiënt openbaar vervoerssysteem.\r\n"; ;
                    break;
                case "CU":
                    standPunten.Text = "CU standpunten:\r\n\r\n" +
                           "Immigratie: Eerlijke en humane immigratiepolitiek met oog voor integratie.\r\n\r\n" +
                           "Infrastructuur: Duurzame investeringen in infrastructuur.\r\n\r\n" +
                           "Europese Unie: Samenwerking in de EU op basis van christelijke waarden.\r\n\r\n" +
                           "Belastingen: Rechtvaardig belastingstelsel met aandacht voor kwetsbaren.\r\n\r\n" +
                           "Landbouw: Verduurzaming en ondersteuning van kleinschalige landbouw.\r\n\r\n" +
                           "Justitie: Rechtvaardig en vergevingsgezind justitieel systeem.\r\n\r\n" +
                           "Cultuur: Cultuur als verbindende factor in de samenleving stimuleren.\r\n\r\n" +
                           "Decentralisatie: Sterke lokale gemeenschappen en bestuur.\r\n\r\n" +
                           "Milieu: Bewust milieubeleid voor behoud van schepping.\r\n\r\n" +
                           "Energie: Versnellen van de energietransitie naar duurzame bronnen.\r\n\r\n" +
                           "Vluchtelingenbeleid: Waardig en humaan vluchtelingenbeleid.\r\n\r\n" +
                           "Openbaar Vervoer: Verbetering en verduurzaming van het openbaar vervoer.\r\n";
                    break;  
                case "GroenLinks":
                    standPunten.Text = "GroenLinks standpunten:\r\n\r\n" +
                           "Immigratie: Inclusieve en humane aanpak van immigratie.\r\n\r\n" +
                           "Infrastructuur: Duurzame infrastructuurprojecten om klimaatdoelen te halen.\r\n\r\n" +
                           "Europese Unie: Sterke en sociale EU met nadruk op milieubeleid.\r\n\r\n" +
                           "Belastingen: Progressieve belastingen voor meer gelijkheid.\r\n\r\n" +
                           "Landbouw: Duurzame en biologische landbouw stimuleren.\r\n\r\n" +
                           "Justitie: Rechtvaardig systeem met focus op preventie en re-integratie.\r\n\r\n" +
                           "Cultuur: Actieve ondersteuning van culturele diversiteit.\r\n\r\n" +
                           "Decentralisatie: Meer macht en middelen naar lokale overheden.\r\n\r\n" +
                           "Milieu: Ambitieuze klimaatdoelen voor een groenere toekomst.\r\n\r\n" +
                           "Energie: Snelle overgang naar 100% hernieuwbare energie.\r\n\r\n" +
                           "Vluchtelingenbeleid: Solidariteit en humane opvang voor vluchtelingen.\r\n\r\n" +
                           "Openbaar Vervoer: Gratis en duurzaam openbaar vervoer.\r\n";
                    break;
                case "PVDA":
                    standPunten.Text = "PVDA standpunten:\r\n\r\n" +
                           "Immigratie: Eerlijke en rechtvaardige immigratiepolitiek met oog voor integratie.\r\n\r\n" +
                           "Infrastructuur: Investeren in infrastructuur voor werkgelegenheid en duurzaamheid.\r\n\r\n" +
                           "Europese Unie: Solidariteit en samenwerking binnen een sociale EU.\r\n\r\n" +
                           "Belastingen: Progressieve belastinghervorming voor meer gelijkheid.\r\n\r\n" +
                           "Landbouw: Duurzame landbouw en eerlijke prijzen voor boeren.\r\n\r\n" +
                           "Justitie: Rechtvaardig en menselijk justitieel systeem.\r\n\r\n" +
                           "Cultuur: Breed toegankelijk cultuurbeleid.\r\n\r\n" +
                           "Decentralisatie: Sterkere lokale besturen voor betere dienstverlening.\r\n\r\n" +
                           "Milieu: Krachtig milieubeleid voor toekomstige generaties.\r\n\r\n" +
                           "Energie: Investeren in duurzame energie en energiebesparing.\r\n\r\n" +
                           "Vluchtelingenbeleid: Menswaardige opvang en integratie van vluchtelingen.\r\n\r\n" +
                           "Openbaar Vervoer: Betaalbaar en efficiënt openbaar vervoer voor iedereen.\r\n";
                    break;
                case "BBB":
                    standPunten.Text = "BBB standpunten:\r\n\r\n" +
                           "Immigratie: Streng maar rechtvaardig immigratiebeleid.\r\n\r\n" +
                           "Infrastructuur: Verbetering van infrastructuur om platteland bereikbaar te houden.\r\n\r\n" +
                           "Europese Unie: Minder Brusselse regels, meer nationale autonomie.\r\n\r\n" +
                           "Belastingen: Verlaging van belastingen voor burgers en ondernemers.\r\n\r\n" +
                           "Landbouw: Sterke steun en bescherming voor de agrarische sector.\r\n\r\n" +
                           "Justitie: Zwaardere straffen voor misdaad en betere ondersteuning voor slachtoffers.\r\n\r\n" +
                           "Cultuur: Behoud van regionale culturele identiteit en tradities.\r\n\r\n" +
                           "Decentralisatie: Meer bevoegdheden naar lokale overheden.\r\n\r\n" +
                           "Milieu: Milieubeleid dat rekening houdt met agrarische belangen.\r\n\r\n" +
                           "Energie: Betaalbare en haalbare energietransitie.\r\n\r\n" +
                           "Vluchtelingenbeleid: Beperkte en gecontroleerde opvang van vluchtelingen.\r\n\r\n" +
                           "Openbaar Vervoer: Verbetering van openbaar vervoer op het platteland.\r\n";
                    break;
            }
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
