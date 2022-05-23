using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace WCFDropBoxClone
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде и файле конфигурации.
    public class Service : IService
    {
        //SqlConnection connect;
        string connectStr = "server=localhost;uid=root;pwd=Act1@BefM;database=dropboxclonedb";
        public void DBConnect()
        {
            MySqlConnection connect = new MySqlConnection(connectStr);
            connect.Open();
        }
        public void AddFile()
        {
            MySqlConnection connect = new MySqlConnection(connectStr);
            MySqlCommand command = new MySqlCommand("select * from filestable", connect);
            connect.Open();           
            string filePath;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                command.CommandText = @"INSERT INTO filestable VALUES (@FileName, @FileSize, @FileBinary)";
                command.Parameters.Add("@FileName", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@FileSize", MySqlDbType.Float);
                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                float fileSize = new FileInfo(filePath).Length;
                byte[] FileData;
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    FileData = new byte[fs.Length];
                    fs.Read(FileData, 0, FileData.Length);
                    command.Parameters.Add("@FileBinary", MySqlDbType.VarBinary, Convert.ToInt32(fs.Length));
                }
                command.Parameters["@FileName"].Value = fileName;
                command.Parameters["@FileSize"].Value = fileSize;
                command.Parameters["@FileBinary"].Value = FileData;
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFile()
        {
            throw new NotImplementedException();
        }

        public void DownloadFile()
        {
            throw new NotImplementedException();
        }
    }
}
