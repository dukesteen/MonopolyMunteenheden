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
        Random random = new Random();

        static string jsonString = "{ \"streets\": [ { \"name\": \"Dorpsstraat\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Dorpsstraat.png\", \"bought\": false }, { \"name\": \"Brink\", \"cityName\": \"Ons_dorp\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Brink.png\", \"bought\": false }, { \"name\": \"Steenstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Steenstraat.png\", \"bought\": false }, { \"name\": \"Ketelstraat\", \"cityName\": \"Arnhem\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Ketelstraat.png\", \"bought\": false }, { \"name\": \"Velperplein\", \"cityName\": \"Arnhem\", \"price\": 120, \"path\": \"/MonopolyCards/Arnhem/Velperplein.png\", \"bought\": false }, { \"name\": \"Barteljorisstraat\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Barteljorisstraat.png\", \"bought\": false }, { \"name\": \"Zijlweg\", \"cityName\": \"Haarlem\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Zijlweg.png\", \"bought\": false }, { \"name\": \"Houtstraat\", \"cityName\": \"Haarlem\", \"price\": 160, \"path\": \"/MonopolyCards/Haarlem/Houtstraat.png\", \"bought\": false }, { \"name\": \"Neude\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Neude.png\", \"bought\": false }, { \"name\": \"Biltstraat\", \"cityName\": \"Utrecht\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Biltstraat.png\", \"bought\": false }, { \"name\": \"Vreeburg\", \"cityName\": \"Utrecht\", \"price\": 200, \"path\": \"/MonopolyCards/Utrecht/Vreeburg.png\", \"bought\": false }, { \"name\": \"Akerkhof\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Akerkhof.png\", \"bought\": false }, { \"name\": \"Grotemarkt\", \"cityName\": \"Groningen\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Grotemarkt.png\", \"bought\": false }, { \"name\": \"Heerestraat\", \"cityName\": \"Groningen\", \"price\": 240, \"path\": \"/MonopolyCards/Groningen/Heerestraat.png\", \"bought\": false }, { \"name\": \"Spui\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Spui.png\", \"bought\": false }, { \"name\": \"Plein\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Plein.png\", \"bought\": false }, { \"name\": \"Lange_poten\", \"cityName\": \"Den_haag\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Lange_poten.png\", \"bought\": false }, { \"name\": \"Hofplein\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Hofplein.png\", \"bought\": false }, { \"name\": \"Blaak\", \"cityName\": \"Rotterdam\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Blaak.png\", \"bought\": false }, { \"name\": \"Coolsingel\", \"cityName\": \"Rotterdam\", \"price\": 320, \"path\": \"/MonopolyCards/Rotterdam/Coolsingel.png\", \"bought\": false }, { \"name\": \"Leidsestraat\", \"cityName\": \"Amsterdam\", \"price\": 350, \"path\": \"/MonopolyCards/Amsterdam/Leidsestraat.png\", \"bought\": false }, { \"name\": \"Kalverstraat\", \"cityName\": \"Amsterdam\", \"price\": 400, \"path\": \"/MonopolyCards/Amsterdam/Kalverstraat.png\", \"bought\": false }, { \"name\": \"Station_noord\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_noord.png\", \"bought\": false }, { \"name\": \"Station_oost\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_oost.png\", \"bought\": false }, { \"name\": \"Station_zuid\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_zuid.png\", \"bought\": false }, { \"name\": \"Station_west\", \"cityName\": \"Stations\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_west.png\", \"bought\": false }, { \"name\": \"Waterleiding\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Waterleiding.png\", \"bought\": false }, { \"name\": \"Elektriciteitsbedrijf\", \"cityName\": \"Overig\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Elektriciteitsbedrijf.png\", \"bought\": false } ] }";
        StreetData data = JsonConvert.DeserializeObject<StreetData>(jsonString);

        public MainWindow()
        {
            InitializeComponent();
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

        private void BerekenBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in data.Streets)
            {
                AddImage(AppDomain.CurrentDomain.BaseDirectory + i.Path);
            }
        }

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

        private void AddText_Click(object sender, RoutedEventArgs e)
        {
            // Selecteer de prijs van Dorpsstraat
            var naam = from s in data.Streets
                       where s.Bought == false
                       orderby s.Price descending 
                       group s by s;

            foreach (var i in naam)
            {
                if (bedrag <= i.FirstOrDefault().Price) continue;
                AddToTextBlock(i.FirstOrDefault().Name + ": Bought");
                AddImage(AppDomain.CurrentDomain.BaseDirectory + i.FirstOrDefault().Path);
                bedrag -= Convert.ToInt32(i.FirstOrDefault().Price);
            }

            AddToTextBlock("Remaining amount: " + bedrag);
        }

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

            [JsonProperty("bought")]
            public bool Bought { get; set; }
        }

        private void BedragTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool success = Int32.TryParse(bedragTxtBox.Text, out bedrag);
        }
    }
}
