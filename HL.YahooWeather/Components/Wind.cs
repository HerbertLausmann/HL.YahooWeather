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
    /// Forecast information about wind.
    /// </summary>
    public class Wind : ComponentBase
    {
        /// <summary>
        /// Chill: wind chill in degrees (integer)
        /// </summary>
        public int Chill
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("chill")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// Direction: wind direction, in degrees (integer)
        /// </summary>
        public float Direction
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("direction")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// Speed: wind speed, in the units specified in the Speed property of the Units object (mph or kph). (integer)
        /// </summary>
        public float Speed
        {
            get { return Convert.ToSingle(Element.Attribute(System.Xml.Linq.XName.Get("speed")).Value, new System.Globalization.CultureInfo("en-US")); }
        }
    }
}
