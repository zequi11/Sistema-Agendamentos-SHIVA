namespace SistemaDeAgendementos
{
    partial class FormSelecionarAgendamento
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
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            btnProsseguir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridConsultas).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridConsultas
            // 
            dataGridConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridConsultas.Location = new Point(442, 62);
            dataGridConsultas.Name = "dataGridConsultas";
            dataGridConsultas.Size = new Size(341, 327);
            dataGridConsultas.TabIndex = 10;
            // 
            // dtpDataSelecionada
            // 
            dtpDataSelecionada.Font = new Font("Segoe UI", 9F);
            dtpDataSelecionada.Location = new Point(6, 30);
            dtpDataSelecionada.Name = "dtpDataSelecionada";
            dtpDataSelecionada.Size = new Size(230, 23);
            dtpDataSelecionada.TabIndex = 2;
            // 
            // btnFiltrarData
            // 
            btnFiltrarData.Font = new Font("Segoe UI", 9F);
            btnFiltrarData.Location = new Point(242, 26);
            btnFiltrarData.Name = "btnFiltrarData";
            btnFiltrarData.Size = new Size(95, 35);
            btnFiltrarData.TabIndex = 3;
            btnFiltrarData.Text = "Filtrar Data";
            btnFiltrarData.UseVisualStyleBackColor = true;
            btnFiltrarData.Click += btnFiltrarData_Click_1;
            // 
            // btnFiltrarSemana
            // 
            btnFiltrarSemana.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFiltrarSemana.Location = new Point(242, 26);
            btnFiltrarSemana.Name = "btnFiltrarSemana";
            btnFiltrarSemana.Size = new Size(95, 35);
            btnFiltrarSemana.TabIndex = 1;
            btnFiltrarSemana.Text = "Ver Semana";
            btnFiltrarSemana.UseVisualStyleBackColor = true;
            btnFiltrarSemana.Click += btnFiltrarSemana_Click_1;
            // 
            // btnFiltrarNome
            // 
            btnFiltrarNome.Font = new Font("Segoe UI", 9F);
            btnFiltrarNome.Location = new Point(242, 19);
            btnFiltrarNome.Name = "btnFiltrarNome";
            btnFiltrarNome.Size = new Size(95, 35);
            btnFiltrarNome.TabIndex = 5;
            btnFiltrarNome.Text = "Filtrar Nome";
            btnFiltrarNome.UseVisualStyleBackColor = true;
            btnFiltrarNome.Click += btnFiltrarNome_Click_1;
            // 
            // btnLimparFiltros
            // 
            btnLimparFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimparFiltros.Location = new Point(23, 354);
            btnLimparFiltros.Name = "btnLimparFiltros";
            btnLimparFiltros.Size = new Size(95, 35);
            btnLimparFiltros.TabIndex = 9;
            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.UseVisualStyleBackColor = true;
            btnLimparFiltros.Click += btnLimparFiltros_Click_1;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Font = new Font("Segoe UI", 9F);
            txtNomeCliente.Location = new Point(6, 26);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.PlaceholderText = "Digite o nome do cliente aqui...";
            txtNomeCliente.Size = new Size(230, 23);
            txtNomeCliente.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNomeCliente);
            groupBox2.Controls.Add(btnFiltrarNome);
            groupBox2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            groupBox2.Location = new Point(17, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(343, 72);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrar por Cliente";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpDataSelecionada);
            groupBox1.Controls.Add(btnFiltrarData);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            groupBox1.Location = new Point(17, 162);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(343, 73);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar por Dia";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Controls.Add(btnFiltrarSemana);
            groupBox3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(17, 62);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(343, 73);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agendamentos da Semana";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 9F);
            dateTimePicker1.Location = new Point(6, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(230, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // btnProsseguir
            // 
            btnProsseguir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProsseguir.Location = new Point(265, 354);
            btnProsseguir.Name = "btnProsseguir";
            btnProsseguir.Size = new Size(95, 35);
            btnProsseguir.TabIndex = 14;
            btnProsseguir.Text = "Prosseguir";
            btnProsseguir.UseVisualStyleBackColor = true;
            btnProsseguir.Click += button1_Click;
            // 
            // FormSelecionarAgendamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProsseguir);
            Controls.Add(dataGridConsultas);
            Controls.Add(btnLimparFiltros);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Name = "FormSelecionarAgendamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selecionar Agendamento";
            Load += FormSelecionarAgendamento_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridConsultas).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridConsultas;
        private DateTimePicker dtpDataSelecionada;
        private Button btnFiltrarData;
        private Button btnFiltrarSemana;
        private Button btnFiltrarNome;
        private Button btnLimparFiltros;
        private TextBox txtNomeCliente;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePicker1;
        private Button btnProsseguir;
    }
}