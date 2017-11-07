/*
 * HL.YahooWeather is a .NET Wrapper for the Yahoo Weather WebService!
 * It working by sending a request to Yahoo Services using YQL.
 * The web service returns a XML response that is parsed by this wrapper.
 * This API runs on .NET CORE 2.0.
 * 
 * You can modify this code as you want, but please, keep this header as it is!
 * All the rights for the Yahoo Weather Services belongs to Yahoo Holdings, Inc.
 * 
 * This Wrapper has been developed by Herbert Lausmann!
 * 
 * Herbert Lausmann
 * November 2017
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HL.YahooWeather.Globalization
{
    internal static class Globalization
    {
        internal static Task<string> GetTextAsync(int code)
        {
            return Task.Run<string>(() =>
            {
                string databasePath = string.Format("HL.YahooWeather.Globalization.{0}.txt", CultureInfo.CurrentUICulture.Name);
                if (!Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(databasePath))
                {
                    databasePath = string.Format("HL.YahooWeather.Globalization.{0}.txt", "en-US");
                }
                Stream databaseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(databasePath);
                StreamReader reader = new StreamReader(databaseStream);
                Dictionary<int, string> data = new Dictionary<int, string>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    data.Add(int.Parse(line.Split(' ')[0]), line.Remove(0, line.Split(' ')[0].Length + 1));
                }
                return data[code];
            });
        }
    }
}
