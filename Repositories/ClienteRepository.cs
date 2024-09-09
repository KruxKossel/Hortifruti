using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Database.Configurations;
using Hortifruti.Models;

namespace Hortifruti.Repositories
{
    public class ClienteRepository(string connectionString) : ICrud<Cliente>
    {

        private readonly string _connectionString = connectionString;

        public bool Adicionar(Cliente entidade)
        {
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                    // add
                    using (var comando = connection.DbConnection().CreateCommand()){

                        comando.CommandText = "INSERT INTO clientes (Nome, CPF, Telefone) VALUES (@nome, @cpf, @telefone)";
                        comando.Parameters.AddWithValue("@nome", entidade.Nome);
                        comando.Parameters.AddWithValue("@cpf", entidade.Cpf);
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

        public List<Cliente> Atualizar()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Listar()
        {
            throw new NotImplementedException();
        }

        public bool Remover(Cliente entidade)
        {
            throw new NotImplementedException();
        }
    }
}