using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class VendaRepository(string connectionString) : ICrud<Venda>
    {
        private readonly string _connectionString = connectionString;
        public bool Adicionar(Venda entidade)
        {
            throw new NotImplementedException();
        }

        public List<Venda> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Venda> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}