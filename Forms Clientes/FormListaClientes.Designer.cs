namespace SistemaDeAgendementos
{
    partial class FormListaClientes
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
            btnFiltrarCPF = new Button();
            label2 = new Label();
            label1 = new Label();
            txtNome = new TextBox();
            dataGridClientes = new DataGridView();
            txtcpf = new TextBox();
            btnLimpar = new Button();
            btnFiltrarNome = new Button();
            btnProsseguir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            SuspendLayout();
            // 
            // btnFiltrarCPF
            // 
            btnFiltrarCPF.Location = new Point(483, 110);
            btnFiltrarCPF.Name = "btnFiltrarCPF";
            btnFiltrarCPF.Size = new Size(77, 36);
            btnFiltrarCPF.TabIndex = 26;
            btnFiltrarCPF.Text = "Filtrar CPF";
            btnFiltrarCPF.UseVisualStyleBackColor = true;
            btnFiltrarCPF.Click += btnFiltrarCPF_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 25);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 25;
            label2.Text = "Filtrar Por Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(483, 25);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 24;
            label1.Text = "Filtrar Por CPF:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(169, 52);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(211, 23);
            txtNome.TabIndex = 23;
            // 
            // dataGridClientes
            // 
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(169, 198);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.Size = new Size(462, 278);
            dataGridClientes.TabIndex = 22;
            // 
            // txtcpf
            // 
            txtcpf.Location = new Point(420, 52);
            txtcpf.Name = "txtcpf";
            txtcpf.Size = new Size(211, 23);
            txtcpf.TabIndex = 21;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(361, 110);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(77, 37);
            btnLimpar.TabIndex = 20;
            btnLimpar.Text = "&Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrarNome
            // 
            btnFiltrarNome.Location = new Point(234, 110);
            btnFiltrarNome.Name = "btnFiltrarNome";
            btnFiltrarNome.Size = new Size(86, 36);
            btnFiltrarNome.TabIndex = 19;
            btnFiltrarNome.Text = "Filtrar Nome";
            btnFiltrarNome.UseVisualStyleBackColor = true;
            btnFiltrarNome.Click += btnFiltrarNome_Click;
            // 
            // btnProsseguir
            // 
            btnProsseguir.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnProsseguir.Location = new Point(686, 439);
            btnProsseguir.Name = "btnProsseguir";
            btnProsseguir.Size = new Size(102, 37);
            btnProsseguir.TabIndex = 27;
            btnProsseguir.Text = "Prosseguir";
            btnProsseguir.UseVisualStyleBackColor = true;
            btnProsseguir.Click += btnProsseguir_Click;
            // 
            // FormListaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(btnProsseguir);
            Controls.Add(btnFiltrarCPF);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(dataGridClientes);
            Controls.Add(txtcpf);
            Controls.Add(btnLimpar);
            Controls.Add(btnFiltrarNome);
            Name = "FormListaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormListaClientes";
            Load += FormListaClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFiltrarCPF;
        private Label label2;
        private Label label1;
        private TextBox txtNome;
        private DataGridView dataGridClientes;
        private TextBox txtcpf;
        private Button btnLimpar;
        private Button btnFiltrarNome;
        private Button btnProsseguir;
    }
}