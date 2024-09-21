using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class ClienteService(ClienteRepository clienteRepository) : ICrud<Cliente>
    {
        private readonly ClienteRepository _clienteRepository = clienteRepository;

        public (bool, decimal) Adicionar(Cliente entidade)
        {
           
            return _clienteRepository.Adicionar(entidade);;
        }

        public List<Cliente> Atualizar()
        {
            return _clienteRepository.Atualizar();
        }

        public List<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }

        public bool Remover(int id)
        {
            bool pessoaRemovida = _clienteRepository.Remover(id);
            if (pessoaRemovida == false){
                return pessoaRemovida;
            }
            return pessoaRemovida;
        }
    }
}