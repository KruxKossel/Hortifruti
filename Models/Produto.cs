using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Produto(int fornecedorId, string nome, decimal preco)
    {
        public int Id { get;}
        public int FornecedorId { get; } = fornecedorId;
        public string Nome { get; } = nome;
        public decimal Preco { get; } = preco;
    }
}