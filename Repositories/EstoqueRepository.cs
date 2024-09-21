using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class EstoqueRepository(string connectionString) : ICrud<Estoque>
    {
        private readonly string _connectionString = connectionString;

        public (bool, decimal) Adicionar(Estoque entidade)
        {
            throw new NotImplementedException();
        }

        public List<Estoque> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Estoque> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}