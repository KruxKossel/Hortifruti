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
    public class Menus
    {
    //  public static void RedirectVendaRouter(VendaRouter vendaRouter,ItensVendaRouter itensVendaRouter, int option){
    //     SwitchVenda(vendaRouter, itensVendaRouter, option);
    //  }
     
     public static void GerenciarMenu<T>(T Router, int option) // exemplo de segundo menu
        {
            string Letreiro= "Unknown";
            if(option == 1){Letreiro = "Produto";}
            if(option == 2){Letreiro = "Estoque";}
            if(option == 3){Letreiro = "Vendas";}
            if(option == 4){Letreiro = "Fornecedores";}
            if(option == 5){Letreiro = "Clientes";}
            if(option == 6){Letreiro = "Funcionarios";}

            do
            {
                Console.Clear();    
                Console.WriteLine("=============================");
                Console.WriteLine($"  Gerenciar {Letreiro}");
                Console.WriteLine("=============================");
                Console.WriteLine($"1. Adicionar {Letreiro}");
                Console.WriteLine($"2. Listar {Letreiro}");
                Console.WriteLine($"3. Atualizar {Letreiro}");
                Console.WriteLine($"4. Remover {Letreiro}");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out option))
                {
                    switch (option)
                    {
                        case 1:
                        RedirectRouter(Router,option);
                            break;
                        case 2:
                        RedirectRouter(Router,option);
                            break;
                        case 3:
                        RedirectRouter(Router,option);
                            break;
                        case 4:
                        RedirectRouter(Router,option);
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
        public static void RedirectRouter<T>(T Router, int option){
            switch (Router)
                    {
                        case ClienteRouter clienteRouter:
                        SwitchCliente(clienteRouter,option);
                            break;
                        case EstoqueRouter estoqueRouter:
                        SwitchEstoque(estoqueRouter,option);
                            break;
                        case FornecedorRouter fornecedorRouter:
                        SwitchFornecedor(fornecedorRouter,option);
                            break;
                        case FuncionarioRouter funcionarioRouter:
                        SwitchFuncionario(funcionarioRouter,option);
                            break;
                        case ProdutoRouter produtoRouter:
                        SwitchProduto(produtoRouter,option);
                            break;
                        case VendaRouter vendaRouter:
                        SwitchVenda(vendaRouter,option);
                            break;
                    }
        }   
        public static void SwitchCliente(ClienteRouter clienteRouter, int option){
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
        }
    }
    public static void SwitchEstoque(EstoqueRouter estoqueRouter, int option){
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
    }     
    }
    public static void SwitchFornecedor(FornecedorRouter fornecedorRouter, int option){
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
                            break;}
    }
    public static void SwitchFuncionario(FuncionarioRouter funcionarioRouter, int option){
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
                            break;}
    }
    public static void SwitchProduto(ProdutoRouter produtoRouter, int option){
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
                            break;}
    }
    public static void SwitchVenda(VendaRouter vendaRouter, int option){
        switch (option)
                    {
                        case 1:

                            var itensVenda = CriarEntidade.CriarItensVenda();
                            var (sucesso,total, idVenda) = vendaRouter.AdicionaritensVenda(itensVenda);

                            if (total != 0 || total == 5){
                                Venda venda = CriarEntidade.CriarVenda(total, idVenda);
                                vendaRouter.AdicionarVenda(venda);
                            }
                            break;
                        case 2:
                            List<Venda> vendas = vendaRouter.ListarVenda();
                            Console.WriteLine("Vendas:");
                            foreach(var vendasFeitas in vendas){
                                Console.WriteLine($"\nCliente Id: {vendasFeitas.ClienteId}\n Data: {vendasFeitas.Data}\n Total: {vendasFeitas.Total}");
                            }
                            break;
                        case 3:
                            vendaRouter.AtualizarVenda();
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
                            vendaRouter.RemoverVenda(id);
                            break;

            
    }
    }
//     public static decimal SwitchItensdeVenda(ItensVendaRouter itensVendaRouter, int option){
                
//                 switch (option)
//                     {
//                         case 1:
//                             var itensVenda = CriarEntidade.CriarItensVenda();
//                             var (sucesso, total) = itensVendaRouter.Adicionar(itensVenda);

//                             return total;
//                             break;
//                         case 2:
//                             List<ItensVenda> itensVendas = itensVendaRouter.Listar();
//                             Console.WriteLine("Itens da venda:");
//                             foreach(var iv in itensVendas){
//                             Console.WriteLine($"\nId do Produto: {iv.ProdutoId}\nQuantidade: {iv.Quantidade}\nPreco: {iv.Preco}");
//                             }                        
//                             break;
//                         case 3:
//                             itensVendaRouter.Atualizar();
//                             break;
//                         case 4:
//                             int id;
//                             while (true)
//                             {
//                                 Console.WriteLine("Digite o ID da venda a ser removido: ");
//                                 if (int.TryParse(Console.ReadLine(), out id))
//                                 {
//                                     break;
//                                 }
//                                 else
//                                 {
//                                     Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
//                                 }
//                             }
//                             itensVendaRouter.Remover(id);
//                             break;
//                         case 5:
//                             return 5;
//                             break;
//     }
//     return 0;
// }
}
}