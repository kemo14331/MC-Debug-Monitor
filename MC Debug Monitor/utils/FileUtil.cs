using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace MC_Debug_Monitor.utils
{
    public static class FileUtil
    {
        /// <summary>
        /// サーバープロパティの読み込み
        /// </summary>
        /// <returns> <key, value>  </returns>
        public static Dictionary<string, string> getServerProperties(Stream stream)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(stream);
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                if (!str[0].Equals("#") && str.IndexOf("=") != -1)
                {
                    int keyIndex = str.IndexOf("=");
                    string key = str.Substring(0, keyIndex);
                    string value;
                    if (keyIndex + 1 <= str.Length - 1)
                    {
                        value = str.Substring(keyIndex + 1, str.Length - (keyIndex + 1));
                    }
                    else
                    {
                        value = null;
                    }
                    properties.Add(key, value);
                }
            }
            return properties;
        }


        /// <summary>
        /// mcFunctionの読み込み
        /// </summary>
        /// <returns> コマンド文字列のList </returns>
        public static List<string> loadMCFunction(Stream stream)
        {
            List<string> commands = new List<string>();
            StreamReader sr = new System.IO.StreamReader(stream);
            string line = sr.ReadLine();
            if (!line[0].Equals("#"))
            {
                commands.Add(line);
            }
            return commands;
        }

        /// <summary>
        ///  DataTableをCSVで保存
        /// </summary>
        /// <param name="dataTable">保存するDataTable</param>
        /// <param name="filePath">パス</param>
        public static void saveDataTableToCSV(this DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            File.WriteAllText(filePath, fileContent.ToString());
        }

        /// <summary>
        ///  DataTableをJsonで保存
        /// </summary>
        /// <param name="dataTable">保存するDataTable</param>
        /// <param name="filePath">パス</param>
        public static void saveDataTableToJson(DataTable datatable, string filePath)
        {

            string json = JsonConvert.SerializeObject(datatable);
            File.WriteAllText(filePath, json);
        }
    }
}
