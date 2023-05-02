using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RM_Colocar.Models;


namespace RM_Colocar.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();
        }
        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };
            dgvCidades.DataSource = c.consultar();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text

            };

            c.incluir();

            limpaControles();
            carregarGrid("");





        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();







            }



        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;


            c = new Cidade()
            {

                id = int.Parse(txtID.Text),


                nome = txtNome.Text,

                uf = txtUF.Text

            };

            c.Alterar();
            limpaControles();
            carregarGrid("");


                                                                
            






        }

        private void dgvCidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
           if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)


                c = new Cidade()

                {
                    id=int.Parse(txtID.Text)


                };
            c.Excluir();
            limpaControles();
            carregarGrid("");
    
                                    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();

            carregarGrid("");


        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
            

