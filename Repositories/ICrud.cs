using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Repositories
{
    public interface ICrud<T> where T : class
    {
        public bool Adicionar(T entidade);
        public List<T> Listar();
        public List<T> Atualizar();
        public bool Remover(int id);
    }
}