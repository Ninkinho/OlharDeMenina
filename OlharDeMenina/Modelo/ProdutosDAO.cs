﻿using MySql.Data.MySqlClient;

namespace OlharDeMenina.Modelo
{
    internal class ProdutosDAO
    {
        public string Mensagem { get; private set; }
        private MySqlCommand cmd = new MySqlCommand();
        private Conexao con = new Conexao();

        public string Adicionar(Produtos produtos)
        {
            con.Close();
            cmd.CommandText = "insert into produto (NomeProduto, Marca, Categoria, Descricao, Preco, Quantidade) values (@nomeproduto, @marca, @categoria, @descricao, @valor, @quantidade)";
            cmd.Parameters.AddWithValue("nomeproduto", produtos.NomeProduto);
            cmd.Parameters.AddWithValue("marca", produtos.Marca);
            cmd.Parameters.AddWithValue("categoria", produtos.Categoria);
            cmd.Parameters.AddWithValue("descricao", produtos.Descricao);
            cmd.Parameters.AddWithValue("valor", produtos.Valor);
            cmd.Parameters.AddWithValue("quantidade", produtos.Quantidade);
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                Mensagem = "Cadastrado com sucesso!!!";
            }
            catch (MySqlException ex)
            {
                Mensagem = ex.Message;
            }
            System.Windows.Forms.MessageBox.Show(Mensagem);
            return Mensagem;
        }

        public MySqlDataReader RetornaProdutos()
        {
            con.Close();
            string query = "SELECT * FROM Produto";
            MySqlCommand cmd = new MySqlCommand(query, con.Conectar());
            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                dataReader.Read();

                if (dataReader.HasRows)
                {
                    Mensagem = "Dados atualizados com sucesso!";
                    //System.Windows.Forms.MessageBox.Show(Mensagem);
                }
                else
                {
                    Mensagem = "Não há dados na tabela.";
                    System.Windows.Forms.MessageBox.Show(Mensagem);
                }
                return dataReader;
            }
            catch (MySqlException ex)
            {
                Mensagem = ex.Message;
                System.Windows.Forms.MessageBox.Show(Mensagem);
                return dataReader;
            }
        }

        public MySqlDataReader RetornaProdutos(int idProd)
        {
            con.Close();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Produto WHERE Codigo = @id", con.Conectar());
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new MySqlParameter("id", idProd));
            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                dataReader.Read();

                if (dataReader.HasRows)
                {
                    Mensagem = "Dados atualizados com sucesso!";
                    //System.Windows.Forms.MessageBox.Show(Mensagem);
                }
                else
                {
                    Mensagem = "Não há dados na tabela.";
                    System.Windows.Forms.MessageBox.Show(Mensagem);
                }
                return dataReader;
            }
            catch (MySqlException ex)
            {
                Mensagem = ex.Message;
                System.Windows.Forms.MessageBox.Show(Mensagem + ex);
                return dataReader;
            }
        }

        public string DeletarProdutos(int idProd)
        {
            con.Close();
            cmd.CommandText = "delete from produto where Codigo = @id";
            cmd.Parameters.AddWithValue("id", idProd);
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                Mensagem = "Deletado com sucesso!!!";
            }
            catch (MySqlException ex)
            {
                Mensagem = ex.Message;
            }
            return Mensagem;
        }

        public string EditarProdutos(Produtos produtos, int idProd)
        {
            con.Close();
            cmd.CommandText = "UPDATE produto SET NomeProduto = @nomeproduto, Marca = @marca, Categoria = @categoria, Descricao = @descricao, Preco = @valor, Quantidade = @quantidade WHERE Codigo = @id";
            cmd.Parameters.AddWithValue("nomeproduto", produtos.NomeProduto);
            cmd.Parameters.AddWithValue("marca", produtos.Marca);
            cmd.Parameters.AddWithValue("categoria", produtos.Categoria);
            cmd.Parameters.AddWithValue("descricao", produtos.Descricao);
            cmd.Parameters.AddWithValue("valor", produtos.Valor);
            cmd.Parameters.AddWithValue("quantidade", produtos.Quantidade);
            cmd.Parameters.AddWithValue("id", idProd);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                Mensagem = "Atualizado com Sucesso";
            }
            catch (MySqlException ex)
            {
                Mensagem = ex.Message;
            }

            return Mensagem;
        }
    }
}