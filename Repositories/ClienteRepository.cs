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
    public class ClienteRepository(string connectionString) : ICrud<Cliente>
    {

        private readonly string _connectionString = connectionString;

        public (bool, decimal) Adicionar(Cliente entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.Nome))
            {
                Console.WriteLine("Erro: Nome do cliente não pode ser vazio.");
                return (false, 0);
            }

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // add
                    using (var comando = connection.DbConnection().CreateCommand())
                    {

                        comando.CommandText = "INSERT INTO clientes (Nome, CPF, Telefone) VALUES (@nome, @cpf, @telefone)";
                        comando.Parameters.AddWithValue("@nome", entidade.Nome);
                        comando.Parameters.AddWithValue("@cpf", entidade.Cpf);
                        comando.Parameters.AddWithValue("@telefone", entidade.Telefone);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true, 0); // cliente adicionado com sucesso
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

        public List<Cliente> Atualizar()
        {
            
           List<Cliente> clienteAtualizado = [];

           var (entidade, id) = AtualizarEntidade.AtualizarCliente();


           if (string.IsNullOrWhiteSpace(entidade.Nome))
            {
                Console.WriteLine("Erro: Nome do cliente não pode ser vazio.");
                return clienteAtualizado;
            }

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM clientes WHERE id = @id";
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
                            return clienteAtualizado;
                        }
                    }

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE clientes SET Nome = @nome, CPF = @cpf, Telefone = @telefone WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@nome", entidade.Nome);
                        comando.Parameters.AddWithValue("@cpf", entidade.Cpf);
                        comando.Parameters.AddWithValue("@telefone", entidade.Telefone);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
                            clienteAtualizado.Add(entidade);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum dado encontrado");
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
            return clienteAtualizado;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM clientes";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                string nome = leitor["Nome"] != DBNull.Value ? leitor["Nome"].ToString() : string.Empty;
                                string cpf = leitor["Cpf"] != DBNull.Value ? leitor["Cpf"].ToString() : string.Empty;
                                string telefone = leitor["Telefone"] != DBNull.Value ? leitor["Telefone"].ToString() : string.Empty;

                                Cliente cliente = new(nome, cpf, telefone);
                                clientes.Add(cliente);
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

            return clientes;
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
                        checkCommand.CommandText = "SELECT COUNT(1) FROM clientes WHERE id = @id";
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
                        comando.CommandText = "DELETE FROM clientes WHERE Id = @id ";
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
