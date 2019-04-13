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
        Random random = new Random();

        static string jsonString = "{ \"cities\": [ { \"name\": \"Ons_dorp\", \"streets\": [ { \"name\": \"Dorpsstraat\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Dorpsstraat.png\", \"bought\": false }, { \"name\": \"Brink\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Brink.png\", \"bought\": false } ] }, { \"name\": \"Arnhem\", \"streets\": [ { \"name\": \"Steenstraat\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Steenstraat.png\", \"bought\": false }, { \"name\": \"Ketelstraat\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Ketelstraat.png\", \"bought\": false }, { \"name\": \"Velperplein\", \"price\": 120, \"path\": \"/MonopolyCards/Arnhem/Velperplein.png\", \"bought\": false } ] }, { \"name\": \"Haarlem\", \"streets\":[ { \"name\": \"Barteljorisstraat\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Barteljorisstraat.png\", \"bought\": false }, { \"name\": \"Zijlweg\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Zijlweg.png\", \"bought\": false }, { \"name\": \"Houtstraat\", \"price\": 160, \"path\": \"/MonopolyCards/Haarlem/Houtstraat.png\", \"bought\": false } ] }, { \"name\": \"Utrecht\", \"streets\": [ { \"name\": \"Neude\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Neude.png\", \"bought\": false }, { \"name\": \"Biltstraat\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Biltstraat.png\", \"bought\": false }, { \"name\": \"Vreeburg\", \"price\": 200, \"path\": \"/MonopolyCards/Utrecht/Vreeburg.png\", \"bought\": false } ] }, { \"name\": \"Groningen\", \"streets\":[ { \"name\": \"Akerkhof\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Akerkhof.png\", \"bought\": false }, { \"name\": \"Grotemarkt\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Grotemarkt.png\", \"bought\": false }, { \"name\": \"Heerestraat\", \"price\": 240, \"path\": \"/MonopolyCards/Groningen/Heerestraat.png\", \"bought\": false } ] }, { \"name\": \"Den_haag\", \"streets\": [ { \"name\": \"Spui\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Spui.png\", \"bought\": false }, { \"name\": \"Plein\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Plein.png\", \"bought\": false }, { \"name\": \"Lange_poten\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Lange_poten.png\", \"bought\": false } ] }, { \"name\": \"Rotterdam\", \"streets\": [ { \"name\": \"Hofplein\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Hofplein.png\", \"bought\": false }, { \"name\": \"Blaak\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Blaak.png\", \"bought\": false }, { \"name\": \"Coolsingel\", \"price\": 320, \"path\": \"/MonopolyCards/Rotterdam/Coolsingel.png\", \"bought\": false } ] }, { \"name\": \"Amsterdam\", \"streets\": [ { \"name\": \"Leidsestraat\", \"price\": 350, \"path\": \"/MonopolyCards/Amsterdam/Leidsestraat.png\", \"bought\": false }, { \"name\": \"Kalverstraat\", \"price\": 400, \"path\": \"/MonopolyCards/Amsterdam/Kalverstraat.png\", \"bought\": false } ] }, { \"name\": \"Stations\", \"streets\": [ { \"name\": \"Station_noord\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_noord.png\", \"bought\": false }, { \"name\": \"Station_oost\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_oost.png\", \"bought\": false }, { \"name\": \"Station_zuid\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_zuid.png\", \"bought\": false }, { \"name\": \"Station_west\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_west.png\", \"bought\": false } ] }, { \"name\": \"Overig\", \"streets\": [ { \"name\": \"Waterleiding\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Waterleiding.png\", \"bought\": false }, { \"name\": \"Elektriciteitsbedrijf\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Elektriciteitsbedrijf.png\", \"bought\": false } ] } ] }";
        MonopolyStreetData data = JsonConvert.DeserializeObject<MonopolyStreetData>(jsonString);

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
            AddImage(AppDomain.CurrentDomain.BaseDirectory + "/MonopolyCards/Amsterdam/Kalverstraat.png");
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
            int highest = 0;
            foreach (var element in data.Cities)
            {
                if (element > highest)
                {
                    highest = element;
                }
            }
        }

        public partial class MonopolyStreetData
        {
            [JsonProperty("cities")]
            public City[] Cities { get; set; }
        }

        public partial class City
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("streets")]
            public Street[] Streets { get; set; }
        }

        public partial class Street
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("price")]
            public long Price { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("bought")]
            public bool Bought { get; set; }
        }
    }
}
