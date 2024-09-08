using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Estoque(int produtoId, int quantidade)
    {
        public int Id { get;}
        public int ProdutoId { get;} = produtoId;
        public int Quantidade { get;} = quantidade;
    }
}