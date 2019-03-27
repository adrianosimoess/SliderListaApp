using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Collections;

namespace SliderListaApp
{
    public partial class MainPage : ContentPage
    {
        //ArrayList<string> lista = new ArrayList<string>();
        ArrayList lista = new ArrayList()
        {
            //"Ramon","James","Mizael","Adriano"
             "AC", "AL", "AM",
             "AP", "BA", "CE",
             "DF", "ES", "GO",
             "MA", "MG", "MS",
             "MT", "PA", "PB",
             "PE", "PI", "PR",
             "RJ", "RN", "RO",
             "RR", "RS", "SC",
             "SE", "SP", "TO"

        };

        async void visualizarMunicipio(object sender, System.EventArgs e)
        {
            //await DisplayAlert("UF", label_uf.Text, "OK");
            string uf = label_uf.Text.ToUpper();
            var client = new HttpClient();
            var json = await client.GetStringAsync($"http://ibge.herokuapp.com/municipio/?val={uf}");
            var dados = JsonConvert.DeserializeObject<Object>(json);

            JObject municipios = JObject.Parse(json);

            Dictionary<string, string> dadosMunicipio =
            municipios.ToObject<Dictionary<string, string>>();

            ArrayList lista = new ArrayList();
            foreach (KeyValuePair<string, string> municipio in dadosMunicipio)
            {
                lista.Add(municipio.Key);

            }
            await Navigation.PushAsync(new ListaMunicipioPage(lista));
            
        }

        void naMudancaDeValorDoSlider(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            int posicao = Convert.ToInt32(slider_blaster.Value);
            string valordalabel = lista[posicao].ToString();
            label_uf.Text = valordalabel;
        }


        public MainPage()
        {
            InitializeComponent();
        }
    }
}
