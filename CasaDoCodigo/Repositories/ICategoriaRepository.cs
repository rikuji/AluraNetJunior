using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    interface ICategoriaRepository
    {
        Task SaveCategoria(string nomeCategoria);
    }
}
