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
            txtcpf = new MaskedTextBox();
            label1 = new Label();
            dataGridClientes = new DataGridView();
            txtNome = new TextBox();
            btnLimpar = new Button();
            btnFiltrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).BeginInit();
            SuspendLayout();
            // 
            // txtcpf
            // 
            txtcpf.Location = new Point(354, 125);
            txtcpf.Mask = "000,000,000-00";
            txtcpf.Name = "txtcpf";
            txtcpf.Size = new Size(86, 23);
            txtcpf.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 20);
            label1.Name = "label1";
            label1.Size = new Size(161, 37);
            label1.TabIndex = 11;
            label1.Text = "HISTÓRICO\r\n";
            // 
            // dataGridClientes
            // 
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(169, 238);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.Size = new Size(462, 242);
            dataGridClientes.TabIndex = 10;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(229, 82);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(356, 23);
            txtNome.TabIndex = 9;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(405, 164);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(77, 68);
            btnLimpar.TabIndex = 8;
            btnLimpar.Text = "&Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(321, 164);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(77, 68);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "&Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // FormFiltrarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(txtcpf);
            Controls.Add(label1);
            Controls.Add(dataGridClientes);
            Controls.Add(txtNome);
            Controls.Add(btnLimpar);
            Controls.Add(btnFiltrar);
            Name = "FormFiltrarClientes";
            Text = "FormFiltrarClientes";
            Load += FormFiltrarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtcpf;
        private Label label1;
        private DataGridView dataGridClientes;
        private TextBox txtNome;
        private Button btnLimpar;
        private Button btnFiltrar;
    }
}