using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;
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
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Por favor, insira um número.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
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
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Por favor, insira um número.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
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
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Por favor, insira um número.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
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
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Por favor, insira um número.");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
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
                            //
                            break;
                        case 3:
                            //
                            break;
                        case 4:
                            // 
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
                }
                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }
    }
}