using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class VendaService(VendaRepository vendaRepository) : ICrud<Venda>
    {
        private readonly VendaRepository _vendaRepository = vendaRepository;

        public bool Adicionar(Venda entidade)
        {
            return _vendaRepository.Adicionar(entidade);
        }

        public List<Venda> Atualizar()
        {
            return _vendaRepository.Atualizar();
        }

        public List<Venda> Listar()
        {
            return _vendaRepository.Listar();
        }

        public bool Remover(int id)
        {
            return _vendaRepository.Remover(id);
        }
    }
}