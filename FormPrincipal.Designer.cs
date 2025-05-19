namespace SistemaDeAgendementos
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            agendamentosToolStripMenuItem = new ToolStripMenuItem();
            novoAgendamentoToolStripMenuItem = new ToolStripMenuItem();
            visualizarAgendamentosToolStripMenuItem = new ToolStripMenuItem();
            alterarAgendamentoToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            cadastrarClientesToolStripMenuItem = new ToolStripMenuItem();
            visualizarClientesToolStripMenuItem = new ToolStripMenuItem();
            alterarClienteToolStripMenuItem = new ToolStripMenuItem();
            fichasToolStripMenuItem = new ToolStripMenuItem();
            novaFichaToolStripMenuItem = new ToolStripMenuItem();
            visualizarFichasToolStripMenuItem = new ToolStripMenuItem();
            cadastroProdutosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { agendamentosToolStripMenuItem, clientesToolStripMenuItem, fichasToolStripMenuItem, cadastroProdutosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // agendamentosToolStripMenuItem
            // 
            agendamentosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoAgendamentoToolStripMenuItem, visualizarAgendamentosToolStripMenuItem, alterarAgendamentoToolStripMenuItem });
            agendamentosToolStripMenuItem.Name = "agendamentosToolStripMenuItem";
            agendamentosToolStripMenuItem.Size = new Size(100, 20);
            agendamentosToolStripMenuItem.Text = "Agendamentos";
            // 
            // novoAgendamentoToolStripMenuItem
            // 
            novoAgendamentoToolStripMenuItem.Name = "novoAgendamentoToolStripMenuItem";
            novoAgendamentoToolStripMenuItem.Size = new Size(207, 22);
            novoAgendamentoToolStripMenuItem.Text = "Novo Agendamento";
            novoAgendamentoToolStripMenuItem.Click += novoAgendamentoToolStripMenuItem_Click_1;
            // 
            // visualizarAgendamentosToolStripMenuItem
            // 
            visualizarAgendamentosToolStripMenuItem.Name = "visualizarAgendamentosToolStripMenuItem";
            visualizarAgendamentosToolStripMenuItem.Size = new Size(207, 22);
            visualizarAgendamentosToolStripMenuItem.Text = "Visualizar Agendamentos";
            visualizarAgendamentosToolStripMenuItem.Click += visualizarAgendamentosToolStripMenuItem_Click;
            // 
            // alterarAgendamentoToolStripMenuItem
            // 
            alterarAgendamentoToolStripMenuItem.Name = "alterarAgendamentoToolStripMenuItem";
            alterarAgendamentoToolStripMenuItem.Size = new Size(207, 22);
            alterarAgendamentoToolStripMenuItem.Text = "Alterar Agendamento";
            alterarAgendamentoToolStripMenuItem.Click += alterarAgendamentoToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarClientesToolStripMenuItem, visualizarClientesToolStripMenuItem, alterarClienteToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // cadastrarClientesToolStripMenuItem
            // 
            cadastrarClientesToolStripMenuItem.Name = "cadastrarClientesToolStripMenuItem";
            cadastrarClientesToolStripMenuItem.Size = new Size(169, 22);
            cadastrarClientesToolStripMenuItem.Text = "Cadastrar Clientes";
            cadastrarClientesToolStripMenuItem.Click += cadastrarClientesToolStripMenuItem_Click_1;
            // 
            // visualizarClientesToolStripMenuItem
            // 
            visualizarClientesToolStripMenuItem.Name = "visualizarClientesToolStripMenuItem";
            visualizarClientesToolStripMenuItem.Size = new Size(169, 22);
            visualizarClientesToolStripMenuItem.Text = "Visualizar Clientes";
            visualizarClientesToolStripMenuItem.Click += visualizarClientesToolStripMenuItem_Click;
            // 
            // alterarClienteToolStripMenuItem
            // 
            alterarClienteToolStripMenuItem.Name = "alterarClienteToolStripMenuItem";
            alterarClienteToolStripMenuItem.Size = new Size(169, 22);
            alterarClienteToolStripMenuItem.Text = "Alterar Cliente";
            alterarClienteToolStripMenuItem.Click += alterarClienteToolStripMenuItem_Click;
            // 
            // fichasToolStripMenuItem
            // 
            fichasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novaFichaToolStripMenuItem, visualizarFichasToolStripMenuItem });
            fichasToolStripMenuItem.Name = "fichasToolStripMenuItem";
            fichasToolStripMenuItem.Size = new Size(52, 20);
            fichasToolStripMenuItem.Text = "Fichas";
            // 
            // novaFichaToolStripMenuItem
            // 
            novaFichaToolStripMenuItem.Name = "novaFichaToolStripMenuItem";
            novaFichaToolStripMenuItem.Size = new Size(159, 22);
            novaFichaToolStripMenuItem.Text = "Nova Ficha";
            novaFichaToolStripMenuItem.Click += novaFichaToolStripMenuItem_Click;
            // 
            // visualizarFichasToolStripMenuItem
            // 
            visualizarFichasToolStripMenuItem.Name = "visualizarFichasToolStripMenuItem";
            visualizarFichasToolStripMenuItem.Size = new Size(159, 22);
            visualizarFichasToolStripMenuItem.Text = "Visualizar Fichas";
            // 
            // cadastroProdutosToolStripMenuItem
            // 
            cadastroProdutosToolStripMenuItem.Name = "cadastroProdutosToolStripMenuItem";
            cadastroProdutosToolStripMenuItem.Size = new Size(117, 20);
            cadastroProdutosToolStripMenuItem.Text = "Cadastro Produtos";
            cadastroProdutosToolStripMenuItem.Click += cadastroProdutosToolStripMenuItem_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            Load += FormPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem agendamentosToolStripMenuItem;
        private ToolStripMenuItem novoAgendamentoToolStripMenuItem;
        private ToolStripMenuItem visualizarAgendamentosToolStripMenuItem;
        private ToolStripMenuItem alterarAgendamentoToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem cadastrarClientesToolStripMenuItem;
        private ToolStripMenuItem visualizarClientesToolStripMenuItem;
        private ToolStripMenuItem alterarClienteToolStripMenuItem;
        private ToolStripMenuItem fichasToolStripMenuItem;
        private ToolStripMenuItem novaFichaToolStripMenuItem;
        private ToolStripMenuItem visualizarFichasToolStripMenuItem;
        private ToolStripMenuItem cadastroProdutosToolStripMenuItem;
    }
}