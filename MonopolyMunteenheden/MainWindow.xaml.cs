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
            AddImage(AppDomain.CurrentDomain.BaseDirectory + "\\MonopolyCards\\Amsterdam\\Kalverstraat.png");
        }

        #region Afbeelding toevoegen en text toevoegen functies
        // Functie om een foto aan de stackpanel toe te voegen met een bepaalde path.
        public void AddImage(string path)
        {
            Image image = new Image();
            image.Source = new ImageSourceConverter().ConvertFromString(path) as ImageSource;
            image.Stretch = Stretch.Fill;
            image.Height = 245;
            image.Width = 160;
            imagePanel.Children.Add(image);
        }

        public void AddToTextBlock(string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textPanel.Children.Add(textBlock);
        }
        #endregion

        private void BerekenBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            AddImage(AppDomain.CurrentDomain.BaseDirectory + "\\MonopolyCards\\Amsterdam\\Leidsestraat.png");
        }

        private void AddText_Click(object sender, RoutedEventArgs e)
        {
            AddToTextBlock("sup");
        }
    }
}
