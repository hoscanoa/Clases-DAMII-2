using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClienteWS.Resources;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ClienteWS
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "Http://169.254.80.80:50434/api/empleado?DNI=" + txtDNI.Text;
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.DefaultRequestHeaders.Accept.Clear();
            clienteHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
            
            string resultado = await
            clienteHttp.GetStringAsync(url);

            Empleado emp =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Empleado>(resultado);
            txtNombres.Text = emp.Nombres;
            txtDireccion.Text = emp.Direccion;
            txtTelefono.Text = emp.Telefono;
        }

      
    }
}