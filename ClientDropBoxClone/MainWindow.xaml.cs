using MySqlConnector;
using NLog;
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
            client = new Service.ServiceClient();
            //Logs
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Trace("trace message");
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");
        }
        private void DBTableLoad()
        {
            Service.DataTableToGrid data = new Service.DataTableToGrid();
            DataTable dataTable = new DataTable();
            data = client.LoadDBToDataGrid();
            dataTable = data.FileTable;
            FileListDataGrid.ItemsSource = dataTable.DefaultView;
        }
        //ForUnitTest
        public int CountSum(int i, int y)
        {
            return i + y;
        }
        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {

            string filePath;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = ofd.FileName;
                byte[] FileData;
                float FileSize = new FileInfo(filePath).Length;
                //using (FileStream fs = new FileStream(filePath, FileMode.Open))
                //{
                    //FileData = new byte[(int)FileSize];
                    FileData = File.ReadAllBytes(filePath);
                //    fs.Read(FileData, 0, FileData.Length);
                //}
                client.AddFile(filePath, FileData, FileSize);
            }
            DBTableLoad();
        }

        private void AppMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DBTableLoad();
        }

        private void DeleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            if(FileListDataGrid.SelectedItem != null)
            {
                 DataRowView row = (DataRowView)FileListDataGrid.SelectedItems[0];
                int id = (int)row["id"];
                client.DeleteFile(id);
                DBTableLoad();
            }
        }

        private void DownloadFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileListDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)FileListDataGrid.SelectedItems[0];
                int id = (int)row["id"];
                byte[] FileData;
                string fileName;
                Service.DownLoadFileData fileDataServ = new Service.DownLoadFileData();
                fileDataServ = client.DownloadFile(id);
                fileName = fileDataServ.FileName;
                FileData = fileDataServ.data;
                string ext = System.IO.Path.GetExtension(fileName);
                //Stream stream;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "All files (*" + ext + ")| *" + ext;
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //stream = saveFileDialog.OpenFile();
                    //stream.Write(FileData, 0, FileData.Length);
                    File.WriteAllBytes(System.IO.Path.GetFullPath(saveFileDialog.FileName), FileData);
                    //stream.Close();
                }
            }
        }
    }
}
