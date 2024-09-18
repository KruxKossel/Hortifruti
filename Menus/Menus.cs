using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Hortifruti.Models;
using Hortifruti.Repositories;
using Hortifruti.Routers;

namespace Hortifruti.Menus
{
    public class Menus()
    {
        
        public static void GerenciarProdutos(ProdutoRouter produtoRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();    
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Produtos");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Atualizar Produto");
                Console.WriteLine("4. Remover Produto");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Produto produto = CriarEntidade.CriarProduto();
                            produtoRouter.Adicionar(produto);
                            break;
                        case 2:
                            List<Produto> produtos = produtoRouter.Listar();
                            
                            Console.WriteLine("\nFuncionarios cadastrados:");
                            
                            foreach (var c in produtos){
                                Console.WriteLine($"\nFornecedor ID: {c.FornecedorId}\nCPF: {c.Nome}\nTelefone: {c.Preco}");
                            }  
                            
                            break;
                        case 3:
                            //
                            break;
                        case 4:
                             int id;
                            
                             while (true)

                            {
                                Console.WriteLine("Digite o ID do Produto a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            produtoRouter.Remover(id); 
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarEstoque(EstoqueRouter estoqueRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Estoque");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar ao Estoque");
                Console.WriteLine("2. Listar Estoque");
                Console.WriteLine("3. Atualizar Estoque");
                Console.WriteLine("4. Remover do Estoque");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            //
                            break;
                        case 2:
                            //
                            break;
                        case 3:
                            //
                            break;
                        case 4:
                            // 
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarItensdeVenda(ItensVendaRouter itensVendaRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();    
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Itens de Venda");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Itens de Venda");
                Console.WriteLine("2. Listar Itens de Venda");
                Console.WriteLine("3. Atualizar Itens de Venda");
                Console.WriteLine("4. Remover Itens de Venda");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            ItensVenda itensVenda = CriarEntidade.CriarItensVenda();
                            itensVendaRouter.Adicionar(itensVenda);
                            break;
                        case 2:
                            List<ItensVenda> itensVendas = itensVendaRouter.Listar();
                            Console.WriteLine("Itens da venda:");
                            foreach(var iv in itensVendas){
                            Console.WriteLine($"\nId do Produto: {iv.ProdutoId}\nId da venda: {iv.VendaId}\nQuantidade: {iv.Quantidade}\nPreco: {iv.Preco}");
                            }                        
                            break;
                        case 3:
                            itensVendaRouter.Atualizar();
                            break;
                        case 4:
                            int id;
                            while (true)
                            {
                                Console.WriteLine("Digite o ID da venda a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            itensVendaRouter.Remover(id);
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarVendas(VendaRouter vendaRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Vendas");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Vendas");
                Console.WriteLine("2. Listar Vendas");
                Console.WriteLine("3. Atualizar Vendas");
                Console.WriteLine("4. Remover Vendas");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Venda venda = CriarEntidade.CriarVenda();
                            vendaRouter.Adicionar(venda);
                            break;
                        case 2:
                            List<Venda> vendas = vendaRouter.Listar();
                            Console.WriteLine("Vendas:");
                            foreach(var Venda in vendas){
                                Console.WriteLine($"\nCLiente Id: {Venda.ClienteId}\n Data: {Venda.Data}\n Total: {Venda.Total}");
                            }
                            break;
                        case 3:
                            vendaRouter.Atualizar();
                            break;
                        case 4:
                            int id;
                            while (true)
                            {
                                Console.WriteLine("Digite o ID da venda a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            vendaRouter.Remover(id);
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarFuncionarios(FuncionarioRouter funcionarioRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Funcionários");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Funcionários");
                Console.WriteLine("2. Listar Funcionários");
                Console.WriteLine("3. Atualizar Funcionários");
                Console.WriteLine("4. Remover Funcionários");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Funcionario funcionario = CriarEntidade.CriarFuncionario();
                            funcionarioRouter.Adicionar(funcionario);

                            break;
                        case 2:
                             List<Funcionario> funcionarios = funcionarioRouter.Listar();
                            
                            Console.WriteLine("\nFuncionarios cadastrados:");
                            
                            foreach (var c in funcionarios){
                                Console.WriteLine($"\nNome: {c.Nome}\nCPF: {c.Cpf}\nTelefone: {c.Cargo}");
                            }  
                            
                            break;
                        case 3:
                            funcionarioRouter.Atualizar();
                            break;
                        case 4:
                            int id;
                            
                             while (true)
                            {
                                Console.WriteLine("Digite o ID do Funcionario a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            funcionarioRouter.Remover(id);
                            break;
                        case 0:
                            Console.WriteLine("\n\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\n\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarClientes(ClienteRouter clienteRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();    
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Clientes");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Clientes");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Atualizar Clientes");
                Console.WriteLine("4. Remover Clientes");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Cliente cliente = CriarEntidade.CriarCliente();
                            clienteRouter.Adicionar(cliente);
                            break;
                        case 2:
                        
                            List<Cliente> clientes = clienteRouter.Listar();
                            
                            Console.WriteLine("\nClientes cadastrados:");
                            
                            foreach (var c in clientes){
                                Console.WriteLine($"\nNome: {c.Nome}\nCPF: {c.Cpf}\nTelefone: {c.Telefone}");
                            }  
                            break;
                        case 3:
                            List<Cliente> clienteAtualizado = clienteRouter.Atualizar();
                            Console.WriteLine("\nClientes atualizados:");
                            foreach (var c in clienteAtualizado)
                            {
                                Console.WriteLine($"\n\nID: {c.Id}, Nome: {c.Nome}, CPF: {c.Cpf}, Telefone: {c.Telefone}\n");
                            }
                            break;
                        case 4:
                            int id;
                            
                             while (true)
                            {
                                Console.WriteLine("Digite o ID do Cliente a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            clienteRouter.Remover(id);
                            break;
                        case 0:
                            Console.WriteLine("\n\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\n\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        public static void GerenciarFornecedores(FornecedorRouter fornecedorRouter) // exemplo de segundo menu
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("  Gerenciar Fornecedores");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Adicionar Fornecedores");
                Console.WriteLine("2. Listar Fornecedores");
                Console.WriteLine("3. Atualizar Fornecedores");
                Console.WriteLine("4. Remover Fornecedores");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Fornecedor fornecedor = CriarEntidade.CriarFornecedor();
                            fornecedorRouter.Adicionar(fornecedor);
                            break;
                        case 2:
                            List<Fornecedor> fornecedores = fornecedorRouter.Listar();
                            
                            Console.WriteLine("\nFornecedores cadastrados:");

                            foreach(var c in fornecedores){
                                Console.WriteLine($"\nRazao Social: {c.RazaoSocial}\nCNPJ: {c.Cnpj}\nTelefone: {c.Telefone}");
                            }
                            break;
                        case 3:
                        
                            
                            fornecedorRouter.Atualizar();

                            break;
                        case 4:
                            int id;
                            
                             while (true)
                            {
                                Console.WriteLine("Digite o ID do Fornecedor a ser removido: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                                }
                            }
                            fornecedorRouter.Remover(id); 
                            break;
                        case 0:
                            Console.WriteLine("\n\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("\n\nOpção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\nEntrada inválida! Por favor, insira um número.");
                    option = 5;
                }
                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }
    }
}