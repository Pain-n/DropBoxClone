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
        string connectStr = "server=localhost;uid=root;pwd=Act1@BefM";

        public void AddFile(string filePath, byte[] FileData, float FileSize)
        {
            MySqlConnection connect = new MySqlConnection(connectStr);
            connect.Open();
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            string Query = "insert into dropboxclonedb.filestable(FileName,FileSize,FileBinary) values('" + fileName + "','" + FileSize + "','" + FileData + "');";
            MySqlCommand command = new MySqlCommand(Query, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void DeleteFile(int id)
        {
            MySqlConnection connect = new MySqlConnection(connectStr);
            connect.Open();
            string Query = "delete from dropboxclonedb.filestable where id="+id;
            MySqlCommand command = new MySqlCommand(Query, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        public DownLoadFileData DownloadFile(int id)
        {
            DownLoadFileData FileData = new DownLoadFileData();
            byte[] data;
            string name;
            MySqlConnection connect = new MySqlConnection(connectStr);
            connect.Open();
            string Query = "select id,FileName,FileSize,FileBinary from dropboxclonedb.filestable where id=" + id;
            MySqlCommand command = new MySqlCommand(Query, connect);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float FileSize = (float)reader["FileSize"];
            int FileSizeConv = (int)FileSize;
            data = new byte[FileSizeConv];
            reader.GetBytes(reader.GetOrdinal("FileBinary"), 0, data, 0, FileSizeConv);
            //data = (byte[])reader["FileBinary"];
            name = (string)reader["FileName"];
            FileData.data = data;
            FileData.FileName = name;
            connect.Close();
            return FileData;
        }
        public DataTableToGrid LoadDBToDataGrid()
        {
            DataTableToGrid fileTable = new DataTableToGrid();
            DataTable dataTable = new DataTable("FileTable");
            MySqlConnection connect = new MySqlConnection(connectStr);
            connect.Open();
            string Query = "select id,FileName,FileSize from dropboxclonedb.filestable";
            MySqlCommand command = new MySqlCommand(Query, connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            fileTable.FileTable = dataTable;
            connect.Close();
            return fileTable;
        }
    }
}
