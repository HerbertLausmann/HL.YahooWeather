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
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace HL.YahooWeather
{
    /// <summary>
    /// Provides a simple wrapper for the Yahoo Weather WebService.
    /// To use it, just create an instance using Load(Location) or LoadAsync(Location) methods.
    /// This class can be instanced and binded in XAML.
    /// </summary>
    public class YahooWeather : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// For internal use only!
        /// Notifies that all the properties has changed
        /// </summary>
        protected void ChangedAll()
        {
            OnPropertyChanged("TwoWayBindableLocation");
            OnPropertyChanged("WeatherIcon");
            OnPropertyChanged("Query");
            OnPropertyChanged("PubDate");
            OnPropertyChanged("Longitude");
            OnPropertyChanged("Latitude");
            OnPropertyChanged("Forecasts");

            OnPropertyChanged("Astronomy");
            OnPropertyChanged("Atmosphere");
            OnPropertyChanged("Condition");
            OnPropertyChanged("Location");
            OnPropertyChanged("Units");
            OnPropertyChanged("Wind");
        }

        private string _TwoWayBindableLocation;
        /// <summary>
        /// For DataBinding purposes.
        /// This property can be used for a TwoWay Data Binding in XAML.
        /// When you change its value (A location), internally, it reloads all the forecast info for the given location.
        /// </summary>
        public string TwoWayBindableLocation
        {
            get
            {
                return (_Loader == null) ? _TwoWayBindableLocation : Location.ToString();
            }
            set
            {
                _Query = null; _Loader = null; _WeatherIcon = null;
                _TwoWayBindableLocation = value;
                if (value == null)
                {
                    ChangedAll();
                }
                else
                    Task.Run(async () =>
                    {
                        _IsLoading = true;
                        OnPropertyChanged("IsLoading");
                        await Init(new YahooWeatherLoader(value));
                        _IsLoading = false;
                        OnPropertyChanged("IsLoading");
                    });
            }
        }

        private bool _IsLoading;
        public bool IsLoading { get => _IsLoading; }

        #endregion

        #region Initialization
        public YahooWeather() { }
        internal YahooWeather(YahooWeatherLoader Loader)
        {
#pragma warning disable 4014
            Init(Loader);
        }

        private async Task Init(YahooWeatherLoader Loader)
        {
            _IsLoading = true;
            OnPropertyChanged("IsLoading");
            await Task.Run(() =>
            {
                try
                {
                    _Loader = Loader;
                    _Query = _Loader.GetWeatherData();

                    var ele = _Loader.Data.Descendants().First(x => x.Name == "description"
                    && x.Parent.Name == "item");

                    string picURL = Regex.Match(ele.Value, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?").Value;

                    System.Net.WebClient client = new System.Net.WebClient();
                    _WeatherIcon = client.DownloadData(picURL);
                }
                catch (Exception e)
                {
                    throw new System.Net.WebException(e.Message, e);
                }
            });
            _IsLoading = false;
            OnPropertyChanged("IsLoading");
            ChangedAll();
        }

        /// <summary>
        /// Creates and load an updated YahooWeather object that contains all the information about the weather of the given Location.
        /// </summary>
        /// <param name="Location">The name of the location that you want to check the forecast. For example: "New York NY United States"</param>
        /// <returns>Returns a YahooWeather object containing all the information for the given location</returns>
        public static YahooWeather Load(string Location)
        {
            YahooWeather weather = new YahooWeather(new YahooWeatherLoader(Location));
            return weather;
        }

        /// <summary>
        /// Creates and load, asynchronous, an updated YahooWeather object that contains all the information about the weather of the given Location.
        /// </summary>
        /// <param name="Location">The name of the location that you want to check the Weather conditions. For example: "New York NY United States"</param>
        /// <returns>Returns a YahooWeather object containing all the information for the given location</returns>
        public static async Task<YahooWeather> LoadAsync(string Location)
        {
            YahooWeather weather = new YahooWeather();
            await weather.Init(new YahooWeatherLoader(Location));
            return weather;
        }
        #endregion

        #region Components
        /// <summary>
        /// Forecast information about current astronomical conditions.
        /// </summary>
        public Components.Astronomy Astronomy
        {
            get
            {
                if (_Loader == null) return null;
                Components.Astronomy output = new Components.Astronomy();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "astronomy"));
                return output;
            }
        }
        /// <summary>
        /// Forecast information about current atmospheric pressure, humidity, and visibility.
        /// </summary>
        public Components.Atmosphere Atmosphere
        {
            get
            {
                if (_Loader == null) return null;
                Components.Atmosphere output = new Components.Atmosphere();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "atmosphere"));
                return output;
            }
        }
        /// <summary>
        /// The weather conditions
        /// </summary>
        public Components.Condition Condition
        {
            get
            {
                if (_Loader == null) return null;
                Components.Condition output = new Components.Condition();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "condition"));
                return output;
            }
        }
        /// <summary>
        /// The location of this forecast
        /// </summary>
        public Components.Location Location
        {
            get
            {
                if (_Loader == null) return null;
                Components.Location output = new Components.Location();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "location"));
                return output;
            }
        }
        /// <summary>
        /// The units used for various aspects of this forecast.
        /// </summary>
        public Components.Units Units
        {
            get
            {
                if (_Loader == null) return null;
                Components.Units output = new Components.Units();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "units"));
                return output;
            }
        }
        /// <summary>
        /// Forecast information about wind.
        /// </summary>
        public Components.Wind Wind
        {
            get
            {
                if (_Loader == null) return null;
                Components.Wind output = new Components.Wind();
                output.Load(_Loader.Data.Descendants().First(x => x.Name.LocalName == "wind"));
                return output;
            }
        }

        /// <summary>
        /// Returns the forecasts for today and the next 9 days.
        /// </summary>
        public ICollection<Components.Forecast> Forecasts
        {
            get
            {
                if (_Loader == null) return null;
                List<Components.Forecast> output = new List<Components.Forecast>();
                foreach (System.Xml.Linq.XElement element in _Loader.Data.Descendants().Where(x => x.Name.LocalName == "forecast"))
                {
                    Components.Forecast forecast = new Components.Forecast();
                    forecast.Load(element);
                    output.Add(forecast);
                }
                return output;
            }
        }
        #endregion

        #region Fields
        YahooWeatherLoader _Loader;
        private string _Query;
        private byte[] _WeatherIcon;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Latitude for the curren location
        /// </summary>
        public float Latitude
        {
            get
            {
                if (_Loader == null) return 0.0f;
                System.Xml.Linq.XElement element = _Loader.Data.Descendants().First(x => x.Name.LocalName == "lat");
                return Convert.ToSingle(element.Value, new System.Globalization.CultureInfo("en-US"));
            }
        }
        /// <summary>
        /// Gets the Longitude for the curren location
        /// </summary>
        public float Longitude
        {
            get
            {
                if (_Loader == null) return 0.0f;
                System.Xml.Linq.XElement element = _Loader.Data.Descendants().First(x => x.Name.LocalName == "long");
                return Convert.ToSingle(element.Value, new System.Globalization.CultureInfo("en-US"));
            }
        }

        /// <summary>
        /// Gets the date when this forecast and all of the underlying information has been released;
        /// </summary>
        public DateTime? PubDate
        {
            get
            {
                if (_Loader == null) return null;
                System.Xml.Linq.XElement element = _Loader.Data.Descendants().First(x => x.Name.LocalName == "pubDate");
                return DateTime.Parse(element.Value.Substring(0, 25), new System.Globalization.CultureInfo("en-US"));
            }
        }

        /// <summary>
        /// Returns the YQL query that was sent to Yahoo WebServices to get the data used to create this object
        /// </summary>
        public string Query { get => _Query; }

        /// <summary>
        /// Gets the byte array related to the Weather Icon sent by the Yahoo WebService.
        /// To use it, first load it into a MemoryStream object.
        /// Then, create a System.Drawing.Bitmap or System.Windows.Media.Imaging.BitmapImage or another object related to the platform that you are targeting.
        /// Normally, it's a static 52x52 pxs GIF image.
        /// </summary>
        public byte[] WeatherIcon { get => _WeatherIcon; }
        #endregion
    }
}