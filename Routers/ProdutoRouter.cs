using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Services;

namespace Hortifruti.Routers
{
    public class ProdutoRouter(ProdutoService produtoService) : ICrud<Produto>
    {
        private readonly ProdutoService _produtoService = produtoService;

        public bool Adicionar(Produto entidade)
        {        
            bool fornecedorId = _produtoService.Adicionar(entidade);

            if (fornecedorId == false){
                return fornecedorId;
            }
            return fornecedorId;
            

        }

        public List<Produto> Atualizar()
        {
            return _produtoService.Atualizar();
        }

        public List<Produto> Listar()
        {
            return _produtoService.Listar();
        }

        public bool Remover(int id)
        {
            return _produtoService.Remover(id);
        }
    }
}