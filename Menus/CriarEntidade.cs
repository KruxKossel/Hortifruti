using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Menus
{
    public class CriarEntidade
    {
        // configurações de aceitação, fazer prevenção de erros
        public static Cliente CriarCliente()
        {
            string nome;
            string cpf;
            string telefone;

            while(true)
            {
                Console.Write("\nDigite o NOME do Cliente: ");
                nome = Console.ReadLine();
                 if (nome != string.Empty)
                {
                    break;
                }
            }
                

            while(true)
            {
                Console.Write("\nDigite o CPF do Cliente: ");
                cpf = Console.ReadLine();
                if (cpf != string.Empty)
                {
                    break;
                }

            }

            while(true){

                Console.Write("\nDigite o TELEFONE do Cliente: ");
                telefone = Console.ReadLine();

                if(telefone != string.Empty){
                    break;
                }

            }

            Cliente cliente = new(nome, cpf, telefone);

            return cliente;
        }

        public static Estoque CriarEstoque()
        {
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

                Console.Write("\nDigite a quantidade de Produtos: ");
                if (int.TryParse(Console.ReadLine(), out quantidade))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nQuantidade inválida. Por favor, digite um número inteiro.\n");
                }

            }

            Estoque estoque= new(produtoId, quantidade);

            return estoque;
        }

        public static Fornecedor CriarFornecedor()
        {

            string razaoSocial;
            string cnpj;
            string telefone;

            while(true)
            {
                Console.Write("\nDigite a Razão Social do Fornecedor: ");
                razaoSocial = Console.ReadLine();
                if (razaoSocial != string.Empty)
                {
                    break;
                }
            }

            while(true)
            {
                Console.Write("\nDigite o CNPJ do Fornecedor: ");
                cnpj = Console.ReadLine();
                if (cnpj != string.Empty)
                {
                    break;
                }

            }

            while(true)
            {
                Console.Write("\nDigite o TELEFONE do Fornecedor: ");
                telefone = Console.ReadLine();
                if (telefone != string.Empty)
                {
                    break;
                }
            }

            Fornecedor fornecedor= new(razaoSocial, cnpj, telefone);

            return fornecedor;
        }

        public static Funcionario CriarFuncionario()
        {

            string nome;
            string cpf;
            string cargo;

            while(true)
            {
                Console.Write("\nDigite o NOME do Funcionario: ");
                nome = Console.ReadLine();
                if (nome != string.Empty)
                {
                    break;
                }
            }

            while(true)
            {
                Console.Write("\nDigite o CPF do Funcionario: ");
                cpf = Console.ReadLine();
                if (cpf != string.Empty)
                {
                    break;
                }
            }

            while(true)
            {
                Console.Write("\nDigite o CARGO do Funcionario: ");
                cargo = Console.ReadLine();
                if (cargo != string.Empty)
                {
                    break;
                }
            }

            Funcionario funcionario = new(nome, cpf, cargo);

            return funcionario;
        }

        public static ItensVenda CriarItensVenda()
        {
            int vendaId;
            int produtoId;
            int quantidade;
            decimal preco;

            while (true)
            {
                Console.Write("\nDigite o ID da Venda: ");
                if (int.TryParse(Console.ReadLine(), out vendaId))
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

            ItensVenda itensVenda = new(vendaId, produtoId, quantidade, preco);

            return itensVenda;
        }

        public static Produto CriarProduto()
        {
            int fornecedorId;
            string nome;
            decimal preco;

            while (true)
            {
                Console.Write("\nDigite o ID do Fornecedor: ");
                if (int.TryParse(Console.ReadLine(), out fornecedorId))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }
            }

            while(true)
            {
                Console.Write("\nDigite o NOME do Produto: ");
                nome = Console.ReadLine();
                if (nome != string.Empty)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("\nDigite o PREÇO do Produto: ");
                if (decimal.TryParse(Console.ReadLine(), out preco))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nValor inválido. Por favor, digite um número decimal.\n");
                }
            }

            Produto produto= new(fornecedorId,nome,preco);

            return produto;
        }
    }
}