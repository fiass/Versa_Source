using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SetupVersa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Page_1.Visibility = Visibility.Visible;
            Page_2.Visibility = Visibility.Hidden;
            Page_3.Visibility = Visibility.Hidden;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page_1.Visibility = Visibility.Hidden;
            Page_2.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        internal static string Path;
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Setup", $@"{Path}\Versa-Setup.zip");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
            }
            using (ZipFile zip = ZipFile.Read($@"{Path}\Versa-Setup.zip", new ReadOptions { Encoding = Encoding.GetEncoding("cp866") }))
            {
                foreach (ZipEntry eq in zip)
                {
                    eq.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                    eq.ExtractWithPassword(Path, new string(CharCrypt.SetupVersa_Crypt.Char_1));
                }
            }
            File.Delete($@"{Path}\Versa-Setup.zip");
            Page_1.Visibility = Visibility.Hidden;
            Page_2.Visibility = Visibility.Hidden;
            Page_3.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = FBD.SelectedPath;
                FolderPath.Content = "Path: " + Path + " Right?";
            }
        }
    }
}
