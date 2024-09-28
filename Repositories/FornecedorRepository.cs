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
    public class FornecedorRepository(string connectionString) : ICrud<Fornecedor>
    {
        private readonly string _connectionString = connectionString;
        public (bool, decimal) Adicionar(Fornecedor entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.RazaoSocial))
            {
                Console.WriteLine("Erro: Razao Social do fornecedor não pode ser vazia.");
                return (false,0);
            }

            if (string.IsNullOrWhiteSpace(entidade.Cnpj))
            {
                Console.WriteLine("Erro: CNPJ do fornecedor não pode ser vazio.");
                return (false,0);
            }

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // add
                    using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "INSERT INTO fornecedores (Razao_Social, CNPJ, Telefone) VALUES (@razao_social, @cnpj, @telefone)";
                        comando.Parameters.AddWithValue("@razao_social", entidade.RazaoSocial);
                        comando.Parameters.AddWithValue("@cnpj", entidade.Cnpj);
                        comando.Parameters.AddWithValue("@telefone", entidade.Telefone);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true,0); // fornecedor adicionado com sucesso

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

      public List<Fornecedor> Atualizar()
        {
            List<Fornecedor> fornecedorAtualizado = new List<Fornecedor>();

            var (fornecedor, id) = AtualizarEntidade.AtualizarFornecedor();

            try
            {
                var connection = new HortifrutiContext(_connectionString);

                if(!string.IsNullOrWhiteSpace(fornecedor.RazaoSocial) && !string.IsNullOrWhiteSpace(fornecedor.Cnpj) && !string.IsNullOrWhiteSpace(fornecedor.Telefone))
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET Razao_Social = @razao_social, CNPJ = @cnpj, Telefone = @telefone WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);
                        comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                        comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 2)
                        {
                            Console.WriteLine("Dados atualizados com sucesso!");
                            fornecedorAtualizado.Add(fornecedor);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum dado alterado...");
                        }
                    }
                }
                else if(!string.IsNullOrWhiteSpace(fornecedor.RazaoSocial) && string.IsNullOrWhiteSpace(fornecedor.Cnpj) && string.IsNullOrWhiteSpace(fornecedor.Telefone))
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET Razao_Social = @razao_social WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Razão Social atualizada com sucesso!");
                            fornecedorAtualizado.Add(fornecedor);
                        }
                        else
                        {
                            Console.WriteLine("Razão Social não alterada...");
                        }
                    }
                }
                else if(string.IsNullOrWhiteSpace(fornecedor.RazaoSocial) && !string.IsNullOrWhiteSpace(fornecedor.Cnpj) && string.IsNullOrWhiteSpace(fornecedor.Telefone))
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET CNPJ = @cnpj WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("CNPJ atualizado com sucesso!");
                            fornecedorAtualizado.Add(fornecedor);
                        }
                        else
                        {
                            Console.WriteLine("CNPJ não alterado....");
                        }
                    }
                }
                else if(string.IsNullOrWhiteSpace(fornecedor.RazaoSocial) && string.IsNullOrWhiteSpace(fornecedor.Cnpj) && !string.IsNullOrWhiteSpace(fornecedor.Telefone))
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET Telefone = @telefone WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Telefone atualizado com sucesso");
                            fornecedorAtualizado.Add(fornecedor);
                        }
                        else
                        {
                            Console.WriteLine("Telefone não alterado...");
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
            return fornecedorAtualizado;
        }
                

        public List<Fornecedor> Listar()
        {
          List<Fornecedor> fornecedor = new List<Fornecedor>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM fornecedores";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                string razaoSocial = leitor["Razao_Social"] != DBNull.Value ? leitor["Razao_Social"].ToString() : string.Empty;
                                string cnpj = leitor["CNPJ"] != DBNull.Value ? leitor["CNPJ"].ToString() : string.Empty;
                                string telefone = leitor["Telefone"] != DBNull.Value ? leitor["Telefone"].ToString() : string.Empty;

                                Fornecedor fornecedores = new(razaoSocial, cnpj, telefone);
                                fornecedor.Add(fornecedores);
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
            return fornecedor;
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
                        comando.CommandText = "DELETE FROM fornecedores WHERE Id = @id ";
                        comando.Parameters.AddWithValue("@id",id);

                        int linhasAfetadas = comando.ExecuteNonQuery();


                        if(linhasAfetadas>0){
                            Console.WriteLine("Fornecedor removido com sucesso!");
                            return true;
                        }else{
                            Console.WriteLine("Fornecedor não encontrado...");
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