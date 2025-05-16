namespace SistemaDeAgendementos
{
    partial class FormProcurarCliente
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
            btnVoltar = new Button();
            button1 = new Button();
            btnBuscarNome = new Button();
            listBox1 = new ListBox();
            label3 = new Label();
            txtCpf = new MaskedTextBox();
            label1 = new Label();
            btnBuscarCpf = new Button();
            txtNome = new TextBox();
            SuspendLayout();
            // 
            // btnVoltar
            // 
            btnVoltar.Font = new Font("Segoe UI", 11F);
            btnVoltar.Location = new Point(12, 285);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(99, 35);
            btnVoltar.TabIndex = 16;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(12, 326);
            button1.Name = "button1";
            button1.Size = new Size(99, 35);
            button1.TabIndex = 14;
            button1.Text = "Prosseguir";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnBuscarNome
            // 
            btnBuscarNome.Location = new Point(117, 222);
            btnBuscarNome.Name = "btnBuscarNome";
            btnBuscarNome.Size = new Size(75, 23);
            btnBuscarNome.TabIndex = 11;
            btnBuscarNome.Text = "Buscar";
            btnBuscarNome.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(274, 117);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(323, 244);
            listBox1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(34, 199);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 15;
            label3.Text = "Nome:";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(11, 140);
            txtCpf.Mask = "000,000,000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(45, 117);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 9;
            label1.Text = "CPF";
            // 
            // btnBuscarCpf
            // 
            btnBuscarCpf.Location = new Point(117, 140);
            btnBuscarCpf.Name = "btnBuscarCpf";
            btnBuscarCpf.Size = new Size(75, 23);
            btnBuscarCpf.TabIndex = 8;
            btnBuscarCpf.Text = "Buscar";
            btnBuscarCpf.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(11, 222);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 10;
            // 
            // FormProcurarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 389);
            Controls.Add(btnVoltar);
            Controls.Add(button1);
            Controls.Add(btnBuscarNome);
            Controls.Add(listBox1);
            Controls.Add(label3);
            Controls.Add(txtCpf);
            Controls.Add(label1);
            Controls.Add(btnBuscarCpf);
            Controls.Add(txtNome);
            Name = "FormProcurarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Escolher Cliente";
            Load += FormProcurarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVoltar;
        private Button button1;
        private Button btnBuscarNome;
        private ListBox listBox1;
        private Label label3;
        private MaskedTextBox txtCpf;
        private Label label1;
        private Button btnBuscarCpf;
        private TextBox txtNome;
    }
}