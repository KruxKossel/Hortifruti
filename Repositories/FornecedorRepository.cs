using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Database.Configurations;
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
            throw new NotImplementedException();
        }

        public List<Fornecedor> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(Fornecedor entidade)
        {
            throw new NotImplementedException();
        }
    }
}