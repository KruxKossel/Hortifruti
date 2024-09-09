using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class ItensVendaService(ItensVendaRepository itensVendaRepository) : ICrud<ItensVenda>
    {
        private readonly ItensVendaRepository _itensVendaRepository = itensVendaRepository;

        public bool Adicionar(ItensVenda entidade)
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

        public bool Remover(ItensVenda entidade)
        {
            return _itensVendaRepository.Remover(entidade);
        }
    }
}