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

        public (bool, decimal) Adicionar(Fornecedor entidade)
        {
            return  _fornecedorRepository.Adicionar(entidade);
        }

        public List<Fornecedor> Atualizar()
        {
            return _fornecedorRepository.Atualizar();
        }

        public List<Fornecedor> Listar()
        {
            return _fornecedorRepository.Listar();
        }

        public bool Remover(int id)
        {
            return _fornecedorRepository.Remover(id);
        }
    }
}