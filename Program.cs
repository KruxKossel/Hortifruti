using Hortifruti.Database.Configurations;
using Hortifruti.Menus;
using Hortifruti.Repositories;
using Hortifruti.Routers;
using Hortifruti.Services;
//inicio
// =============================== Banco de Dados =============================
string connectionString = "Data Source=" + DatabaseLocal.DatabasePath;

HortifrutiContext dbManager = new(connectionString);


dbManager.InicializeDatabase();

// ================================== Produtos ==================================
ProdutoRepository produtoRepository = new(connectionString);
ProdutoService produtoService= new(produtoRepository);
ProdutoRouter produtoRouter= new(produtoService);

// ================================== Estoque ==================================
EstoqueRepository estoqueRepository = new(connectionString);
EstoqueService estoqueService = new(estoqueRepository);
EstoqueRouter estoqueRouter = new(estoqueService);

// =============================== Itens de Venda ==================================
ItensVendaRepository itensVendaRepository = new(connectionString);
ItensVendaService itensVendaService = new(itensVendaRepository);

// =================================== Vendas ==================================
VendaRepository vendaRepository = new(connectionString);
VendaService vendaService = new(vendaRepository);
VendaRouter vendaRouter = new(vendaService,itensVendaService);

// ================================== Fornecedores ==================================
FornecedorRepository fornecedorRepository = new(connectionString);
FornecedorService fornecedorService = new(fornecedorRepository);
FornecedorRouter fornecedorRouter = new(fornecedorService);

// ================================== Clientes ==================================
ClienteRepository clienteRepository = new(connectionString);
ClienteService clienteService = new(clienteRepository);
ClienteRouter clienteRouter = new(clienteService);

// ================================== Funcionários ==================================
FuncionarioRepository funcionarioRepository = new(connectionString);
FuncionarioService funcionarioService = new(funcionarioRepository);
FuncionarioRouter funcionarioRouter = new(funcionarioService);

// ================================== Menu ==================================
int option;
do
{
    Console.Clear();
    Console.WriteLine("=============================");
    Console.WriteLine("  Sistema de Gerenciamento de Hortifruti");
    Console.WriteLine("=============================");
    Console.WriteLine("1. Gerenciar Produtos");
    Console.WriteLine("2. Gerenciar Estoque");
    Console.WriteLine("3. Gerenciar Vendas");
    Console.WriteLine("4. Gerenciar Fornecedores");
    Console.WriteLine("5. Gerenciar Clientes");
    Console.WriteLine("6. Gerenciar Funcionários");
    Console.WriteLine("0. Sair");
    Console.WriteLine("=============================");
    Console.Write("Escolha uma opção: ");
    
    string input = Console.ReadLine();
    if (int.TryParse(input, out option))
    {
        switch (option)
        {
            case 1:
                Menus.GerenciarMenu(produtoRouter, option);
                break;
            case 2:
                Menus.GerenciarMenu(estoqueRouter,option);
                break;
            case 3:
                Menus.GerenciarMenu(vendaRouter,option);    
                break;
            case 4:
                Menus.GerenciarMenu(fornecedorRouter,option);    
                break;
            case 5:
                Menus.GerenciarMenu(clienteRouter,option);    
                break;
            case 6:
                Menus.GerenciarMenu(funcionarioRouter,option);
                break;
            case 0:
                    Console.WriteLine("Saindo...");
                break;
            default:
                    Console.WriteLine("\n\nOpção inválida! Tente novamente.");
                break;
        }
    }
    else
    {
        Console.WriteLine("\n\nEntrada inválida! Por favor, insira um número.");
        option = 8;
    }
    //Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
    Console.ReadKey();

} while (option != 0);