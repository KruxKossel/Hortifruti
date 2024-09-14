using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class ItensVendaRepository(string connectionString) : ICrud<ItensVenda>
    {
        private readonly string _connectionString = connectionString;
        public bool Adicionar(ItensVenda entidade)
        {
            throw new NotImplementedException();
        }

        public List<ItensVenda> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<ItensVenda> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}