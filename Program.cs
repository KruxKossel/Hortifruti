




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
    Console.WriteLine("4. Gerenciar Itens de Venda");
    Console.WriteLine("5. Gerenciar Fornecedores");
    Console.WriteLine("6. Gerenciar Clientes");
    Console.WriteLine("7. Gerenciar Funcionários");
    Console.WriteLine("0. Sair");
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
        case 5:
            //
            break;
        case 6:
            //
            break;
        case 7:
            //
            break;
        case 0:
            Console.WriteLine("Saindo...");
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
} while (option != 0);




static void GerenciarProdutos() // exemplo de segundo menu
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