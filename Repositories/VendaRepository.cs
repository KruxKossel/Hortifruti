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
        public bool Adicionar(Venda entidade)
        {
            

            try
            {
                var connection = new HortifrutiContext(_connectionString);
                using (connection.DbConnection())
                {
                    using (var comando = connection.DbConnection().CreateCommand())
                    {

                        comando.CommandText = "INSERT INTO vendas (ClienteId, Data, Total) VALUES (@clienteid, @data, @total)";
                        comando.Parameters.AddWithValue("@clienteid", entidade.ClienteId);
                        comando.Parameters.AddWithValue("@data", entidade.Data);
                        comando.Parameters.AddWithValue("@total", entidade.Total);
                        comando.ExecuteNonQuery();
                    }

                    Console.Clear();
                    Console.WriteLine("\nDados inseridos com sucesso!\n\n");
                    return true;
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
                    // using (var checkCommand = connection.DbConnection().CreateCommand())
                    // {
                    //     checkCommand.CommandText = "SELECT COUNT(1) FROM vendas WHERE id = @id";
                    //     checkCommand.Parameters.AddWithValue("@id", id);

                    //     var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    //     if (count > 0)
                    //     {
                    //         Console.WriteLine($"\nID {id} encontrado no banco de dados.\n");
                    //         Console.ReadKey();
                    //     }
                    //     else
                    //     {
                    //         Console.WriteLine($"\n\nID {id} não existe. \n");
                    //         return VendasAtt;
                    //     }
                    // }

                    using (var comando = connection.DbConnection().CreateCommand())
                    {
                        comando.CommandText = "UPDATE vendas SET ClienteId = @clienteid, Data = @data, Total = @total WHERE Id = @id";
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@clienteid", entidade.ClienteId);
                        comando.Parameters.AddWithValue("@data", entidade.Data);
                        comando.Parameters.AddWithValue("@total", entidade.Total);

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
                            int clienteId = leitor["ClienteId"] != DBNull.Value ? Convert.ToInt32(leitor["ClienteId"]) : 0;
                            DateTime data = leitor["Data"] != DBNull.Value ? Convert.ToDateTime(leitor["Data"]) : DateTime.MinValue;
                            decimal total = leitor["Total"] != DBNull.Value ? Convert.ToDecimal(leitor["Total"]) : 0.0m;

                                Venda venda = new(clienteId, data, total);
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
                        checkCommand.CommandText = "SELECT COUNT(1) FROM vendas WHERE id = @id";
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