using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RM_Colocar.Views;


namespace RM_Colocar
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {

            Banco.CriarBanco();

        }

       

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
            FrmCidades form = new FrmCidades();
            form.Show();

        }

       

        private void marcasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmMarcas form = new FrmMarcas();
            form.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.Show();
        }
    }
}
