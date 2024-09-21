using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class ClienteRouter(ClienteService clienteService) : ICrud<Cliente>
    {
        private readonly ClienteService _clienteService = clienteService;

        public (bool, decimal) Adicionar(Cliente entidade)
        {
            return _clienteService.Adicionar(entidade);
        }

        public List<Cliente> Atualizar()
        {
            return _clienteService.Atualizar();
        }

        public List<Cliente> Listar()
        {
            return _clienteService.Listar();
        }

        public bool Remover(int id)
        {
            bool pessoaRemovida = _clienteService.Remover(id);
            if (pessoaRemovida == false){
                return pessoaRemovida;
            }
            return pessoaRemovida;
        }
    }
}