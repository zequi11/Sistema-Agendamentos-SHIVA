using System;
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
            AbrirOuAtivar<FormEscolhaServico>();
        }

        private void cadastrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormFiltrarClientes>();
        }

        private void cadastroProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mantido igual, pois não é MDI child
            CadastroProdutos cadastroProdutos = new CadastroProdutos();
            cadastroProdutos.Show();
            this.Hide();
        }

        private void cadastrarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirOuAtivar<CadastroCliente>();
        }

        private void novoAgendamentoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormEscolhaServico>();
        }

        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormFiltrarClientes>();
        }

        private void novaFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<CadastroFicha>();
        }

        private void visualizarAgendamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormVerAgendamentos>();
        }

        private void alterarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormListaClientes>();
        }

        private void alterarAgendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirOuAtivar<FormSelecionarAgendamento>();
        }

        private void AbrirOuAtivar<T>() where T : Form, new()
        {
            Form formAberto = null;

            foreach (Form form in this.MdiChildren)
            {
                if (form is T formulario && !formulario.IsDisposed && formulario.Visible)
                {
                    formAberto = formulario;
                    break;
                }
            }

            if (formAberto != null)
            {
                formAberto.Activate();
            }
            else
            {
                T novoForm = new T();
                novoForm.MdiParent = this;
                novoForm.Show();
            }
        }
    }
}
