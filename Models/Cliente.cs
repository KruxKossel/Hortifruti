using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Cliente(string nome, string cpf) : Pessoa (nome, cpf)
    {
        static readonly Regex regexTelefone = RegexUtil.MyRegexTelefone();
        public int Id { get;}

        //valida o telefone
        private string _telefone;
        public string Telefone 
        {
            get => _telefone;
            set 
            {    
                if (!string.IsNullOrWhiteSpace(value) && regexTelefone.IsMatch(value))
                {
                    this._telefone = value;
                }
                else
                {
                    this._telefone = string.Empty;
                }
            }
        }

        public Cliente(string nome, string cpf, string telefone) : this(nome, cpf){

            Telefone = telefone;
        }
    }
}