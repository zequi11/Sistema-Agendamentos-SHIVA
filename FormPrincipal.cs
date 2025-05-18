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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

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

        private void cadastroProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProdutos cadastroProdutos = new CadastroProdutos();
            cadastroProdutos.Show();
            this.Hide();
        }

        private void cadastrarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is CadastroCliente)
                {
                    form.Activate();
                    return;
                }
            }

            CadastroCliente cadastroCliente = new CadastroCliente();
            cadastroCliente.MdiParent = this;
            cadastroCliente.Show();

        }

        private void novoAgendamentoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FormEscolhaServico)
                {
                    if (form.IsDisposed) // <- se foi fechado
                    {
                        break; // sai do loop e vai criar novo
                    }

                    form.Activate();
                    return;
                }
            }

            // Se não achou ou estava fechado, cria novo:
            FormEscolhaServico novoForm = new FormEscolhaServico();
            novoForm.MdiParent = this;
            novoForm.Show();
        }

        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FormFiltrarClientes)
                {
                    form.Activate();
                    return;
                }
            }

            FormFiltrarClientes formFiltrar = new FormFiltrarClientes();
            formFiltrar.MdiParent = this;
            formFiltrar.Show();
        }

        private void novaFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is CadastroFicha)
                {
                    form.Activate();
                    return;
                }
            }

            CadastroFicha cadastroFicha = new CadastroFicha();
            cadastroFicha.MdiParent = this;
            cadastroFicha.Show();
        }

        private void visualizarAgendamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FormVerAgendamentos)
                {
                    form.Activate();
                    return;
                }
            }

            FormVerAgendamentos formVerAgendamentos = new FormVerAgendamentos();
            formVerAgendamentos.MdiParent = this;
            formVerAgendamentos.Show();

        }

        private void alterarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FormListaClientes)
                {
                    form.Activate();
                    return;
                }
            }

            FormListaClientes formLista = new FormListaClientes();
            formLista.MdiParent = this;
            formLista.Show();
        }
    }
}
