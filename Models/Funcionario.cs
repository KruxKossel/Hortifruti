using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Funcionario(string nome, string cpf, string cargo) : Pessoa(nome, cpf)
    {
        static readonly Regex regexNome = RegexUtil.MyRegexNome();
        public int Id { get;}

        private string _cargo;
        public string Cargo 
        { 
            get => _cargo; 
            set
            {
                if (!string.IsNullOrWhiteSpace(cargo) && regexNome.IsMatch(cargo))
                {
                    this._cargo = cargo;
                }
                else
                {
                    Console.WriteLine("\n\nCargo inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                    this._cargo = string.Empty;
                }
            } 
        }
    }
}