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

namespace HL.YahooWeather.Components
{
    /// <summary>
    /// The location of the forecast
    /// </summary>
    public class Location : ComponentBase
    {
        /// <summary>
        /// City name (string)
        /// </summary>
        public string City
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("city")).Value; }
        }

        /// <summary>
        /// Country (string)
        /// </summary>
        public string Country
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("country")).Value; }
        }

        /// <summary>
        /// State, territory, or region, if given (string)
        /// </summary>
        public string Region
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("region")).Value; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", City, Region, Country);
        }
    }
}
