using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class EstoqueService(EstoqueRepository estoqueRepository) : ICrud<Estoque>
    {
        private readonly EstoqueRepository _estoqueRepository = estoqueRepository;

        public (bool, decimal) Adicionar(Estoque entidade)
        {
            
            return _estoqueRepository.Adicionar(entidade);
        }

        public List<Estoque> Atualizar()
        {
            return _estoqueRepository.Atualizar();
        }

        public List<Estoque> Listar()
        {
            return _estoqueRepository.Listar();
        }

        public bool Remover(int id)
        {
            return _estoqueRepository.Remover(id);
        }
    }
}