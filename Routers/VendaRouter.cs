using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class VendaRouter(VendaService vendaService, ItensVendaService itensVenda) : Ivendas<Venda,ItensVenda>
    {
        private readonly VendaService _VendaService = vendaService;
        private readonly ItensVendaService _ItensVendaService = itensVenda;

        public (bool, decimal) AdicionarVenda(Venda entidade) // assinatura 2
        {
            return _VendaService.Adicionar(entidade);
        }
        public (bool, decimal, int) AdicionaritensVenda(ItensVenda entidade){
            return _ItensVendaService.Adicionar(entidade);
        }

        public List<Venda> AtualizarVenda()
        {
            return _VendaService.Atualizar();
        }

        public List<Venda> ListarVenda()
        {
            return _VendaService.Listar();
        }

        public bool RemoverVenda(int id)
        {
            return _VendaService.Remover(id);
        }
    }
}