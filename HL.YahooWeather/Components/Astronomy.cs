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
    /// Forecast information about current astronomical conditions.
    /// </summary>
    public class Astronomy : ComponentBase
    {
        /// <summary>
        /// Sunrise: today's sunrise time.
        /// The time is a string in a local time format of "h:mm am/pm", for example "7:02 am" (DateTime)
        /// </summary>
        public DateTime SunRise
        {
            get
            {
                string strDate = Element.Attribute(System.Xml.Linq.XName.Get("sunrise")).Value;
                strDate = strDate.Substring(0, strDate.IndexOf('m') + 1);
                return DateTime.Parse(strDate, new System.Globalization.CultureInfo("en-US"));
            }
        }
        /// <summary>
        /// Sunset: today's sunset time. The time is a string in a local time format of "h:mm am/pm", for example "4:51 pm" (DateTime)
        /// </summary>
        public DateTime SunSet
        {
            get
            {
                string strDate = Element.Attribute(System.Xml.Linq.XName.Get("sunset")).Value;
                strDate = strDate.Substring(0, strDate.IndexOf('m') + 1);
                return DateTime.Parse(strDate, new System.Globalization.CultureInfo("en-US"));
            }
        }
    }
}
