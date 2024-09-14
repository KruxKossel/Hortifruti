using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class FuncionarioRouter(FuncionarioService funcionarioService) : ICrud<Funcionario>
    {
        private readonly FuncionarioService _funcionarioService = funcionarioService;

        public bool Adicionar(Funcionario entidade)
        {
            return _funcionarioService.Adicionar(entidade);
        }

        public List<Funcionario> Atualizar()
        {
            return _funcionarioService.Atualizar();
        }

        public List<Funcionario> Listar()
        {
            return _funcionarioService.Listar();
        }

        public bool Remover(int id)
        {
            return _funcionarioService.Remover(id);
        }
    }
}