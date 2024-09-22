using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class ItensVenda( int produtoId, int quantidade, decimal preco)
    {
        public int Id { get;}
        public int ProdutoId { get; } = produtoId;
        public int Quantidade { get; } = quantidade;
        public decimal Preco { get; } = preco;
        
    }
}