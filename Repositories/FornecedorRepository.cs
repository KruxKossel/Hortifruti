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
        public bool Adicionar(Fornecedor entidade)
        {
            if (string.IsNullOrWhiteSpace(entidade.RazaoSocial))
            {
                Console.WriteLine("Erro: Razao Social do fornecedor não pode ser vazia.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(entidade.Cnpj))
            {
                Console.WriteLine("Erro: CNPJ do fornecedor não pode ser vazio.");
                return false;
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
                    return true; // fornecedor adicionado com sucesso

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

      public List<Fornecedor> Atualizar()
        {
            List<Fornecedor> fornecedorAtualizado = new List<Fornecedor>();

            var (fornecedor, id) = AtualizarEntidade.AtualizarFornecedor();

            if (string.IsNullOrWhiteSpace(fornecedor.RazaoSocial))
            {
                Console.WriteLine("Erro: Razao Social do fornecedor não pode ser vazia.");
                return fornecedorAtualizado;
            }

            if (string.IsNullOrWhiteSpace(fornecedor.Cnpj))
            {
                Console.WriteLine("Erro: CNPJ do fornecedor não pode ser vazio.");
                return fornecedorAtualizado;
            }

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET Razao_Social = @razao_social, CNPJ = @cnpj, Telefone = @telefone WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@razao_social", fornecedor.RazaoSocial);
                        comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                        comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
                            fornecedorAtualizado.Add(fornecedor);
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
                            Console.WriteLine("Fornecedor encontrado com id especificado");
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