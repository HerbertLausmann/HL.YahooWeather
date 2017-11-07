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
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;

namespace HL.YahooWeather
{
    /// <summary>
    /// Internal use only.
    /// Provides a simple way for creating YQL queries related to Weather for the Yahoo WebServices.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class YahooWeatherLoader
    {
        #region Query
        internal YahooWeatherLoader(string Location)
        {
            _location = Location;
        }
        private string _location;
        internal string Location
        {
            get { return _location; }
        }
        internal string GetWeatherData()
        {
            RegionInfo region = RegionInfo.CurrentRegion;
            string query = @"https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=" +
                string.Format("{0}{1}{0}", "\"", _location) +
                string.Format(") and u=\"{0}\"&format=xml", region.IsMetric ? "c" : "f");
            string queryUri = Uri.EscapeUriString(query);
            System.Net.WebRequest queryRequest = System.Net.WebRequest.Create(queryUri);
            System.Net.WebResponse queryResponse = queryRequest.EndGetResponse(queryRequest.BeginGetResponse(null, null));
            System.IO.Stream queryResponseStream = queryResponse.GetResponseStream();
            System.Xml.Linq.XDocument queryResponseDocument = System.Xml.Linq.XDocument.Load(queryResponseStream);
            _data = queryResponseDocument;
            return query;
        }
        #endregion
        private System.Xml.Linq.XDocument _data;
        internal System.Xml.Linq.XDocument Data
        {
            get { return _data; }
        }
    }
}
