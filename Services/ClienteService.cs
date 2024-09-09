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

        public bool Adicionar(Cliente entidade)
        {
            bool pessoaAdicionada = _clienteRepository.Adicionar(entidade);
            return pessoaAdicionada;
        }

        public List<Cliente> Atualizar()
        {
            return _clienteRepository.Atualizar();
        }

        public List<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }

        public bool Remover(Cliente entidade)
        {
            return _clienteRepository.Remover(entidade);
        }
    }
}