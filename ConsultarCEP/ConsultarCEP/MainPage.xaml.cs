using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCEP.Servicos;
using ConsultarCEP.Servicos.Modelos;
using Newtonsoft.Json;

namespace ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            // atribui método ao botão
            Botao.Clicked += BuscarCep;
		}

        private void BuscarCep(object sender, EventArgs args)
        {
            if (IsValid(Cep.Text.Trim()))
            {
                Endereco end = ViaCepService.BuscarEnderecoCep(Cep.Text.Trim());
                if (end.logradouro != null)
                {
                    Resultado.Text = string.Format("Endereco: {0} \nBairro: {1} \nCidade: {2} - {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                }
                else
                {
                    Resultado.Text = "CEP inválido!";
                }
            }

        }

        public bool IsValid(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !int.TryParse(cep, out int cepInt))
            {
                DisplayAlert("ERRO", "CEP inválido!", "OK");
                return false;
            }
            return true;
        }
    }
}
