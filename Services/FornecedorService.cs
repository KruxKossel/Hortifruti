using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;

namespace Hortifruti.Services
{
    public class FornecedorService(FornecedorRepository fornecedorRepository) : ICrud<Fornecedor>
    {
        private readonly FornecedorRepository _fornecedorRepository = fornecedorRepository;

        public bool Adicionar(Fornecedor entidade)
        {
            bool pessoaAdicionada = _fornecedorRepository.Adicionar(entidade);
            return pessoaAdicionada;
        }

        public List<Fornecedor> Atualizar()
        {
            return _fornecedorRepository.Atualizar();
        }

        public List<Fornecedor> Listar()
        {
            return _fornecedorRepository.Listar();
        }

        public bool Remover(Fornecedor entidade)
        {
            return _fornecedorRepository.Remover(entidade);
        }
    }
}