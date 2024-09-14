using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class EstoqueRouter(EstoqueService estoqueService) : ICrud<Estoque>
    {
        private readonly EstoqueService _estoqueService = estoqueService;

        public bool Adicionar(Estoque entidade)
        {
            return _estoqueService.Adicionar(entidade);
        }

        public List<Estoque> Atualizar()
        {
            return _estoqueService.Atualizar();
        }

        public List<Estoque> Listar()
        {
            return _estoqueService.Listar();
        }

        public bool Remover(int id)
        {
            return _estoqueService.Remover(id);
        }
    }
}