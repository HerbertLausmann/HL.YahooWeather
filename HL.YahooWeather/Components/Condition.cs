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
    /// The weather conditions
    /// </summary>
    public class Condition : ComponentBase
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
        /// The current temperature, in the units specified by the Units object (integer)
        /// </summary>
        public int Temperature
        {
            get { return Convert.ToInt32(Element.Attribute(System.Xml.Linq.XName.Get("temp")).Value, new System.Globalization.CultureInfo("en-US")); }
        }

        /// <summary>
        /// Text: a textual description of conditions, for example, "Partly Cloudy" (string)
        /// </summary>
        public string Text
        {
            get { return Element.Attribute(System.Xml.Linq.XName.Get("text")).Value; }
        }

        /// <summary>
        /// Text: a textual description of conditions, for example, "Partly Cloudy" (string).
        /// This Property returns the same of the Text property, but translated (if any translation is available) to the OS language.
        /// </summary>
        public string CurrentCultureText
        {
            get
            {
                var task = Globalization.Globalization.GetTextAsync(Convert.ToInt32(Code));
                task.Wait();
                return task.Result;
            }
        }

        /// <summary>
        /// Date: the current date and time for which this forecast applies.
        /// </summary>
        public DateTime Date
        {
            get
            {
                string strDate = Element.Attribute(System.Xml.Linq.XName.Get("date")).Value;
                strDate = strDate.Substring(0, 25);
                return DateTime.Parse(strDate, new System.Globalization.CultureInfo("en-US"));
            }
        }
    }

    /// <summary>
    /// Contains all the possible condition codes for a forecast.
    /// </summary>
    public enum Conditions : int
    {
        tornado = 0,
        tropical_storm = 1,
        hurricane = 2,
        severe_thunderstorms = 3,
        thunderstorms = 4,
        mixed_rain_and_snow = 5,
        mixed_rain_and_sleet = 6,
        mixed_snow_and_sleet = 7,
        freezing_drizzle = 8,
        drizzle = 9,
        freezing_rain = 10,
        showers = 11,
        showers_ = 12,
        snow_flurries = 13,
        light_snow_showers = 14,
        blowing_snow = 15,
        snow = 16,
        hail = 17,
        sleet = 18,
        dust = 19,
        foggy = 20,
        haze = 21,
        smoky = 22,
        blustery = 23,
        windy = 24,
        cold = 25,
        cloudy = 26,
        mostly_cloudy_night = 27,
        mostly_cloudy_day = 28,
        partly_cloudy_night = 29,
        partly_cloudy_day = 30,
        clear_night = 31,
        sunny = 32,
        fair_night = 33,
        fair_day = 34,
        mixed_rain_and_hail = 35,
        hot = 36,
        isolated_thunderstorms = 37,
        scattered_thunderstorms = 38,
        scattered_thunderstorms_ = 39,
        scattered_showers = 40,
        heavy_snow = 41,
        scattered_snow_showers = 42,
        heavy_snow_ = 43,
        partly_cloudy = 44,
        thundershowers = 45,
        snow_showers = 46,
        isolated_thundershowers = 47,
        not_available = 3200
    };
}

