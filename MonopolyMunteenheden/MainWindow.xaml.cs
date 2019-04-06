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

        static string jsonString = "{ \"cities\": [ { \"name\": \"Ons_dorp\", \"streets\": [ { \"name\": \"Dorpsstraat\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Dorpsstraat.png\" }, { \"name\": \"Brink\", \"price\": 60, \"path\": \"/MonopolyCards/Ons_dorp/Brink.png\" } ] }, { \"name\": \"Arnhem\", \"streets\": [ { \"name\": \"Steenstraat\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Steenstraat.png\" }, { \"name\": \"Ketelstraat\", \"price\": 100, \"path\": \"/MonopolyCards/Arnhem/Ketelstraat.png\" }, { \"name\": \"Velperplein\", \"price\": 120, \"path\": \"/MonopolyCards/Arnhem/Velperplein.png\" } ] }, { \"name\": \"Haarlem\", \"streets\":[ { \"name\": \"Barteljorisstraat\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Barteljorisstraat.png\" }, { \"name\": \"Zijlweg\", \"price\": 140, \"path\": \"/MonopolyCards/Haarlem/Zijlweg.png\" }, { \"name\": \"Houtstraat\", \"price\": 160, \"path\": \"/MonopolyCards/Haarlem/Houtstraat.png\" } ] }, { \"name\": \"Utrecht\", \"streets\": [ { \"name\": \"Neude\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Neude.png\" }, { \"name\": \"Biltstraat\", \"price\": 180, \"path\": \"/MonopolyCards/Utrecht/Biltstraat.png\" }, { \"name\": \"Vreeburg\", \"price\": 200, \"path\": \"/MonopolyCards/Utrecht/Vreeburg.png\" } ] }, { \"name\": \"Groningen\", \"streets\":[ { \"name\": \"Akerkhof\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Akerkhof.png\" }, { \"name\": \"Grotemarkt\", \"price\": 220, \"path\": \"/MonopolyCards/Groningen/Grotemarkt.png\" }, { \"name\": \"Heerestraat\", \"price\": 240, \"path\": \"/MonopolyCards/Groningen/Heerestraat.png\" } ] }, { \"name\": \"Den_haag\", \"streets\": [ { \"name\": \"Spui\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Spui.png\" }, { \"name\": \"Plein\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Plein.png\" }, { \"name\": \"Lange_poten\", \"price\": 260, \"path\": \"/MonopolyCards/Den_haag/Lange_poten.png\" } ] }, { \"name\": \"Rotterdam\", \"streets\": [ { \"name\": \"Hofplein\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Hofplein.png\" }, { \"name\": \"Blaak\", \"price\": 300, \"path\": \"/MonopolyCards/Rotterdam/Blaak.png\" }, { \"name\": \"Coolsingel\", \"price\": 320, \"path\": \"/MonopolyCards/Rotterdam/Coolsingel.png\" } ] }, { \"name\": \"Amsterdam\", \"streets\": [ { \"name\": \"Leidsestraat\", \"price\": 350, \"path\": \"/MonopolyCards/Amsterdam/Leidsestraat.png\" }, { \"name\": \"Kalverstraat\", \"price\": 400, \"path\": \"/MonopolyCards/Amsterdam/Kalverstraat.png\" } ] }, { \"name\": \"Stations\", \"streets\": [ { \"name\": \"Station_noord\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_noord.png\" }, { \"name\": \"Station_oost\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_oost.png\" }, { \"name\": \"Station_zuid\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_zuid.png\" }, { \"name\": \"Station_west\", \"price\": 200, \"path\": \"/MonopolyCards/Stations/Station_west.png\" } ] }, { \"name\": \"Overig\", \"streets\": [ { \"name\": \"Waterleiding\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Waterleiding.png\" }, { \"name\": \"Elektriciteitsbedrijf\", \"price\": 300, \"path\": \"/MonopolyCards/Overig/Elektriciteitsbedrijf.png\" } ] } ] }";
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
        // Functie om een foto aan de stackpanel toe te voegen met een bepaalde path.
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
            MonopolyStreetData monopolyStreetData = new MonopolyStreetData();
            AddToTextBlock(data.Cities[1].Name); // I want to insert the name of a street from the city Amsterdam here
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
        }
    }
}
