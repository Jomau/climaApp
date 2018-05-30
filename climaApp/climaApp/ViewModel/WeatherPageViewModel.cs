using System;
using System.Collections.Generic;
using System.Text;

namespace climaApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Model;


    public class WeatherPageViewModel : NotificableViewModel
    {
        #region Atributos
        private string ubicacion;
        private string pais;
        private string resulTerm;
        private string region;
        private string ultimaActualizacion;
        private string clima;
        private string temperatura;
        private ImageSource imagen;
        #endregion

        #region Propiedades
        public string Ubicacion
        {
            get
            {
                return ubicacion;
            }
            set
            {
                SetValue(ref ubicacion, value);
            }
        }
        public string Pais
        {
            get
            {
                return pais;
            }
            set
            {
                SetValue(ref pais, value);
            }
        }
        public string ResulTerm
        {
            get
            {
                return resulTerm;
            }
            set
            {
                SetValue(ref resulTerm, value);
            }
        }
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                SetValue(ref region, value);
            }
        }
        public string UltimaActualizacion
        {
            get
            {
                return ultimaActualizacion;
            }
            set
            {
                SetValue(ref ultimaActualizacion, value);
            }
        }
        public string Clima
        {
            get
            {
                return clima;
            }
            set
            {
                SetValue(ref clima, value);
            }
        }
        public string Temperatura
        {
            get
            {
                return temperatura;
            }
            set
            {
                SetValue(ref temperatura, value);
            }
        }
        public ImageSource Imagen
        {
            get
            {
                return imagen;
            }
            set
            {
                SetValue(ref imagen, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(Buscar);
            }
        }
        #endregion
        #region Constructor
        public WeatherPageViewModel() {
        }
        #endregion

        #region Métodos
        private async void Buscar() {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(ObtenerUrl());
            var response = await cliente.GetAsync(cliente.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var weather = Weather.FromJson(jsonResult);
            FijarValores(weather);
        }

        private void FijarValores(Weather weather)
        {
            Ubicacion = weather.Query.Results.Channel.Location.City;
            Pais = weather.Query.Results.Channel.Location.Country;
            Region= weather.Query.Results.Channel.Location.Region;
            UltimaActualizacion = weather.Query.Results.Channel.LastBuildDate;
            Temperatura = weather.Query.Results.Channel.Item.Condition.Temp;
            Clima = weather.Query.Results.Channel.Item.Condition.Text;
            var codeImg = weather.Query.Results.Channel.Item.Condition.Code;
            string imgLink = $"http://l.yimg.com/a/i/us/we/52/{codeImg}.gif";
            Imagen = ImageSource.FromUri(new Uri(imgLink));
        }

        private string ObtenerUrl()
        {
            string serviceUrl = $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22{ResulTerm}%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
            return serviceUrl;
        }
        #endregion
    }
}
