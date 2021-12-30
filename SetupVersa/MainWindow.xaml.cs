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
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-1.bin", $@"{Path}\CharCrypt.dll");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-2.bin", $@"{Path}\DotNetZip.dll");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-3.bin", $@"{Path}\LiteDatabase.dll");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
                if (!Directory.Exists($@"{Path}\Plugins"))
                {
                    Directory.CreateDirectory($@"{Path}\Plugins");
                }
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-4.bin", $@"{Path}\Plugins\AutoUpdate.dll");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
                if (!Directory.Exists($@"{Path}\Mods"))
                {
                    Directory.CreateDirectory($@"{Path}\Mods");
                }
                client.DownloadFile("https://raw.githubusercontent.com/fiass/Versa/Versa-Data/Loader/Versa-Module-5.bin", $@"{Path}\Mods\Versa.dll");
                while (client.IsBusy)
                {
                    await Task.Delay(100);
                }
            }
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
