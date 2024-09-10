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

      public List<Fornecedor> Atualizar()
        {
            List<Fornecedor> fornecedor = new List<Fornecedor>();

            Console.WriteLine("Digite o id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nova razão social:");
            string razaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o novo CNPJ:");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Digite o novo telefone:");
            string telefone = Console.ReadLine();

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE fornecedores SET Razao_Social = @razao_social, CNPJ = @cnpj, Telefone = @telefone WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@razao_social", razaoSocial);
                        comando.Parameters.AddWithValue("@cnpj", cnpj);
                        comando.Parameters.AddWithValue("@telefone", telefone);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
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
            return fornecedor;
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
                                Fornecedor fornecedores = new Fornecedor(
                                    leitor["Razao_Social"].ToString(),
                                    leitor["CNPJ"].ToString(),
                                    leitor["Telefone"].ToString()
                                );
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

        public bool Remover(Fornecedor entidade)
        {
            try
            {
                 Console.WriteLine("Digite o ID do Fornecedor a ser removido: ");
                 int id = int.Parse(Console.ReadLine());

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