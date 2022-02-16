using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClientesProjeto.Conexoes
{
    public class SqlServer
    {
        private readonly SqlConnection _conexao;

        public SqlServer()
        {
            this._conexao = new SqlConnection(@"Server=DESKTOP-05IP2B2\SQLEXPRESS ;Database=LOJA;User Id=sa;Password=Pardini2021!;");

        }
        public void InserirClientes(Entidades.Clientes cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Clientes
                                (Nome, Cpf, Email, Telefone)
                               VALUES
                                (@Nome, @Cpf, @Email, @Telefone);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    
                    cmd.Parameters.AddWithValue("Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("Email", cliente.Email);
                    cmd.Parameters.AddWithValue("Telefone", cliente.Telefone);
                    





                    cmd.ExecuteNonQuery();


                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Entidades.Clientes> ListarClientes()
        {
            var clientes = new List<Entidades.Clientes>();
            try
            {
                _conexao.Open();

                string query = @"Select * FROM Clientes";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var cliente = new Entidades.Clientes();
                        
                        cliente.Nome = rdr["Nome"].ToString();
                        cliente.Email = rdr["Email"].ToString();
                        cliente.Telefone = rdr["Telefone"].ToString();
                        cliente.Cpf = rdr["Cpf"].ToString();



                        clientes.Add(cliente);
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

            return clientes;
        }

    }
}

            
