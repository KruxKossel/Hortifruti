using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class ItensVendaRouter(ItensVendaService itensVendaService) : ICrud<ItensVenda>
    {
        private readonly ItensVendaService _itensVendaService = itensVendaService;

        public bool Adicionar(ItensVenda entidade)
        {
            return _itensVendaService.Adicionar(entidade);
        }

        public List<ItensVenda> Atualizar()
        {
            return _itensVendaService.Atualizar();
        }

        public List<ItensVenda> Listar()
        {
            return _itensVendaService.Listar();
        }

        public bool Remover(int id)
        {
            return _itensVendaService.Remover(id);
        }
    }
}