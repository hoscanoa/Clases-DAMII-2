using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppRRHH.Resources;

namespace AppRRHH
{
    public partial class MainPage : PhoneApplicationPage
    {
        MyDataContext db = new MyDataContext(MyDataContext.cadenaConexion);

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        void CrearBD()
        {
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
                Genero g = new Genero()
                {
                    DescripcionGenero = "Masculino"
                };
                db.ListaGeneros.InsertOnSubmit(g);
                g = new Genero()
                {
                    DescripcionGenero = "Femenino"
                };
                db.ListaGeneros.InsertOnSubmit(g);
                db.SubmitChanges();

                Ubigeo u = new Ubigeo()
                {
                    DescripcionUbigeo = "Lima/Lima/Surco"
                };
                db.ListaUbigeos.InsertOnSubmit(u);

                u = new Ubigeo()
                {
                    DescripcionUbigeo = "Lima/Lima/Surquillo"
                };
                db.ListaUbigeos.InsertOnSubmit(u);

                u = new Ubigeo()
                {
                    DescripcionUbigeo = "Ica/Ica/Pisco"
                };
                db.ListaUbigeos.InsertOnSubmit(u);

                u = new Ubigeo()
                {
                    DescripcionUbigeo = "Lima/Lima/Independencia"
                };
                db.ListaUbigeos.InsertOnSubmit(u);
                db.SubmitChanges();
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            CrearBD();
            cboGenero.ItemsSource = db.ListaGeneros;
            autoUbicacion.ItemsSource = db.ListaUbigeos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
      

    }
}