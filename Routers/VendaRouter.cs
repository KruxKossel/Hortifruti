using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class VendaRouter(VendaService vendaService) : ICrud<Venda>
    {
        private readonly VendaService _VendaService = vendaService;

        public bool Adicionar(Venda entidade)
        {
            return _VendaService.Adicionar(entidade);
        }

        public List<Venda> Atualizar()
        {
            return _VendaService.Atualizar();
        }

        public List<Venda> Listar()
        {
            return _VendaService.Listar();
        }

        public bool Remover(Venda entidade)
        {
            return _VendaService.Remover(entidade);
        }
    }
}