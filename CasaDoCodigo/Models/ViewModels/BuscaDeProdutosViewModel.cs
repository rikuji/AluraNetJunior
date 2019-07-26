using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public IList<Categoria> Categorias { get; set; }
        public IList<Produto> Produtos { get; set; }

        public BuscaDeProdutosViewModel(IList<Categoria> categorias, IList<Produto> produtos)
        {
            Categorias = categorias;
            Produtos = produtos;
        }

    }
}
