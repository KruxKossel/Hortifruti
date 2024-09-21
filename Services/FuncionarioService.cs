using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class FuncionarioService(FuncionarioRepository funcionarioRepository) : ICrud<Funcionario>
    {
        private readonly FuncionarioRepository _funcionarioRepository = funcionarioRepository;

        public (bool, decimal) Adicionar(Funcionario entidade)
        {
           return _funcionarioRepository.Adicionar(entidade);
        }

        public List<Funcionario> Atualizar()
        {
            return _funcionarioRepository.Atualizar();
        }

        public List<Funcionario> Listar()
        {
            return _funcionarioRepository.Listar();
        }

        public bool Remover(int id)
        {
            return _funcionarioRepository.Remover(id);
        }
    }
}