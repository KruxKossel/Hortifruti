using Hortifruti.Repositories;

namespace Hortifruti.Repositories
{
public interface Ivendas<T1,T2> 
    where T1 : class
    where T2 : class
    {
        public (bool, decimal) AdicionarVenda(T1 entidade);
        public (bool, decimal, int) AdicionaritensVenda(T2 entidade);
        public List<T1> ListarVenda();
        public List<T1> AtualizarVenda();
        public bool RemoverVenda(int id);
    }


}