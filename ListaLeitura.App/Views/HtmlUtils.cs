using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ListaLeitura.App.HTML
{
    public class HtmlUtils
    {
        public static string CarregaArquivoHtml(string nomeArquivo)
        {
            var nomeCompleto = $"C:/Projects/ListaLeitura/ListaLeitura.App/HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompleto))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
