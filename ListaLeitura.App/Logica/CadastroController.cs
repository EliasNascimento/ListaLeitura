using ListaLeitura.App.HTML;
using ListaLeitura.App.Negocio;
using ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.App.Logica
{
    public class CadastroController
    {

        //Cadastro de um novo livro
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "Livro adicionado com sucesso!";
        }

        //Exibe formulário para cadastro do livro
        public IActionResult ExibeFormulario()
        {
            return new ViewResult { ViewName = "formulario" };
        }

    }
}
