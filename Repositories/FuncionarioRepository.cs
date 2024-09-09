using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class FuncionarioRepository(string connectionString) : ICrud<Funcionario>
    {
        private readonly string _connectionString = connectionString;

        public bool Adicionar(Funcionario entidade)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(Funcionario entidade)
        {
            throw new NotImplementedException();
        }
    }
}