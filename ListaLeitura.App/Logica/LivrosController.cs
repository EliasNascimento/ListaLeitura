using ListaLeitura.App.HTML;
using ListaLeitura.App.Negocio;
using ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {

        public IEnumerable<Livro> Livros { get; set; }

        private static string CarregaLista(IEnumerable<Livro> livros)
        {            
            var conteudoArquivo = HtmlUtils.CarregaArquivoHtml("lista");

            
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");            
        }

        //Livros para ler
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;            
            return View("lista");
        }

        //Livros lendo
        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lista");
        }

        //Livros lidos
        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lidos.Livros;
            return View("lista");
        }

        //Exibe detalhes do livro
        public string Detalhes(int id)
        {            
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return livro.Detalhes();
        }

        public string Teste()
        {
            return "Nova funcionalidade implementada!";
        }
    }
}
