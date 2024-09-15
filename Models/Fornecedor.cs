using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Fornecedor
    {

        static readonly Regex regexTelefone = RegexUtil.MyRegexTelefone();
        static readonly Regex regexCnpj = RegexUtil.MyRegexCnpj();
        static readonly Regex regexNome = RegexUtil.MyRegexNome();

        public int Id { get; }

        private string _razaoSocial;
        public string RazaoSocial 
        { 
            get => _razaoSocial;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && regexNome.IsMatch(value))
                {
                    this._razaoSocial = value;
                }
                else
                {
                    this._razaoSocial = string.Empty;
                }
            } 
        }

        private string _cnpj;
        public string Cnpj 
        { 
            get => _cnpj;
            set 
            {
                if (!string.IsNullOrWhiteSpace(value) && regexCnpj.IsMatch(value))
                {
                    this._cnpj = value;
                }
                else
                {
                    this._cnpj = string.Empty;
                }
            }
        }
        
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


        public Fornecedor(string razaoSocial, string cnpj,  string telefone){

            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Telefone = telefone;
        }
    }
}