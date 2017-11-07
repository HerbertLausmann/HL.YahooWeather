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
    public class Forecast : ComponentBase
    {
        /// <summary>
        /// Code: the condition code for this forecast.
        /// You could use this code to choose a text description or image for the forecast.
        /// The possible values for this element are described in Conditions enum (integer)
        /// </summary>
        public Conditions Code
        {
            get { return (Conditions)Enum.Parse(typeof(Conditions), Element.Attribute(System.Xml.Linq.XName.Get("code")).Value, true); }
        }
        /// <summary>
        /// High: the forecasted high temperature for this day, in the units specified by the Units object (integer)
        /// </summary>
        public int High
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("high")).Value, new System.Globalization.CultureInfo("en-US")); }
        }
        /// <summary>
        /// Low: the forecasted low temperature for this day, in the units specified by the Units object (integer)
        /// </summary>
        public int Low
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("low")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// Text: a textual description of conditions, for example, "Partly Cloudy" (string)
        /// </summary>
        public string Text
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("text")).Value; }
        }

        /// <summary>
        /// Date: the date to which this forecast applies.
        /// </summary>
        public DateTime Date
        {
            get { return DateTime.Parse(Element.Attribute(System.Xml.Linq.XName.Get("date")).Value, new System.Globalization.CultureInfo("en-US")); }
        }
    }
}
