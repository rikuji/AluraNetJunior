using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ICategoriaRepository categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public  IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public IList<Produto> GetProdutos(string nomeProduto)
        {
            return  dbSet.Include(p => p.Categoria).Where(p => p.Nome.Contains(nomeProduto) || p.Categoria.Nome.Contains(nomeProduto)).ToList();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                Categoria categoria;

                if (contexto.Set<Categoria>().Where(p => p.Nome == livro.Categoria).FirstOrDefault() is Categoria _categoria)
                {
                    categoria = _categoria;
                }
                else
                {
                    categoria = new Categoria(livro.Categoria);
                    contexto.Set<Categoria>().Add(categoria);
                    contexto.SaveChanges();
                }

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria.Id));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
