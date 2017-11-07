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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HL.YahooWeather.Components
{
    /// <summary>
    /// For internal use only: The base class for all components of a given Forecast.
    /// It encapsulates a XElement...
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ComponentBase
    {
        protected System.Xml.Linq.XElement Element;
        internal ComponentBase() { }
        internal virtual void Load(System.Xml.Linq.XElement Source)
        {
            Element = Source;
        }
    }
}
