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

namespace CodeForMom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "YouTube Video and Audio Downloader";
        }

        private void Download(object sender, RoutedEventArgs e)
        {
            if (VideoUrl.Text == String.Empty)
            {
                MessageBox.Show("Enter Video URL");
                return;
            }
            if (FileName.Text == String.Empty)
            {
                MessageBox.Show("Enter mp3 file url");
                return;
            }

            if (!(VideoUrl.Text.StartsWith("http://youtube.com") || VideoUrl.Text.StartsWith("https://youtube.com") || VideoUrl.Text.StartsWith("www.youtube.com") || VideoUrl.Text.StartsWith("http://www.youtube.com") || VideoUrl.Text.StartsWith("https://www.youtube.com")))
            {
                MessageBox.Show("Enter valid YouTube url");
                return;
            }

            String urlPath = VideoUrl.Text;
            String currentUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String dirPath = "C:\\Users\\" + currentUserName.Split('\\')[1] + "\\Music\\";
            String filePath = dirPath + "\\" + FileName.Text.Replace(" ", "") + ".mp3";
            String args = urlPath + " " + dirPath + " " + filePath;
            System.Diagnostics.Process.Start("xy.sh", args);

        }

        private void onURLBoxFocus(object sender, RoutedEventArgs e)
        {
            if (!(VideoUrl.Text.StartsWith("http://youtube.com") || VideoUrl.Text.StartsWith("https://youtube.com")) || VideoUrl.Text.StartsWith("www.youtube.com") || VideoUrl.Text.StartsWith("http://www.youtube.com") || VideoUrl.Text.StartsWith("https://www.youtube.com"))
            {
                VideoUrl.Text = Clipboard.GetText();
            }
        }
    }
}
