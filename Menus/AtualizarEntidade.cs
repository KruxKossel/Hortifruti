using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Hortifruti.Models;

namespace Hortifruti.Menus
{
    public class AtualizarEntidade
    {
        static readonly Regex regexTelefone = RegexUtil.MyRegexTelefone();
        static readonly Regex regexCpf = RegexUtil.MyRegexCpf();
        static readonly Regex regexNome = RegexUtil.MyRegexNome();
        static readonly Regex regexCnpj = RegexUtil.MyRegexCnpj();

        private static int CriarId(){

            int id;

            while (true)
            {
                Console.Write("Digite o id:");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }
            }

            return id;
        }


        public static (Cliente, int) AtualizarCliente(){

            string nome;
            string cpf;
            string telefone;
            int id = CriarId();

            while(true)
            {
                Console.Write("\nDigite o novo NOME: ");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && regexNome.IsMatch(nome))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nNome inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                }
            }

            while(true)
            {
                Console.Write("Digite o novo CPF:");
                cpf = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cpf))
                {
                    Console.WriteLine("Não foi informado CPF.");
                    break;
                }
                else if(!string.IsNullOrWhiteSpace(cpf) && regexCpf.IsMatch(cpf))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nCPF inválido.\nAceita formatos como: 123.456.789-09, 12345678909.\n");
                }
            }

            while(true)
            {
                Console.Write("Digite o novo Telefone:");
                telefone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefone))
                {
                    Console.WriteLine("Não foi informado Telefone.");
                    break;
                }
                else if(!string.IsNullOrWhiteSpace (telefone) && regexTelefone.IsMatch(telefone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTelefone inválido.\nAceita formatos como: (11) 91234-5678, 11 91234-5678, 1191234-5678, 91234-5678.\n");
                }
            }

            
            Cliente cliente = new(nome, cpf, telefone);
            return (cliente, id);
        }

        public static (Fornecedor, int) AtualizarFornecedor() {

            string razaoSocial;
            string cnpj;
            string telefone;
            int id = CriarId();

            while (true)
            {
                Console.Write("Digite a nova razão social:");
                razaoSocial = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(razaoSocial) && regexNome.IsMatch(razaoSocial))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nrazao Social inválida. Por favor, digite um nome sem números ou caracteres especiais.\n");
                }
            }

            while (true)
            {
                Console.Write("Digite o novo CNPJ:");
                cnpj = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cnpj) && regexCnpj.IsMatch(cnpj))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nCNPJ inválido.\nAceita formatos como: 12.345.678/0001-95, 12345678000195.\n");
                }
            }

            while (true)
            {
                Console.Write("Digite o novo telefone:");
                telefone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefone))
                {
                    Console.WriteLine("Não foi informado Telefone.");
                    break;
                }
                else if(!string.IsNullOrWhiteSpace (telefone) && regexTelefone.IsMatch(telefone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nTelefone inválido.\nAceita formatos como: (11) 91234-5678, 11 91234-5678, 1191234-5678, 91234-5678.\n");
                }
            }

            Fornecedor fornecedor= new Fornecedor(razaoSocial,cnpj,telefone);
            return (fornecedor, id);

        }

        public static (Funcionario, int) AtualizarFuncionario(){

            int id = CriarId();
            string nome;
            string cpf;
            string cargo;

            while(true){
                Console.Write("Digite o novo nome:");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && regexNome.IsMatch(nome))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nNome inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                }
            }

            while(true){
                
            Console.Write("Digite o novo cpf:");
            cpf = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(cpf) && regexCpf.IsMatch(cpf))
            {
                break;
            }
            else
            {
                Console.WriteLine("\n\nCPF inválido.\nAceita formatos como: 123.456.789-09, 12345678909.\n");
            }
            }

            while (true){
                Console.Write("Digite o novo cargo:");
                cargo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cargo) && regexNome.IsMatch(cargo))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nCargo inválido. Por favor, digite um nome sem números ou caracteres especiais.\n");
                }
            }

            Funcionario funcionario= new(nome,cpf,cargo);

            return (funcionario, id);
        }

        public static (Venda, int) AtualizarVenda(){

            int id = CriarId();
            int clienteId;
            int itensVendaId;
            DateTime  data = DateTime.Now;
            decimal total=0;

           while (true)
            {
                Console.Write("\nDigite o novo Id do cliente: ");
                if (int.TryParse(Console.ReadLine(), out clienteId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }

            }
            while (true)
            {
                Console.Write("\nDigite o novo Id do cliente: ");
                if (int.TryParse(Console.ReadLine(), out itensVendaId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }

            }

            Venda venda= new(clienteId, itensVendaId, data, total);

            return (venda, id);
        }
        public static (ItensVenda, int) AtualizarItensVenda(){

            int id = CriarId();
            int produtoId;
            int quantidade;
            decimal preco;

            while (true)
            {
                Console.Write("\nDigite o ID do Produto: ");
                if (int.TryParse(Console.ReadLine(), out produtoId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }
            }

            while (true)
            {
                Console.Write("\nDigite a QUANTIDADE de Itens da Venda: ");
                if (int.TryParse(Console.ReadLine(), out quantidade))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nQuantidade inválida. Por favor, digite um número inteiro.\n");
                }
            }

            while (true)
            {
                Console.Write("\nDigite o PREÇO dos Itens da Venda: ");
                if (decimal.TryParse(Console.ReadLine(), out preco))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nValor inválido. Por favor, digite um número decimal.\n");
                }
            }

            ItensVenda itensVenda = new(produtoId, quantidade, preco);
            return (itensVenda, id);
        }
        public static (Estoque, int) AtualizarEstoque(){

            int id = CriarId();
            int produtoId;
            int quantidade;

            while (true)
            {
                Console.Write("\nDigite o ID do Produto: ");
                if (int.TryParse(Console.ReadLine(), out produtoId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }
            }

            while (true)
            {
                Console.Write("\nDigite a QUANTIDADE de Itens da Venda: ");
                if (int.TryParse(Console.ReadLine(), out quantidade))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nQuantidade inválida. Por favor, digite um número inteiro.\n");
                }
            }

            Estoque estoque = new(produtoId, quantidade);
            return (estoque, id);
        }

    }
}