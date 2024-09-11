using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Menus;

namespace Hortifruti.Models
{
    public class Fornecedor(string razaoSocial, string cnpj, string telefone)
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
                if (!string.IsNullOrWhiteSpace(razaoSocial) && regexNome.IsMatch(razaoSocial))
                {
                    this._razaoSocial = razaoSocial;
                }
                else
                {
                    Console.WriteLine("\n\nrazao Social inválida. Por favor, digite um nome sem números ou caracteres especiais.\n");
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
                if (!string.IsNullOrWhiteSpace(cnpj) && regexCnpj.IsMatch(cnpj))
                {
                    this._cnpj = cnpj;
                }
                else
                {
                    Console.WriteLine("\n\nCNPJ inválido.\nAceita formatos como: 12.345.678/0001-95, 12345678000195.\n");
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
                if (!string.IsNullOrWhiteSpace(telefone) && regexTelefone.IsMatch(telefone))
                {
                    this._telefone = telefone;
                }
                else
                {
                    Console.WriteLine("\n\nTelefone inválido.\nAceita formatos como: (11) 91234-5678, 11 91234-5678, 1191234-5678, 91234-5678.\n");
                    this._telefone = string.Empty;
                }
            } 
        } 
    }
}