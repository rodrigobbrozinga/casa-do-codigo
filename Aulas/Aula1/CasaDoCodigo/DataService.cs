using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;


        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();
            List<Livro> livros = GetLivros();
            produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("Livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
