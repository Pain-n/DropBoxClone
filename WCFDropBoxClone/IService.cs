using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace WCFDropBoxClone
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {
        [OperationContract (IsOneWay = true)]
        void AddFile(string filePath, byte[] FileData,float FileSize);
        [OperationContract]
        void DeleteFile(int id);
        [OperationContract]
        DownLoadFileData DownloadFile(int id);

        [OperationContract]
        DataTableToGrid LoadDBToDataGrid();

    }
    [DataContract]
    public class DataTableToGrid
    {
        [DataMember]
        public DataTable FileTable
        {
            get;
            set;
        }
    }
    public class DownLoadFileData
    {
        [DataMember]
        public byte[] data
        {
            get;
            set;
        }
        [DataMember]
        public string FileName
        {
            get;
            set;
        }
    }
}
