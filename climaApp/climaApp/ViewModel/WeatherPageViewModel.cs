using System;
using System.Collections.Generic;
using System.Text;

namespace climaApp.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    

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
        private void Buscar() {

        }
        #endregion
    }
}
