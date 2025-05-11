using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void novoAgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form is FormEscolhaServico)
                {
                    form.Activate();
                    return;
                }
            }

            FormEscolhaServico formescolhaServico = new FormEscolhaServico();
            formescolhaServico.MdiParent = this;
            formescolhaServico.Show();

        }

        private void cadastrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FormFiltrarClientes)
                {
                    form.Activate();
                    return;
                }
            }

            FormFiltrarClientes formFiltrarClientes = new FormFiltrarClientes();
            formFiltrarClientes.MdiParent = this;
            formFiltrarClientes.Show();
        }



        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cadastroProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProdutos cadastroProdutos = new CadastroProdutos();
            cadastroProdutos.Show();
            this.Hide();
        }

        private void cadastrarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CadastroCliente cadastroCliente = new CadastroCliente();
            cadastroCliente.MdiParent = this;
            cadastroCliente.Show();

        }
    }
}
