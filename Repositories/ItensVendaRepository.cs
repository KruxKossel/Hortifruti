using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Database.Configurations;
using Hortifruti.Menus;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class ItensVendaRepository(string connectionString) : ICrud<ItensVenda>
    {
        private readonly string _connectionString = connectionString;

        public (bool, decimal) Adicionar(ItensVenda entidade)
        {
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM produtos WHERE id = @id";
                        checkCommand.Parameters.AddWithValue("@id", entidade.ProdutoId);

                        var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine($"\nID {entidade.ProdutoId} encontrado no banco de dados.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\n\nID {entidade.ProdutoId} não existe. \n");
                            return (false, 0);
                        }
                    }

                    decimal precoProduto = 0;

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT Preco FROM produtos WHERE Id = @produtoId";
                        comando.Parameters.AddWithValue("@produtoId", entidade.ProdutoId);

                        using (var leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                precoProduto = leitor["Preco"] != DBNull.Value ? Convert.ToDecimal(leitor["Preco"]) : 0;
                            }
                        }
                    }

                    var vendaPreco = new ItensVenda(entidade.ProdutoId, entidade.Quantidade, precoProduto);

                    decimal total = entidade.Quantidade * vendaPreco.Preco;

                    // add
                    using (var comandoInsert = connection.DbConnection().CreateCommand())
                    {
                        comandoInsert.CommandText = "INSERT INTO itens_venda (ProdutoId, Quantidade, Preco) VALUES (@produtoId, @quantidade, @preco)";
                        comandoInsert.Parameters.AddWithValue("@produtoId", entidade.ProdutoId);
                        comandoInsert.Parameters.AddWithValue("@quantidade", entidade.Quantidade);
                        comandoInsert.Parameters.AddWithValue("@preco", vendaPreco.Preco);

                        comandoInsert.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true, total); 
                }

            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
                return (false,0);

            }
            catch(Exception ex){
                Console.WriteLine("Error geral:" + ex.Message);
                return (false,0);
            }
        }

        public List<ItensVenda> Atualizar()
        {
            List<ItensVenda> itensVendasAtt = [];

           var (entidade, id) = AtualizarEntidade.AtualizarItensVenda();

            try
            {
                double total = Convert.ToDouble(entidade.Quantidade) * Convert.ToDouble(entidade.Preco);
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM itens_venda WHERE Id = @id AND ProdutoId = @produtoid";
                        checkCommand.Parameters.AddWithValue("@id", id);
                        checkCommand.Parameters.AddWithValue("@produtoid", entidade.ProdutoId);

                        var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine($"\nID {id} encontrado no banco de dados.\n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"\n\nID {id} não existe. \n");
                            return itensVendasAtt;
                        }
                    }

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE itens_venda SET ProdutoId = @produtoid, Quantidade = @quantidade, Preco = @preco WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@produtoid", entidade.ProdutoId);
                        comando.Parameters.AddWithValue("@quantidade", entidade.Quantidade);
                        comando.Parameters.AddWithValue("@preco", entidade.Preco);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
                            itensVendasAtt.Add(entidade);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum dado encontrado");
                        }
                    }
                    //     using (var comando = connection.DbConnection().CreateCommand()){

                    //     comando.CommandText = "UPDATE vendas SET Total = @total WHERE Id = @vendaId";
                    //     comando.Parameters.AddWithValue("@total", total);
                    //     comando.ExecuteNonQuery();
                    // }
                }
            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Erro SQLite: " + sqLiteEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }
            return itensVendasAtt;
        }

        public List<ItensVenda> Listar()
        {
            List<ItensVenda> itensVenda = new List<ItensVenda>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM itens_venda";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                            int id = leitor["Id"] != DBNull.Value ? Convert.ToInt32(leitor["Id"]) : 0;
                            int ProdutoId = leitor["ProdutoId"] != DBNull.Value ? Convert.ToInt32(leitor["ProdutoId"]) : 0;
                            int Quantidade = leitor["Quantidade"] != DBNull.Value ? Convert.ToInt32(leitor["Quantidade"]) : 0;
                            decimal Preco = leitor["Preco"] != DBNull.Value ? Convert.ToDecimal(leitor["Preco"]) : 0.0m;

                                ItensVenda itenVenda = new( ProdutoId, Quantidade, Preco);
                                itensVenda.Add(itenVenda);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error geral:" + ex.Message);
            }

            return itensVenda;
        }

        public bool Remover(int id)
        {
            try
            {

                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM itens_venda WHERE Id = @id";
                        checkCommand.Parameters.AddWithValue("@id", id);
                        

                        var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine($"\nID {id} encontrado no banco de dados.\n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"\n\nID {id} não existe. \n");
                            return false;
                        }
                    }
                    

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "DELETE FROM itens_venda WHERE Id = @id ";
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if(linhasAfetadas>0){
                            Console.WriteLine("\nCliente removido com sucesso!");
                            return true;
                        }else{
                            Console.WriteLine("\nCliente não encontrado");
                            return false;
                        }
                    }
                }
            }
           catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error geral:" + ex.Message);
                return false;
            }
        
        }
    }
}