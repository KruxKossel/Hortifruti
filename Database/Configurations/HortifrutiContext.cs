using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Database.Configurations
{
    public class HortifrutiContext(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public SQLiteConnection DbConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void InicializeDatabase()
        {
            try
            {
                using(DbConnection()){
                    
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS clientes (
                            Id INTEGER PRIMARY KEY,
                            Nome TEXT NOT NULL,
                            CPF TEXT,
                            Telefone TEXT
                        );
                        CREATE TABLE IF NOT EXISTS estoque (
                            Id INTEGER PRIMARY KEY,
                            ProdutoId INTEGER,
                            Quantidade INTEGER,
                            FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
                        );
                        CREATE TABLE IF NOT EXISTS fornecedores (
                            Id INTEGER PRIMARY KEY,
                            Razao_Social TEXT NOT NULL,
                            CNPJ TEXT NOT NULL,
                            Telefone TEXT
                        );
                        CREATE TABLE IF NOT EXISTS funcionarios (
                            Id INTEGER PRIMARY KEY,
                            Nome TEXT NOT NULL,
                            CPF TEXT NOT NULL,
                            Cargo TEXT
                        );
                        CREATE TABLE IF NOT EXISTS itens_venda (
                            Id INTEGER PRIMARY KEY,
                            VendaId INTEGER,
                            ProdutoId INTEGER,
                            Quantidade INTEGER,
                            Preco REAL,
                            FOREIGN KEY (VendaId) REFERENCES Venda(Id),
                            FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
                        );
                        CREATE TABLE IF NOT EXISTS produtos (
                            Id INTEGER PRIMARY KEY,
                            FornecedorId INTEGER,
                            Nome TEXT NOT NULL,
                            Preco REAL,
                            FOREIGN KEY (FornecedorId) REFERENCES Fornecedor(Id)
                        );
                        CREATE TABLE IF NOT EXISTS vendas (
                            Id INTEGER PRIMARY KEY,
                            ClienteId INTEGER,
                            Data TEXT,
                            Total REAL,
                            FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
                        );
                    ";

                    using (var comando = DbConnection().CreateCommand()){

                        comando.CommandText = createTableQuery;
                        comando.ExecuteNonQuery();

                    }
                }
            }
            catch(SQLiteException sqLiteEx)
            {
                Console.WriteLine("Error SQLite:" + sqLiteEx.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error geral:" + ex.Message);
            }  
        } 
    }
}