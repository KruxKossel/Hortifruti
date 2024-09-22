using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class ItensVendaService(ItensVendaRepository itensVendaRepository) : IItensVenda<ItensVenda>
    {
        private readonly ItensVendaRepository _itensVendaRepository = itensVendaRepository;

        public (bool, decimal, int) Adicionar(ItensVenda entidade)
        {
           return _itensVendaRepository.Adicionar(entidade);
        }

        public List<ItensVenda> Atualizar()
        {
            return _itensVendaRepository.Atualizar();
        }

        public List<ItensVenda> Listar()
        {
            return _itensVendaRepository.Listar();
        }

        public bool Remover(int id)
        {
            return _itensVendaRepository.Remover(id);
        }
    }
}