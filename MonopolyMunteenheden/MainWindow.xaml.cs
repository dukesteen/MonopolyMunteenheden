using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonopolyMunteenheden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int bedrag = 0;
        public bool hoogNaarLaag = true;
        public bool laagNaarHoog;

        public readonly Random random = new Random();

        // jsonString draagt alle data voor de straten (Prijs, stadsnaam, straatnaam en foto path)
        static string jsonString = "{ \"streets\": [ { \"name\": \"Dorpsstraat\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Dorpsstraat.png\"}, { \"name\": \"Brink\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Brink.png\"}, { \"name\": \"Steenstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Steenstraat.png\"}, { \"name\": \"Ketelstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Ketelstraat.png\"}, { \"name\": \"Velperplein\", \"cityName\": \"Arnhem\", \"price\": 120, \"path\": \"/MonopolyCards/Arnhem/Velperplein.png\"}, { \"name\": \"Barteljorisstraat\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Barteljorisstraat.png\"}, { \"name\": \"Zijlweg\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Zijlweg.png\"}, { \"name\": \"Houtstraat\", \"cityName\": \"Haarlem\", \"price\": 160, \"path\": \"/MonopolyCards/Haarlem/Houtstraat.png\"}, { \"name\": \"Neude\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Neude.png\"}, { \"name\": \"Biltstraat\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Biltstraat.png\"}, { \"name\": \"Vreeburg\", \"cityName\": \"Utrecht\", \"price\": 200, \"path\": \"/MonopolyCards/Utrecht/Vreeburg.png\"}, { \"name\": \"Akerkhof\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Akerkhof.png\"}, { \"name\": \"Grotemarkt\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Grotemarkt.png\"}, { \"name\": \"Heerestraat\", \"cityName\": \"Groningen\", \"price\": 240, \"path\": \"/MonopolyCards/Groningen/Heerestraat.png\"}, { \"name\": \"Spui\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Spui.png\"}, { \"name\": \"Plein\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Plein.png\"}, { \"name\": \"Lange_poten\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Lange_poten.png\"}, { \"name\": \"Hofplein\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Hofplein.png\"}, { \"name\": \"Blaak\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Blaak.png\"}, { \"name\": \"Coolsingel\", \"cityName\": \"Rotterdam\", \"price\": 320, \"path\": \"/MonopolyCards/Rotterdam/Coolsingel.png\"}, { \"name\": \"Leidsestraat\", \"cityName\": \"Amsterdam\", \"price\": 350, \"path\": \"/MonopolyCards/Amsterdam/Leidsestraat.png\"}, { \"name\": \"Kalverstraat\", \"cityName\": \"Amsterdam\", \"price\": 400, \"path\": \"/MonopolyCards/Amsterdam/Kalverstraat.png\"}, { \"name\": \"Station_noord\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_noord.png\"}, { \"name\": \"Station_oost\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_oost.png\"}, { \"name\": \"Station_zuid\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_zuid.png\"}, { \"name\": \"Station_west\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_west.png\"}, { \"name\": \"Waterleiding\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Waterleiding.png\"}, { \"name\": \"Elektriciteitsbedrijf\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Elektriciteitsbedrijf.png\"} ] }";
        // Hier word de JSON data in de StreetData class gestopt
        private readonly StreetData data = JsonConvert.DeserializeObject<StreetData>(jsonString);

        public MainWindow()
        {
            InitializeComponent();
            volgordeBox.SelectedIndex = 0;
            mainWindow.Icon = new ImageSourceConverter().ConvertFromString(AppDomain.CurrentDomain.BaseDirectory + "/MonopolyCards/Monopoly.png") as ImageSource;
        }

        // Functionaliteit voor het verplaatsen van de MainWindow
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        // Dit stopt een random getal in de bedragTxtBox
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // bedragTxtBox = een random getal tussen 2500 en 5000
            bedragTxtBox.Text = random.Next(2500, 5000).ToString();
        }

        // Functionaliteit van het programma, deze code word uitgevoerd als "Berekenen" word aangeklikt
        private void BerekenBtn_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(bedragTxtBox.Text, out bedrag);

            // Als hoogNaarLaag == true, sorteer dan van hoog naar laag
            if (hoogNaarLaag == true)
            {
                // Voeg alle data toe aan een collection
                var informatie = from s in data.Streets
                    // Order het van hoog naar laag
                    orderby s.Price descending
                    // Stop het allemaal in een groep
                    group s by s;

                // Voor elke record in naam, doe dit
                foreach (var i in informatie)
                {
                    if (bedrag <= i.FirstOrDefault().Price) continue;

                    // Voeg de straat die je kunt kopen toe aan het tekst blok
                    AddToTextBlock(i.FirstOrDefault().Name + ": Bought");
                    // Voeg een foto toe van het kaartje dat op het moment gecheckt word, alleen als het gekocht kan worden
                    AddImage(AppDomain.CurrentDomain.BaseDirectory + i.FirstOrDefault().Path);
                    // Haal het bedrag van de gekochte straat af van het bedrag
                    bedrag -= Convert.ToInt32(i.FirstOrDefault().Price);
                }

                // Voeg het overgebleven bedrag toe aan het tekst blok
                AddToTextBlock("Remaining amount: " + bedrag);
            }

            // Anders, sorteer van laag naar hoog. Dit is praktisch dezelfde code, alleen is descending nu ascending
            else
            {
                // Voeg alle data toe aan een collection
                var informatie = from s in data.Streets
                    // Order het van laag naar hoog
                    orderby s.Price ascending
                    // Stop het allemaal in een groep
                    group s by s;

                foreach (var i in informatie)
                {
                    if (bedrag <= i.FirstOrDefault().Price) continue;

                    // Voeg de straat die je kunt kopen toe aan het tekst blok
                    AddToTextBlock(i.FirstOrDefault().Name + ": Bought");
                    // Voeg een foto toe van het kaartje dat op het moment gecheckt word, alleen als het gekocht kan worden
                    AddImage(AppDomain.CurrentDomain.BaseDirectory + i.FirstOrDefault().Path);
                    // Haal het bedrag van de gekochte straat af van het bedrag
                    bedrag -= Convert.ToInt32(i.FirstOrDefault().Price);
                }

                // Voeg het overgebleven bedrag toe aan het tekst blok
                AddToTextBlock("Remaining amount: " + bedrag);
            }
        }

        #region Exit en minimize icon cursor + functionality
        private void ExitIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ExitIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void MinimizeIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void MinimizeIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }


        #endregion

        #region Afbeelding toevoegen en text toevoegen functies

        /// <summary>
        /// Functie om een foto aan de stackpanel toe te voegen met een bepaalde path.
        /// </summary>
        /// <param name="path">De locatie van de afbeelding</param>
        public void AddImage(string path)
        {
            Image image = new Image
            {
                Source = new ImageSourceConverter().ConvertFromString(path) as ImageSource,
                Stretch = Stretch.Fill,
                Height = 245,
                Width = 160
            };

            imagePanel.Children.Add(image);
        }

        /// <summary>
        /// Functie om een stuk tekst toe te voegen aan het textPanel
        /// </summary>
        /// <param name="text">De tekst die word toegevoegt</param>
        public void AddToTextBlock(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = text
            };

            textPanel.Children.Add(textBlock);
        }
        #endregion

        public partial class StreetData
        {
            // Een tabel met straten
            [JsonProperty("streets")]
            public Street[] Streets { get; set; }
        }

        // Iedere straat heeft al deze informatie (per straat)
        public partial class Street
        {
            // Naam van de straat
            [JsonProperty("name")]
            public string Name { get; set; }

            // Naam van de stad
            [JsonProperty("cityName")]
            public string CityName { get; set; }

            // Prijs van de straat
            [JsonProperty("price")]
            public long Price { get; set; }

            // Locatie van de foto van de straat
            [JsonProperty("path")]
            public string Path { get; set; }
        }

        private void VolgordeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Als in volgordeBox het geselecteerde item hoogNaarLaagItm is, zet hoogNaarLaag true en laagNaarHoog false
            if (volgordeBox.SelectedItem == hoogNaarLaagItm)
            {
                hoogNaarLaag = true;
                laagNaarHoog = false;
            }
            // Als in volgordeBox het geselecteerde item laagNaarHoogItm is, zet hoogNaarLaag false en laagNaarHoog true
            else
            {
                hoogNaarLaag = false;
                laagNaarHoog = true;
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            // Haal alle tekst uit de textPanel
            textPanel.Children.Clear();
            // Haal alle fotos uit de imagePanel
            imagePanel.Children.Clear();
        }
    }
}
