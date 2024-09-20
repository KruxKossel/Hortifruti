using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Venda(int clienteId, DateTime data, decimal total)
    {
        public int Id { get; }
        public int ClienteId { get; } = clienteId;
        public DateTime Data { get; } = data;
        public decimal Total { get;} = total;
    }

}