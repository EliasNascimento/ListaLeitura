using ListaLeitura.App.HTML;
using ListaLeitura.App.Negocio;
using ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.App.Logica
{
    public class CadastroLogica
    {        

        //Cadastro de um novo livro
        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First(),
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso!");
        }

        //Exibe formulário para cadastro do livro
        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaArquivoHtml("formulario");
            return context.Response.WriteAsync(html);
        }
    }
}
