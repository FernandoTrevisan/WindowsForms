using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RM_Colocar.Models
{
    public class Cliente
    {
        public int id { get; set; }

        public string nome { get; set; }

        public int idCidade { get; set; }

        public DateTime dataNasc { get; set; }

        public double renda { get; set; }

        public string cpf { get; set; }

        public string foto { get; set; }
        public bool venda { get; set; }

        public void Incluir()
        {

            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand("INSTERT INTO clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda)" +
                    "VALUES (@nome, @idcidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);

                Banco.comando.Parameters.AddWithValue("@idCidade", idCidade);

                Banco.comando.Parameters.AddWithValue("@dataNasc", dataNasc);

                Banco.comando.Parameters.AddWithValue("@renda", renda);

                Banco.comando.Parameters.AddWithValue("@cpf", cpf);

                Banco.comando.Parameters.AddWithValue("@foto", foto);

                Banco.comando.Parameters.AddWithValue("@venda", venda);

                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }


        public void Alterar()
        {

            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand
                    ("UPDATE  clientes SET nome = @nome, idCidade = @idCidade, dataNasc = @dataNasc, " +
                    "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);

                Banco.comando.Parameters.AddWithValue("@idCidade", idCidade);

                Banco.comando.Parameters.AddWithValue("@dataNasc", dataNasc);

                Banco.comando.Parameters.AddWithValue("@renda", renda);

                Banco.comando.Parameters.AddWithValue("@cpf", cpf);

                Banco.comando.Parameters.AddWithValue("@foto", foto);

                Banco.comando.Parameters.AddWithValue("@venda", venda);

                Banco.comando.Parameters.AddWithValue("@id", id);

                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }



        public void Excluir()
        {

            try
            {
                Banco.conexao.Open();
                Banco.comando = new MySqlCommand("delet from clientes where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();







            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        public DataTable Consultar()
        {

            try
            {
                Banco.comando = new MySqlCommand("SELECT cl.*, ci.nome cidade," +
                 "ci.uf FROM Clientes cl inner join cidades ci on (ci.id = cl.idCidade) " +
                 "where cl.nome like ?Nome order by cl.nome", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@Nome", nome + "%");
                Banco.adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.adaptador.Fill(Banco.datTabela);

                return Banco.datTabela;

            }
            catch (Exception e)

            {

                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;



            }


        }
    }

    
}