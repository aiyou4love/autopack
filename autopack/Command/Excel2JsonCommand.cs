using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel;
using System.Data;

namespace autopack
{
    [Serializable]
    public class Excel2JsonCommand : AbstractCommand
    {
        List<TableRow> mTableRow = new List<TableRow>();
        void runDirectory(string nDirectory, string nDestDirectory)
        {
            DirectoryInfo directoryInfo_ = new DirectoryInfo(nDirectory);
            foreach (FileInfo fileInfo_ in directoryInfo_.GetFiles())
            {
                this.runFile(fileInfo_.FullName, nDestDirectory);
            }
            foreach (DirectoryInfo suDirectory_ in directoryInfo_.GetDirectories())
            {
                string path_ = Path.Combine(nDirectory, suDirectory_.Name);
                this.runDirectory(path_, nDestDirectory);
            }
        }
        void runDataSet(DataTable nDataTable, string nDestDirectory)
        {
            if (nDataTable.Columns.Count <= 0) return;
            if (nDataTable.Rows.Count <= 0) return;
            for ( int i = 0; i < nDataTable.Rows.Count; i++ )
            {
                DataRow dataRow_ = nDataTable.Rows[i];
                foreach (DataColumn j in nDataTable.Columns)
                {
                    object value_ = dataRow_[j];
                    if (value_.GetType() == typeof(double))
                    {
                        double number_ = (double)value_;
                        if ((int)number_ == number_)
                        {
                            value_ = (int)number_;
                        }
                    }
                    string fieldName_ = j.ToString();
                    //if (!string.IsNullOrEmpty(fieldName_))
                    //    rowData[fieldName_] = value_;
                }
            }
        }
        void runFile(string nFile, string nDestDirectory)
        {
            FileStream excelFile_ = File.Open(nFile, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader_ = ExcelReaderFactory.CreateOpenXmlReader(excelFile_);
            excelReader_.IsFirstRowAsColumnNames = true;
            DataSet excelData_ = excelReader_.AsDataSet();
            for ( int i = 0; i < excelData_.Tables.Count; ++i )
            {
                this.runDataSet(excelData_.Tables[i], nDestDirectory);
            }
        }

        public override void runCommand(string nBundleXml)
        {
            Bundle bundle_ = Deserialize<Bundle>(nBundleXml);
            if (!(bundle_.mDirectorys.ContainsKey(mSourceDirectory)))
            {
                Console.WriteLine("mDirectorys key:{0},{1}", mSourceDirectory, "Excel2JsonCommand::runCommand");
                Console.ReadKey(true);
                return;
            }
            string sourceDirectory_ = bundle_.mDirectorys[mSourceDirectory];

            if (!(bundle_.mDirectorys.ContainsKey(mDestDirectory)))
            {
                Console.WriteLine("mDirectorys key:{0},{1}", mDestDirectory, "Excel2JsonCommand::runCommand");
                Console.ReadKey(true);
                return;
            }
            string destDirectory_ = bundle_.mDirectorys[mDestDirectory];

            foreach (string i in mDirectorys)
            {
                string directory_ = Path.Combine(sourceDirectory_, i);
                this.runDirectory(directory_, destDirectory_);
            }
            foreach (string i in mFiles)
            {
                string file_ = Path.Combine(sourceDirectory_, i);
                this.runFile(file_, destDirectory_);
            }
        }

        public List<string> mDirectorys { get; set; }
        public List<string> mFiles { get; set; }
        public string mSourceDirectory { get; set; }
        public string mDestDirectory { get; set; }
    }
}
