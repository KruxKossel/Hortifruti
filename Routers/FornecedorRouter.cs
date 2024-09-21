using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class FornecedorRouter(FornecedorService fornecedorService) : ICrud<Fornecedor>
    {
        private readonly FornecedorService _fornecedorService = fornecedorService;

        public (bool, decimal) Adicionar(Fornecedor entidade)
        {
            return _fornecedorService.Adicionar(entidade);
        }

        public List<Fornecedor> Atualizar()
        {
            return _fornecedorService.Atualizar();
        }

        public List<Fornecedor> Listar()
        {
           return _fornecedorService.Listar();
        }

        public bool Remover(int id)
        {
            return _fornecedorService.Remover(id);
        }
    }
}