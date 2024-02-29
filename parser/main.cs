using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;


namespace GameData
{
    class Cfg
    {
        public static string GetValue(string path, string key)
        {
            string result = "";
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                Regex regex = new Regex("\\b" + key + "\\b", RegexOptions.IgnoreCase);
                string? strEmpty;
                while ((strEmpty = reader.ReadLine()) != null)
                {
                    if (regex.IsMatch(strEmpty))
                    {
                        result = strEmpty;
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
            int countLine = 0;
            string result = "";
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                Regex regex = new Regex("\\b" + key + "\\b", RegexOptions.IgnoreCase);
                string? str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    countLine++;
                    if (regex.IsMatch(str))
                    {
                        result = str;
                        break;
                    }
                }
            }

            try
            {
                string allData = File.ReadAllText(path);
                string newData = allData.Replace(result, value);
                File.WriteAllText(path, newData);
            }
            catch
            {
                return;
            }

            
        }
    }

    class ServerInfo
    {
        public static void GetInfo()
        {
            var ipProps = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnections = ipProps.GetActiveTcpConnections();
 
            Console.WriteLine($"Всего {tcpConnections.Length} активных TCP-подключений");
            Console.WriteLine();
            foreach (var connection in tcpConnections)
            {
                Console.WriteLine("=============================================");
                Console.WriteLine($"Локальный адрес: {connection.LocalEndPoint.Address}:{connection.LocalEndPoint.Port}");
                Console.WriteLine($"Адрес удаленного хоста: {connection.RemoteEndPoint.Address}:{connection.RemoteEndPoint.Port}");
                Console.WriteLine($"Состояние подключения: {connection.State}");
        }
        }
    }
}