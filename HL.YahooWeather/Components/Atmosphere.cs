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
    /// Forecast information about current atmospheric pressure, humidity, and visibility.
    /// </summary>
    public class Atmosphere : ComponentBase
    {
        /// <summary>
        /// Air Humidity, in percent (integer)
        /// </summary>
        public int Humidity
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("humidity")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// Barometric pressure, in the units specified by the Pressure property of the Units object (in or mb). (float).
        /// </summary>
        public float Pressure
        {
            get { return Convert.ToSingle(Element.Attribute(System.Xml.Linq.XName.Get("pressure")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// State of the barometric pressure: steady (0), rising (1), or falling (2). (integer: 0, 1, 2)
        /// </summary>
        public int Rising
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("rising")).Value, new System.Globalization.CultureInfo("en-US")); }
        }
        /// <summary>
        /// Visibility, in the units specified by the Distance property of the Units object (mi or km).
        /// Note that the visibility is specified as the actual value * 100. For example, a visibility of 16.5 miles will be specified as 1650. A visibility of 14 kilometers will appear as 1400. (integer)
        /// </summary>
        public int Visibility
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("visibility")).Value, new System.Globalization.CultureInfo("en-US")); }
        }
    }
}
