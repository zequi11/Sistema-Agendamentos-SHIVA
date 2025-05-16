namespace SistemaDeAgendementos
{
    partial class FormFiltrarClientes
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
            dataGridClientes = new DataGridView();
            btnLimpar = new Button();
            btnFiltrarNome = new Button();
            txtcpf = new TextBox();
            txtNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnFiltrarCPF = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridClientes
            // 
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(169, 202);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.Size = new Size(462, 278);
            dataGridClientes.TabIndex = 10;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(361, 114);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(77, 37);
            btnLimpar.TabIndex = 8;
            btnLimpar.Text = "&Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnFiltrarNome
            // 
            btnFiltrarNome.Location = new Point(234, 114);
            btnFiltrarNome.Name = "btnFiltrarNome";
            btnFiltrarNome.Size = new Size(86, 36);
            btnFiltrarNome.TabIndex = 7;
            btnFiltrarNome.Text = "Filtrar Nome";
            btnFiltrarNome.UseVisualStyleBackColor = true;
            btnFiltrarNome.Click += btnFiltrarNome_Click_1;
            // 
            // txtcpf
            // 
            txtcpf.Location = new Point(420, 56);
            txtcpf.Name = "txtcpf";
            txtcpf.Size = new Size(211, 23);
            txtcpf.TabIndex = 9;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(169, 56);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(211, 23);
            txtNome.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(483, 29);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 16;
            label1.Text = "Filtrar Por CPF:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 29);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 17;
            label2.Text = "Filtrar Por Nome:";
            // 
            // btnFiltrarCPF
            // 
            btnFiltrarCPF.Location = new Point(483, 114);
            btnFiltrarCPF.Name = "btnFiltrarCPF";
            btnFiltrarCPF.Size = new Size(77, 36);
            btnFiltrarCPF.TabIndex = 18;
            btnFiltrarCPF.Text = "Filtrar CPF";
            btnFiltrarCPF.UseVisualStyleBackColor = true;
            btnFiltrarCPF.Click += btnFiltrarCPF_Click;
            // 
            // FormFiltrarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(btnFiltrarCPF);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(dataGridClientes);
            Controls.Add(txtcpf);
            Controls.Add(btnLimpar);
            Controls.Add(btnFiltrarNome);
            Name = "FormFiltrarClientes";
            Text = "Procurar Clientes";
            Load += FormFiltrarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridClientes;
        private Button btnLimpar;
        private Button btnFiltrarNome;
        private TextBox txtcpf;
        private TextBox txtNome;
        private Label label1;
        private Label label2;
        private Button btnFiltrarCPF;
    }
}