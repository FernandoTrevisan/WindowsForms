﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RM_Colocar
{
    public class Banco
    {
        public static MySqlConnection conexao;
        public static MySqlCommand comando;
        public static MySqlDataAdapter adaptador;
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                string server = "localhost";
                string porta = "3307";
                string uid = "root";
                string pwd = "etecjau";

                conexao = new MySqlConnection($"server={server};port={porta};uid={uid};pwd={pwd}");
                conexao.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas;", conexao);
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades"+
                    "(id integer auto_increment primary key,"+
                    "nome varchar(40),"+
                    "uf char(02));",conexao);

                comando.ExecuteNonQuery();

               comando = new  MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas " +
                   "(id integer auto_increment primary key," +
                   "marca char (20));" , conexao);
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias " +
                   "(id integer auto_increment primary key," +
                   "categoria char (20));", conexao);
                comando.ExecuteNonQuery();

                comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS" +
                                            "(Id integer auto_increment primary key," +
                                            "nome char(40)," +
                                            "idCidade integer," +
                                            "dataNasc date," +
                                            "renda decimal(10,2)," +
                                            "cpf char(14)," +
                                            "foto varchar(100)," +
                                            "venda boolean)", conexao);
                comando.ExecuteNonQuery();


                FecharConexao();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }




}

