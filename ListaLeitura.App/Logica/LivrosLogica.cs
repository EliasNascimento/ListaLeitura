﻿using ListaLeitura.App.HTML;
using ListaLeitura.App.Negocio;
using ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        private static string CarregaLista(IEnumerable<Livro> livros)
        {            
            var conteudoArquivo = HtmlUtils.CarregaArquivoHtml("lista");

            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo.Replace(
                    "#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");            
        }

        //Livros para ler
        public static Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);
        }

        //Livros lendo
        public static Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lendo.Livros);

            return context.Response.WriteAsync(html);
        }

        //Livros lidos
        public static Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lidos.Livros);

            return context.Response.WriteAsync(html);
        }

        //Exibe detalhes do livro
        public static Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();

            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }
    }
}
