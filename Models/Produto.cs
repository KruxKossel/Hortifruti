using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Produto(int fornecedorId, decimal preco)
    {

        static readonly Regex regexNome = RegexUtil.MyRegexNome();

        public int Id { get;}
        public int FornecedorId { get; } = fornecedorId;

        private string _nome;
        public string Nome 
        {
            get => _nome;
            set 
            {
                 if (!string.IsNullOrWhiteSpace(value) && regexNome.IsMatch(value))
                {
                    this._nome = value;
                }
                else
                {
                    this._nome = string.Empty;
                }
            }
     
        }
        public decimal Preco { get; } = preco;

        public Produto(int fornecedorId, string nome,  decimal preco) : this(fornecedorId, preco){

            this.Nome = nome;
        }
    }
}