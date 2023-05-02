using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace RM_Colocar.Models
{
    public class Cidade
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string uf { get; set; }

        

        public void incluir()
        {

            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("INSERT INTO cidades (nome, uf) VALUES (@nome, @uf);", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@uf", uf);
                Banco.comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }
         public void Excluir ()
         {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("delete from cidades where id = @id", Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery ();
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
         }
          
        public  DataTable consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("SELECT * FROM Cidades where nome like @Nome order by nome",Banco.conexao);
                Banco.comando.Parameters.AddWithValue("@Nome", nome + "%");
                Banco.adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
                
            }

        }


        public void Alterar()
        {

            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("Update cidades set nome = @nome,uf = @uf where id = @id ", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@uf", uf);
                Banco.comando.Parameters.AddWithValue("@id", id);

                Banco.comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        

    }

}
