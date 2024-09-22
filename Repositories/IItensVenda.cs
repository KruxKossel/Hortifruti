using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Repositories
{
    public interface IItensVenda<T> where T : class
    {
        public (bool, decimal, int) Adicionar(T entidade);
        public List<T> Listar();
        public List<T> Atualizar();
        public bool Remover(int id);
    }
}