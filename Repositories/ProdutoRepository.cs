using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class ProdutoRepository(string connectionString) : ICrud<Produto>
    {
        private readonly string _connectionString = connectionString;

        public bool Adicionar(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public List<Produto> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(Produto entidade)
        {
            throw new NotImplementedException();
        }
    }
}