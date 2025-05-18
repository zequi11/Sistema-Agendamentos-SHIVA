namespace SistemaDeAgendementos
{
    partial class FormVerAgendamentos
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
            dataGridConsultas = new DataGridView();
            dtpDataSelecionada = new DateTimePicker();
            btnFiltrarData = new Button();
            btnFiltrarSemana = new Button();
            btnFiltrarNome = new Button();
            btnLimparFiltros = new Button();
            txtNomeCliente = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridConsultas).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridConsultas
            // 
            dataGridConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridConsultas.Location = new Point(447, 58);
            dataGridConsultas.Name = "dataGridConsultas";
            dataGridConsultas.Size = new Size(341, 327);
            dataGridConsultas.TabIndex = 0;
            // 
            // dtpDataSelecionada
            // 
            dtpDataSelecionada.Font = new Font("Segoe UI", 9F);
            dtpDataSelecionada.Location = new Point(6, 30);
            dtpDataSelecionada.Name = "dtpDataSelecionada";
            dtpDataSelecionada.Size = new Size(230, 23);
            dtpDataSelecionada.TabIndex = 1;
            // 
            // btnFiltrarData
            // 
            btnFiltrarData.Font = new Font("Segoe UI", 9F);
            btnFiltrarData.Location = new Point(242, 22);
            btnFiltrarData.Name = "btnFiltrarData";
            btnFiltrarData.Size = new Size(95, 35);
            btnFiltrarData.TabIndex = 2;
            btnFiltrarData.Text = "Filtrar Data";
            btnFiltrarData.UseVisualStyleBackColor = true;
            btnFiltrarData.Click += btnFiltrarData_Click;
            // 
            // btnFiltrarSemana
            // 
            btnFiltrarSemana.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrarSemana.Location = new Point(235, 58);
            btnFiltrarSemana.Name = "btnFiltrarSemana";
            btnFiltrarSemana.Size = new Size(96, 43);
            btnFiltrarSemana.TabIndex = 3;
            btnFiltrarSemana.Text = "Ver Agendamentos";
            btnFiltrarSemana.UseVisualStyleBackColor = true;
            btnFiltrarSemana.Click += btnFiltrarSemana_Click;
            // 
            // btnFiltrarNome
            // 
            btnFiltrarNome.Font = new Font("Segoe UI", 9F);
            btnFiltrarNome.Location = new Point(242, 19);
            btnFiltrarNome.Name = "btnFiltrarNome";
            btnFiltrarNome.Size = new Size(95, 35);
            btnFiltrarNome.TabIndex = 4;
            btnFiltrarNome.Text = "Filtrar Nome";
            btnFiltrarNome.UseVisualStyleBackColor = true;
            btnFiltrarNome.Click += btnFiltrarNome_Click;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimparFiltros.Location = new Point(270, 350);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 5;
            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Font = new Font("Segoe UI", 9F);
            txtNomeCliente.Location = new Point(6, 26);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.PlaceholderText = "Digite o nome do cliente aqui...";
            txtNomeCliente.Size = new Size(230, 23);
            txtNomeCliente.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpDataSelecionada);
            groupBox1.Controls.Add(btnFiltrarData);
            groupBox1.Font = new Font("Segoe UI", 11F);
            groupBox1.Location = new Point(22, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(343, 73);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar Por Dia";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNomeCliente);
            groupBox2.Controls.Add(btnFiltrarNome);
            groupBox2.Font = new Font("Segoe UI", 11F);
            groupBox2.Location = new Point(22, 234);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(343, 72);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrar Por Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 64);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 9;
            label1.Text = "Agendamentos Da Semana:";
            // 
            // FormVerAgendamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnLimparFiltros);
            Controls.Add(btnFiltrarSemana);
            Controls.Add(dataGridConsultas);
            Name = "FormVerAgendamentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agendamentos";
            ((System.ComponentModel.ISupportInitialize)dataGridConsultas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridConsultas;
        private DateTimePicker dtpDataSelecionada;
        private Button btnFiltrarData;
        private Button btnFiltrarSemana;
        private Button btnFiltrarNome;
        private Button btnLimparFiltros;
        private TextBox txtNomeCliente;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
    }
}