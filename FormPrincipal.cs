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
                if (form is Cadastro_Pasciente___ShivaAnanda.Form1)
                {
                    form.Activate();
                    return;
                }
            }

            Cadastro_Pasciente___ShivaAnanda.Form1 formCadastroClientes = new Cadastro_Pasciente___ShivaAnanda.Form1();
            formCadastroClientes.MdiParent = this;
            formCadastroClientes.Show();
        }

        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is Shiva_Ananda___H.Shiva)
                {
                    form.Activate();
                    return;
                }
            }

            Shiva_Ananda___H.Shiva shiva = new Shiva_Ananda___H.Shiva();
            shiva.MdiParent = this;
            shiva.Show();
        }

        private void novaFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is TelaFicha.Form1)
                {
                    form.Activate();
                    return;
                }
            }

            TelaFicha.Form1 form1 = new TelaFicha.Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
