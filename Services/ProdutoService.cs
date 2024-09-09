using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class ProdutoService(ProdutoRepository produtoRepository) : ICrud<Produto>
    {
        private readonly ProdutoRepository _produtoRepository = produtoRepository;

        public bool Adicionar(Produto entidade)
        {
            bool fornecedorId = _produtoRepository.Adicionar(entidade);

            if (fornecedorId == false){
                return fornecedorId;
            }
            return fornecedorId;
        }

        public List<Produto> Atualizar()
        {
            return _produtoRepository.Atualizar();
        }

        public List<Produto> Listar()
        {
           return _produtoRepository.Listar();
        }

        public bool Remover(Produto entidade)
        {
            return _produtoRepository.Remover(entidade);
        }
    }
}