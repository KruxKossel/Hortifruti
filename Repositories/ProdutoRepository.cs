using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Database.Configurations;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class ProdutoRepository(string connectionString) : ICrud<Produto>
    {
        private readonly string _connectionString = connectionString;

        public bool Adicionar(Produto entidade)
        {
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM fornecedores WHERE id = @id";
                        checkCommand.Parameters.AddWithValue("@id", entidade.FornecedorId);

                        var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine($"\nID {entidade.FornecedorId} encontrado no banco de dados.\n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"\n\nID {entidade.FornecedorId} não existe. \n");
                            return false;
                        }
                    }

                    // add
                    using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "INSERT INTO produtos (FornecedorId, Nome, Preco) VALUES (@fornecedorId, @nome, @preco)";
                        comando.Parameters.AddWithValue("@fornecedorId", entidade.FornecedorId);
                        comando.Parameters.AddWithValue("@nome", entidade.Nome);
                        comando.Parameters.AddWithValue("@preco", entidade.Preco);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return true; // cliente adicionado com sucesso

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

        public List<Produto> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Produto> Listar()
        {
            List<Produto> produto = new List<Produto>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM produtos";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {

                                //ellen quebrou minhas pernas com essa modificação sem avisar kk
                                int Fornecedor = leitor["FornecedorId"] != DBNull.Value ? Convert.ToInt32(leitor["FornecedorId"]) : 0;
                                string Nome = leitor["Nome"] != DBNull.Value ? leitor["Nome"].ToString() : string.Empty;

                                decimal Preco = leitor["Preco"] != DBNull.Value ? Convert.ToDecimal(leitor["Preco"]) : 0;

                                Produto produtos = new Produto(Fornecedor, Nome, Preco);
                                produto.Add(produtos);
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
            return produto;
        }


        public bool Remover(int id)
        {
           try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "DELETE FROM produtos WHERE Id = @id ";
                        comando.Parameters.AddWithValue("@id",id);

                        int linhasAfetadas = comando.ExecuteNonQuery();


                        if(linhasAfetadas>0){
                            Console.WriteLine("Produto removido com sucesso!");
                            return true;
                        }else{
                            Console.WriteLine("Produto nao encontrado!");
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