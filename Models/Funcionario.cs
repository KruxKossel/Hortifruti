using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Funcionario(string nome, string cpf) : Pessoa(nome, cpf)
    {
        static readonly Regex regexNome = RegexUtil.MyRegexNome();
        public int Id { get;}

        private string _cargo;
        public string Cargo 
        { 
            get => _cargo; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && regexNome.IsMatch(value))
                {
                    this._cargo = value;
                }
                else
                {
                    this._cargo = string.Empty;
                }
            } 
        }


        public Funcionario(string nome, string cpf, string cargo ) : this(nome, cpf){

            this.Cargo = cargo;
        }
    }
}