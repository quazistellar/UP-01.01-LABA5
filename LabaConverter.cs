using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UP_01._01.Laba_5
{
    internal class LabaConverter
    {

        public static T Deserialize0bject<T>() 
        
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == true)
            {
                if (Path.GetExtension(dialog.FileName) == ".json")
                {
                    string json = File.ReadAllText(dialog.FileName);
                    T obj = JsonConvert.DeserializeObject<T>(json);
                    return obj;
                }
                else
                {
                    MessageBox.Show("Выбранный файл не является JSON-файлом");
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
