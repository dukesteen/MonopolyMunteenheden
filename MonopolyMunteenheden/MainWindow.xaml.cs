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

        static string jsonString = "{ \"streets\": [ { \"name\": \"Dorpsstraat\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Dorpsstraat.png\"}, { \"name\": \"Brink\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Brink.png\"}, { \"name\": \"Steenstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Steenstraat.png\"}, { \"name\": \"Ketelstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Ketelstraat.png\"}, { \"name\": \"Velperplein\", \"cityName\": \"Arnhem\", \"price\": 120, \"path\": \"/MonopolyCards/Arnhem/Velperplein.png\"}, { \"name\": \"Barteljorisstraat\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Barteljorisstraat.png\"}, { \"name\": \"Zijlweg\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Zijlweg.png\"}, { \"name\": \"Houtstraat\", \"cityName\": \"Haarlem\", \"price\": 160, \"path\": \"/MonopolyCards/Haarlem/Houtstraat.png\"}, { \"name\": \"Neude\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Neude.png\"}, { \"name\": \"Biltstraat\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Biltstraat.png\"}, { \"name\": \"Vreeburg\", \"cityName\": \"Utrecht\", \"price\": 200, \"path\": \"/MonopolyCards/Utrecht/Vreeburg.png\"}, { \"name\": \"Akerkhof\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Akerkhof.png\"}, { \"name\": \"Grotemarkt\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Grotemarkt.png\"}, { \"name\": \"Heerestraat\", \"cityName\": \"Groningen\", \"price\": 240, \"path\": \"/MonopolyCards/Groningen/Heerestraat.png\"}, { \"name\": \"Spui\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Spui.png\"}, { \"name\": \"Plein\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Plein.png\"}, { \"name\": \"Lange_poten\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Lange_poten.png\"}, { \"name\": \"Hofplein\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Hofplein.png\"}, { \"name\": \"Blaak\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Blaak.png\"}, { \"name\": \"Coolsingel\", \"cityName\": \"Rotterdam\", \"price\": 320, \"path\": \"/MonopolyCards/Rotterdam/Coolsingel.png\"}, { \"name\": \"Leidsestraat\", \"cityName\": \"Amsterdam\", \"price\": 350, \"path\": \"/MonopolyCards/Amsterdam/Leidsestraat.png\"}, { \"name\": \"Kalverstraat\", \"cityName\": \"Amsterdam\", \"price\": 400, \"path\": \"/MonopolyCards/Amsterdam/Kalverstraat.png\"}, { \"name\": \"Station_noord\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_noord.png\"}, { \"name\": \"Station_oost\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_oost.png\"}, { \"name\": \"Station_zuid\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_zuid.png\"}, { \"name\": \"Station_west\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_west.png\"}, { \"name\": \"Waterleiding\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Waterleiding.png\"}, { \"name\": \"Elektriciteitsbedrijf\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Elektriciteitsbedrijf.png\"} ] }";
        private readonly StreetData data = JsonConvert.DeserializeObject<StreetData>(jsonString);

        public MainWindow()
        {
            InitializeComponent();
            volgordeBox.SelectedIndex = 0;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bedragTxtBox.Text = random.Next(2500, 5000).ToString();
        }

        private void BerekenBtn_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(bedragTxtBox.Text, out bedrag);

            if (hoogNaarLaag == true)
            {
                // Voeg alle data toe aan een collection
                var naam = from s in data.Streets
                    orderby s.Price descending
                    group s by s;

                foreach (var i in naam)
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
            else
            {
                // Voeg alle data toe aan een collection
                var naam = from s in data.Streets
                    orderby s.Price ascending
                    group s by s;

                foreach (var i in naam)
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
        /// <param name="path"></param>
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
            [JsonProperty("streets")]
            public Street[] Streets { get; set; }
        }

        public partial class Street
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("cityName")]
            public string CityName { get; set; }

            [JsonProperty("price")]
            public long Price { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }
        }

        private void VolgordeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (volgordeBox.SelectedItem == hoogNaarLaagItm)
            {
                hoogNaarLaag = true;
                laagNaarHoog = false;
            }
            else
            {
                hoogNaarLaag = false;
                laagNaarHoog = true;
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            textPanel.Children.Clear();
            imagePanel.Children.Clear();
        }
    }
}
