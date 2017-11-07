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
    /// Units for various aspects of the forecast
    /// </summary>
    public class Units : ComponentBase
    {
        /// <summary>
        /// Distance: units for distance, mi for miles or km for kilometers (string)
        /// </summary>
        public string Distance
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("distance")).Value; }
        }

        /// <summary>
        /// Pressure: units of barometric pressure, in for pounds per square inch or mb for millibars (string)
        /// </summary>
        public string Pressure
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("pressure")).Value; }
        }

        /// <summary>
        /// Speed: units of speed, mph for miles per hour or kph for kilometers per hour (string)
        /// </summary>
        public string Speed
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("speed")).Value; }
        }

        /// <summary>
        /// Temperature: degree units, f for Fahrenheit or c for Celsius (character)
        /// </summary>
        public char Temperature
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("temperature")).Value[0]; }
        }

        public static float FahrenheitToCelsius(float Fahrenheit)
        {
            return (float)(5.0 / 9.0 * (Fahrenheit - 32));
        }
        public static float ConvertCelsiusToFahrenheit(float Celsius)
        {
            return (float)((9.0 / 5.0) * Celsius) + 32;
        }
        public static float MilesToKilometers(float miles)
        {
            return (float)(miles * 1.609344);
        }
    }
}
