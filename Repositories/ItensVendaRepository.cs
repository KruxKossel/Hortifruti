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

        public bool Adicionar(ItensVenda entidade)
        {
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    double total = Convert.ToDouble(entidade.Quantidade) * Convert.ToDouble(entidade.Preco);
                    // add
                    using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "INSERT INTO itens_venda (VendaId, ProdutoId, Quantidade, Preco) VALUES (@vendaId, @produtoId, @quantidade, @preco)";
                        comando.Parameters.AddWithValue("@vendaId", entidade.VendaId);
                        comando.Parameters.AddWithValue("@produtoId", entidade.ProdutoId);
                        comando.Parameters.AddWithValue("@quantidade", entidade.Quantidade);
                        comando.Parameters.AddWithValue("@preco", entidade.Preco);

                        comando.ExecuteNonQuery();

                    }
                    using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "UPDATE vendas SET Total = @total WHERE Id = @vendaId";
                        comando.Parameters.AddWithValue("@vendaId", entidade.VendaId);
                        comando.Parameters.AddWithValue("@total", total);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return true; 
                }

            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
                return false;

            }
            catch(Exception ex){
                Console.WriteLine("Error geral:" + ex.Message);
                return false;
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
                        checkCommand.CommandText = "SELECT COUNT(1) FROM itens_venda WHERE Id = @id AND VendaId = @vendaid AND ProdutoId = @produtoid";
                        checkCommand.Parameters.AddWithValue("@id", id);
                        checkCommand.Parameters.AddWithValue("@vendaid", entidade.VendaId);
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
                        comando.CommandText = "UPDATE itens_venda SET VendaId = @vendaid, ProdutoId = @produtoid, Quantidade = @quantidade, Preco = @preco WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@vendaid", entidade.VendaId);
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
                        using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "UPDATE vendas SET Total = @total WHERE Id = @vendaId";
                        comando.Parameters.AddWithValue("@vendaId", entidade.VendaId);
                        comando.Parameters.AddWithValue("@total", total);
                        comando.ExecuteNonQuery();
                    }
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
                            int VendaId = leitor["VendaId"] != DBNull.Value ? Convert.ToInt32(leitor["VendaId"]) : 0;
                            int ProdutoId = leitor["ProdutoId"] != DBNull.Value ? Convert.ToInt32(leitor["ProdutoId"]) : 0;
                            int Quantidade = leitor["Quantidade"] != DBNull.Value ? Convert.ToInt32(leitor["Quantidade"]) : 0;
                            decimal Preco = leitor["Preco"] != DBNull.Value ? Convert.ToDecimal(leitor["Preco"]) : 0.0m;

                                ItensVenda itenVenda = new(VendaId, ProdutoId, Quantidade, Preco);
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