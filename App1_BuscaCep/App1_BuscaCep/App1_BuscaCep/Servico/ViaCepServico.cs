﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_BuscaCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_BuscaCep.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";


        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;
            return end;
        }
    }
}
