using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class FornecedorRepository(string connectionString) : ICrud<Fornecedor>
    {
        private readonly string _connectionString = connectionString;
        public bool Adicionar(Fornecedor entidade)
        {
            throw new NotImplementedException();
        }

        public List<Fornecedor> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Fornecedor> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(Fornecedor entidade)
        {
            throw new NotImplementedException();
        }
    }
}