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
    public class VendaRepository(string connectionString) : ICrud<Venda>
    {
        private readonly string _connectionString = connectionString;
        public (bool, decimal) Adicionar(Venda entidade)
        {
            
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = @"SELECT 
                                                        (SELECT COUNT(1) FROM clientes WHERE id = @clienteId) AS ClienteCount,
                                                        (SELECT COUNT(1) FROM itens_venda WHERE id = @itensVendaId) AS ItensVendaCount";
                        checkCommand.Parameters.AddWithValue("@clienteId", entidade.ClienteId);
                        checkCommand.Parameters.AddWithValue("@itensVendaId", entidade.ItensVendaId);

                        using (var reader = checkCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var clienteCount = Convert.ToInt32(reader["ClienteCount"]);
                                var itensVendaCount = Convert.ToInt32(reader["ItensVendaCount"]);

                                if (clienteCount > 0 && itensVendaCount > 0)
                                {
                                    Console.WriteLine($"\nID {entidade.ClienteId} encontrado na tabela 'clientes' e ID {entidade.ItensVendaId} encontrado na tabela 'itens_venda'.\n");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"\n\nID {entidade.ClienteId} ou ID {entidade.ItensVendaId} não existem. \n");
                                    return (false, 0);
                                }
                            }
                        }
                    }

                    
                    using (var comando = connection.DbConnection().CreateCommand())
                    {

                        comando.CommandText = "INSERT INTO vendas (ClienteId, ItensVendaId, Data, Total) VALUES (@clienteid, @itensVendaId, @data, @total)";
                        comando.Parameters.AddWithValue("@clienteid", entidade.ClienteId);
                        comando.Parameters.AddWithValue("@itensVendaId", entidade.ItensVendaId);
                        comando.Parameters.AddWithValue("@data", entidade.Data);
                        comando.Parameters.AddWithValue("@total", entidade.Total);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return (true,0);
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
        }

        public List<Venda> Atualizar()
        {
            List<Venda> VendasAtt = [];

           var (entidade, id) = AtualizarEntidade.AtualizarVenda();

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {

                   // checa id
                    using (var checkCommand = connection.DbConnection().CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(1) FROM vendas WHERE Id = @id";
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
                            return VendasAtt;
                        }
                    }

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE vendas SET ClienteId = @clienteid, WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@clienteid", entidade.ClienteId);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Dados atualizados com sucesso");
                            VendasAtt.Add(entidade);
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
            return VendasAtt;
        }

        public List<Venda> Listar()
        {
            List<Venda> vendas = new List<Venda>();
            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "SELECT * FROM vendas";
                        using (var leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                int id = leitor["Id"] != DBNull.Value ? Convert.ToInt32(leitor["Id"]) : 0;
                                int clienteId = leitor["ClienteId"] != DBNull.Value ? Convert.ToInt32(leitor["ClienteId"]) : 0;
                                int itensVendaId = leitor["ItensVendaId"] != DBNull.Value ? Convert.ToInt32(leitor["ItensVendaId"]) : 0;
                                DateTime data = leitor["Data"] != DBNull.Value ? Convert.ToDateTime(leitor["Data"]) : DateTime.MinValue;
                                decimal total = leitor["Total"] != DBNull.Value ? Convert.ToDecimal(leitor["Total"]) : 0.0m;

                                Venda venda = new(clienteId, itensVendaId, data, total);
                                vendas.Add(venda);
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

            return vendas;
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
                        checkCommand.CommandText = "SELECT COUNT(1) FROM vendas WHERE Id = @id";
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
                        comando.CommandText = "DELETE FROM vendas WHERE Id = @id ";
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