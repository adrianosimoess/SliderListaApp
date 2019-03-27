using System;
using System.Collections;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SliderListaApp
{
    public partial class ListaMunicipioPage : ContentPage
    {
        private ArrayList lista;

        public ListaMunicipioPage(ArrayList lista_municipio)
        {
            InitializeComponent();
            listView_municipio.ItemsSource = lista_municipio;
        }

      
    }
}
