using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ConsultarCEP.Servicos.Modelos;
using Newtonsoft.Json;

namespace ConsultarCEP.Servicos
{
    public class ViaCepService
    {
        public static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoCep(string cep)
        {

            string novo = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string result = wc.DownloadString(novo);

            return JsonConvert.DeserializeObject<Endereco>(result);
        }
    }
}
