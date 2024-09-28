using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Database.Configurations;
using Hortifruti.Models;
using Hortifruti.Menus;
using Hortifruti.Services;

namespace Hortifruti.Repositories
{
    public class EstoqueRepository(string connectionString) : ICrud<Estoque>
    {
        private readonly string _connectionString = connectionString;

        public (bool, decimal) Adicionar(Estoque entidade)
        {
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

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
                    
                    using (var comando = connection.DbConnection().CreateCommand())
                    {

                        comando.CommandText = "INSERT INTO estoque (ProdutoId, Quantidade) VALUES (@produtoId, @quantidade)";
                        comando.Parameters.AddWithValue("@produtoId", entidade.ProdutoId);
                        comando.Parameters.AddWithValue("@quantidade", entidade.Quantidade);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true, 0); 
                }

            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
                return (false, 0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error geral:" + ex.Message);
                return (false, 0);
            }
        }

        public List<Estoque> Atualizar()
        {
            List<Estoque> estoqueAtualizado = new List<Estoque>();

            var (estoque, id) = AtualizarEntidade.AtualizarEstoque();

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM estoque WHERE id = @id";
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
                            return estoqueAtualizado;
                        }
                    }

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE estoque SET ProdutoId = @produtoId, Quantidade = @quantidade WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@produtoId", estoque.ProdutoId);
                        comando.Parameters.AddWithValue("@quantidade", estoque.Quantidade);


                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
                            estoqueAtualizado.Add(estoque);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum dado alterado");
                        }
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
            return estoqueAtualizado;
        }

        public List<Estoque> Listar()
        {
            List<Estoque> estoques = new List<Estoque>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM estoque";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                int produtoId = leitor["ProdutoId"] != DBNull.Value ? Convert.ToInt32(leitor["ProdutoId"]) : 0;
                                int quantidade = leitor["Quantidade"] != DBNull.Value ? Convert.ToInt32(leitor["Quantidade"]) : 0;
                                Estoque estoque = new(produtoId,quantidade);
                                estoques.Add(estoque);
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
            return estoques;
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
                        checkCommand.CommandText = "SELECT COUNT(1) FROM estoque WHERE Id = @id";
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
                        comando.CommandText = "DELETE FROM estoque WHERE Id = @id ";
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if(linhasAfetadas>0){
                            Console.WriteLine("\nProduto removido com sucesso do Estoque!");
                            return true;
                        }else{
                            Console.WriteLine("\nProduto não encontrado no Estoque");
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
