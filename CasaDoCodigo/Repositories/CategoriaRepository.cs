using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task SaveCategoria(string nomeCategoria)
        {
            if (!dbSet.Where(p => p.Nome == nomeCategoria).Any())
            {
                dbSet.Add(new Categoria(nomeCategoria));
            }
            await contexto.SaveChangesAsync();
        }
    }
}
