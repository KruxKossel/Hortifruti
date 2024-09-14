using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Produto(int fornecedorId, string nome, decimal preco)
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
                 if (!string.IsNullOrWhiteSpace(nome) && regexNome.IsMatch(nome))
                {
                    this._nome = nome;
                }
                else
                {
                    Console.WriteLine("\n\nNome inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                    this._nome = string.Empty;
                }
            }
     
        }
        public decimal Preco { get; } = preco;
    }
}