using System.IO;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Parser
{


    class Cfg
    {
        public static string GetValue(string path, string key)
        {
            string result = "";
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                Regex regex = new Regex("\\b" + key + "\\b", RegexOptions.IgnoreCase);
                string str = null;
                while ((str = reader.ReadLine()) != null)
                {
                    if (regex.IsMatch(str))
                    {
                        result = str;
                        break;
                    }
                }
            }
            try
            {
                return result.Split("\"")[1];
            }
            catch
            {
                return "Unable to read file";
            }
        }

        public static void NewValue(string path, string key, string value)
        {
            int CountLine = 0;
            string result = "";
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                Regex regex = new Regex("\\b" + key + "\\b", RegexOptions.IgnoreCase);
                string str = null;
                while ((str = reader.ReadLine()) != null)
                {
                    CountLine++;
                    if (regex.IsMatch(str))
                    {
                        result = str;
                        //Console.WriteLine(CountLine);
                        break;
                    }
                }
            }
            string AllData = File.ReadAllText(path);
            string NewData = AllData.Replace(result, value);
            File.WriteAllText(path, NewData);
            
        }
    }
}
