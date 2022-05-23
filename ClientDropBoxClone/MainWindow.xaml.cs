using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
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

namespace ClientDropBoxClone
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service.ServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            client = new Service.ServiceClient();
            client.DBConnect();
        }
        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            if(client != null)
            {
                TextBox.Text = client.ToString();
                client.AddFile();
            }            
        }
    }
}
