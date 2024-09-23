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
    public class FuncionarioRepository(string connectionString) : ICrud<Funcionario>
    {
        private readonly string _connectionString = connectionString;

        public (bool, decimal) Adicionar(Funcionario entidade)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(entidade.Nome))
                {
                    Console.WriteLine("Erro: Nome do funcionário não pode ser vazio.");
                    return (false,0);
                }
                 if (string.IsNullOrWhiteSpace(entidade.Cpf))
                {
                    Console.WriteLine("Erro: CPF do funcionário não pode ser vazio.");
                    return (false,0);
                }
                
                
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // add
                    using (var comando = connection.DbConnection().CreateCommand())
                    {

                        comando.CommandText = "INSERT INTO funcionarios (Nome, CPF, Cargo) VALUES (@nome, @cpf, @cargo)";
                        comando.Parameters.AddWithValue("@nome", entidade.Nome);
                        comando.Parameters.AddWithValue("@cpf", entidade.Cpf);
                        comando.Parameters.AddWithValue("@cargo", entidade.Cargo);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true,0); // cliente adicionado com sucesso
                }

            }
            catch (SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
                return (false,0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error geral:" + ex.Message);
                return (false,0);
            }
            throw new NotImplementedException();
        }


        public List<Funcionario> Atualizar()
        {
           List<Funcionario> funcionarioAtualizado = new List<Funcionario>();

            var (funcionario, id) = AtualizarEntidade.AtualizarFuncionario();

            try
            {
                if (!string.IsNullOrWhiteSpace(funcionario.Nome) && !string.IsNullOrWhiteSpace(funcionario.Cpf) && !string.IsNullOrWhiteSpace(funcionario.Cargo))
                {
                    var connection = new HortifrutiContext(_connectionString);
                    using (connection.DbConnection())
                    {
                        using (var comando = connection.DbConnection().CreateCommand())
                        {
                            comando.CommandText = "UPDATE funcionarios SET Nome = @nome, CPF = @cpf, Cargo = @cargo WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                            comando.Parameters.AddWithValue("@cpf", funcionario.Cpf );
                            comando.Parameters.AddWithValue("@cargo", funcionario.Cargo);

                            int linhasAfetadas = comando.ExecuteNonQuery();
                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Dados atualizados com sucesso");
                                funcionarioAtualizado.Add(funcionario);
                            }
                            else
                            {
                                Console.WriteLine("Nenhum dado encontrado");
                            }
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(funcionario.Nome) && string.IsNullOrWhiteSpace(funcionario.Cpf) && string.IsNullOrWhiteSpace(funcionario.Cargo))
                {
                    var connection = new HortifrutiContext(_connectionString);
                    using (connection.DbConnection())
                    {
                        using (var comando = connection.DbConnection().CreateCommand())
                        {
                            comando.CommandText = "UPDATE funcionarios SET Nome = @nome WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@nome", funcionario.Nome);

                            int linhasAfetadas = comando.ExecuteNonQuery();
                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Nome atualizado com sucesso");
                                funcionarioAtualizado.Add(funcionario);
                            }
                            else
                            {
                                Console.WriteLine("Nenhum dado encontrado");
                            }
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(funcionario.Cpf) && string.IsNullOrWhiteSpace(funcionario.Nome) && string.IsNullOrWhiteSpace(funcionario.Cargo)) 
                { 
                    var connection = new HortifrutiContext(_connectionString);
                    using (connection.DbConnection())
                    {
                        using (var comando = connection.DbConnection().CreateCommand())
                        {
                            comando.CommandText = "UPDATE funcionarios SET CPF = @cpf WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@cpf", funcionario.Cpf );

                            int linhasAfetadas = comando.ExecuteNonQuery();
                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("CPF atualizados com sucesso");
                                funcionarioAtualizado.Add(funcionario);
                            }
                            else
                            {
                                Console.WriteLine("Nenhum dado encontrado");
                            }
                        }
                    }
                } 
                else if(!string.IsNullOrWhiteSpace(funcionario.Cargo) && string.IsNullOrWhiteSpace(funcionario.Cpf) && string.IsNullOrWhiteSpace(funcionario.Nome))
                {
                    var connection = new HortifrutiContext(_connectionString);
                    using (connection.DbConnection())
                    {
                        using (var comando = connection.DbConnection().CreateCommand())
                        {
                            comando.CommandText = "UPDATE funcionarios SET Cargo = @cargo WHERE Id = @id";
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@cargo", funcionario.Cargo);

                            int linhasAfetadas = comando.ExecuteNonQuery();
                            if (linhasAfetadas > 0)
                            {
                                Console.WriteLine("Cargo atualizados com sucesso");
                                funcionarioAtualizado.Add(funcionario);
                            }
                            else
                            {
                                Console.WriteLine("Nenhum dado encontrado");
                            }
                        }
                    }
                } 
                else 
                {
                    Console.Clear();
                    Console.WriteLine("\nNenhum dado inserido!\n\n");
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
            return funcionarioAtualizado;
        }

        public List<Funcionario> Listar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM funcionarios";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Funcionario Funcionario = new Funcionario(
                                    leitor["Nome"].ToString(),
                                    leitor["Cpf"].ToString(),
                                    leitor["Cargo"].ToString()
                                );
                                funcionarios.Add(Funcionario);
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

            return funcionarios;
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
                        comando.CommandText = "DELETE FROM funcionarios WHERE Id = @id ";
                        comando.Parameters.AddWithValue("@id",id);

                        int linhasAfetadas = comando.ExecuteNonQuery();


                        if(linhasAfetadas>0){
                            Console.WriteLine("Funcionario removido com sucesso!");
                            return true;
                        }else{
                            Console.WriteLine("Funcionario encontrado com id especificado");
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
