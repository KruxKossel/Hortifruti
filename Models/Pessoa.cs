using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Pessoa
    {
        static readonly Regex regexCpf = RegexUtil.MyRegexCpf();
        static readonly Regex regexNome = RegexUtil.MyRegexNome();

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
                    Console.WriteLine("\n\nNome inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                    this._nome = string.Empty;
                }
            }
        }

        private string _cpf;
        public string Cpf 
        { 
            get => _cpf;
            set 
            {
                if (!string.IsNullOrWhiteSpace(value) && regexCpf.IsMatch(value))
                {
                    this._cpf = value;
                }
                else
                {
                    Console.WriteLine("\n\nCPF inválido.\nAceita formatos como: 123.456.789-09, 12345678909.\n");
                    this._cpf = string.Empty;
                }
            }
        }

        public Pessoa(string nome, string cpf){

            this.Nome = nome;
            this.Cpf = cpf;
        }
        
    }
}