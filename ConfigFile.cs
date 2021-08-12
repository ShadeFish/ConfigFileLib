using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConfigFileLib
{
    public class ConfigFile
    {
        private string path;
        private char separator = '=';
        public ConfigFile(string path) 
        {
            if(!File.Exists(path)) { File.WriteAllText(path,""); }
            this.path = path;
        }

        public string GetValue(string key)
        {
            string value = string.Empty;
            foreach(string line in File.ReadAllLines(path))
            {
                if(line.Split(separator)[0] == key)
                {
                    value = line.Split(separator)[1];
                }
            }
            return value;
        }

        public void SetValue(string key,string value)
        {
            string[] fileContent = File.ReadAllLines(path);
            List<string> newFileContent = new List<string>();
            if(fileContent.Length > 0)
            {
                foreach(string line in fileContent)
                {
                    if(line.Split(separator)[0] == key)
                    {
                        newFileContent.Add(key + separator + value);
                    }
                    else
                    {
                        newFileContent.Add(line);
                    }
                }
            }
            else
            {
                newFileContent.Add(key + separator + value);
            }
            
            File.WriteAllLines(path, newFileContent.ToArray());
        }
    }
}
