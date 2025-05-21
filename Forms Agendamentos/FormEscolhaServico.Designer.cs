namespace SistemaDeAgendementos
{
    partial class FormEscolhaServico
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
            txtDescricaoConsulta = new TextBox();
            cmbTipoConsulta = new ComboBox();
            groupBox3 = new GroupBox();
            label6 = new Label();
            groupBox2 = new GroupBox();
            label3 = new Label();
            dtpDia = new DateTimePicker();
            dtpHora = new DateTimePicker();
            label5 = new Label();
            groupBox1 = new GroupBox();
            cmb1 = new ComboBox();
            label1 = new Label();
            cmb2 = new ComboBox();
            label2 = new Label();
            cmb3 = new ComboBox();
            label4 = new Label();
            btnLimparOpcao = new Button();
            btnProsseguir = new Button();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDescricaoConsulta
            // 
            txtDescricaoConsulta.Font = new Font("Segoe UI", 9F);
            txtDescricaoConsulta.Location = new Point(15, 141);
            txtDescricaoConsulta.Multiline = true;
            txtDescricaoConsulta.Name = "txtDescricaoConsulta";
            txtDescricaoConsulta.PlaceholderText = "Adicione aqui uma breve descrição ...";
            txtDescricaoConsulta.Size = new Size(241, 158);
            txtDescricaoConsulta.TabIndex = 23;
            // 
            // cmbTipoConsulta
            // 
            cmbTipoConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoConsulta.Font = new Font("Segoe UI", 10F);
            cmbTipoConsulta.FormattingEnabled = true;
            cmbTipoConsulta.Items.AddRange(new object[] { "Avulsa", "Retorno", "Promocional", "Cortesia", "Reagendamento" });
            cmbTipoConsulta.Location = new Point(15, 67);
            cmbTipoConsulta.Name = "cmbTipoConsulta";
            cmbTipoConsulta.Size = new Size(241, 25);
            cmbTipoConsulta.TabIndex = 21;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtDescricaoConsulta);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cmbTipoConsulta);
            groupBox3.Font = new Font("Segoe UI", 11F);
            groupBox3.Location = new Point(651, 28);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(273, 318);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Adicionar Descrição";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(85, 37);
            label6.Name = "label6";
            label6.Size = new Size(101, 19);
            label6.TabIndex = 22;
            label6.Text = "Selecionar tipo:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtpDia);
            groupBox2.Controls.Add(dtpHora);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 11F);
            groupBox2.Location = new Point(353, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(292, 318);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Selecionar Horário";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(98, 37);
            label3.Name = "label3";
            label3.Size = new Size(106, 19);
            label3.TabIndex = 16;
            label3.Text = "Selecionar Data:";
            // 
            // dtpDia
            // 
            dtpDia.Font = new Font("Segoe UI", 9F);
            dtpDia.Location = new Point(25, 67);
            dtpDia.Name = "dtpDia";
            dtpDia.Size = new Size(240, 23);
            dtpDia.TabIndex = 4;
            // 
            // dtpHora
            // 
            dtpHora.Font = new Font("Segoe UI", 10F);
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(25, 141);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(240, 25);
            dtpHora.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(81, 110);
            label5.Name = "label5";
            label5.Size = new Size(123, 19);
            label5.TabIndex = 17;
            label5.Text = "Selecionar Horário:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmb1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmb2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmb3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnLimparOpcao);
            groupBox1.Font = new Font("Segoe UI", 11F);
            groupBox1.Location = new Point(55, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 318);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecionar Terapia";
            // 
            // cmb1
            // 
            cmb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb1.Font = new Font("Segoe UI", 10F);
            cmb1.FormattingEnabled = true;
            cmb1.Items.AddRange(new object[] { "Massagem Ayurvédica", "Massagem com Bambus", "Drenagem Linfática" });
            cmb1.Location = new Point(42, 67);
            cmb1.Name = "cmb1";
            cmb1.Size = new Size(200, 25);
            cmb1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(80, 34);
            label1.Name = "label1";
            label1.Size = new Size(131, 19);
            label1.TabIndex = 5;
            label1.Text = "Massagem Oriental:";
            // 
            // cmb2
            // 
            cmb2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb2.Font = new Font("Segoe UI", 10F);
            cmb2.FormattingEnabled = true;
            cmb2.Items.AddRange(new object[] { "Massagem Relaxante", "Massagem com Aromaterapia", "Massagem com Pedras Quentes" });
            cmb2.Location = new Point(42, 141);
            cmb2.Name = "cmb2";
            cmb2.Size = new Size(200, 25);
            cmb2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(80, 112);
            label2.Name = "label2";
            label2.Size = new Size(140, 19);
            label2.TabIndex = 6;
            label2.Text = "Massagem Relaxante:";
            // 
            // cmb3
            // 
            cmb3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb3.Font = new Font("Segoe UI", 10F);
            cmb3.FormattingEnabled = true;
            cmb3.Items.AddRange(new object[] { "Massagem Desportiva", "Reflexologia Podal", "Shiatsu" });
            cmb3.Location = new Point(42, 216);
            cmb3.Name = "cmb3";
            cmb3.Size = new Size(200, 25);
            cmb3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(69, 185);
            label4.Name = "label4";
            label4.Size = new Size(151, 19);
            label4.TabIndex = 8;
            label4.Text = "Massagem Terapêutica:";
            // 
            // btnLimparOpcao
            // 
            btnLimparOpcao.Font = new Font("Segoe UI", 9F);
            btnLimparOpcao.Location = new Point(90, 265);
            btnLimparOpcao.Name = "btnLimparOpcao";
            btnLimparOpcao.Size = new Size(97, 34);
            btnLimparOpcao.TabIndex = 3;
            btnLimparOpcao.Text = "Limpar Opção";
            btnLimparOpcao.UseVisualStyleBackColor = true;
            btnLimparOpcao.Click += btnLimparOpcao_Click;
            // 
            // btnProsseguir
            // 
            btnProsseguir.Location = new Point(837, 376);
            btnProsseguir.Name = "btnProsseguir";
            btnProsseguir.Size = new Size(87, 46);
            btnProsseguir.TabIndex = 21;
            btnProsseguir.Text = "Prosseguir";
            btnProsseguir.UseVisualStyleBackColor = true;
            btnProsseguir.Click += btnProsseguir_Click_1;
            // 
            // FormEscolhaServico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnProsseguir);
            Name = "FormEscolhaServico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Escolher Terapia";
            Load += FormEscolhaServico_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDescricaoConsulta;
        private ComboBox cmbTipoConsulta;
        private GroupBox groupBox3;
        private Label label6;
        private GroupBox groupBox2;
        private Label label3;
        private DateTimePicker dtpDia;
        private DateTimePicker dtpHora;
        private Label label5;
        private GroupBox groupBox1;
        private ComboBox cmb1;
        private Label label1;
        private ComboBox cmb2;
        private Label label2;
        private ComboBox cmb3;
        private Label label4;
        private Button btnLimparOpcao;
        private Button btnProsseguir;
    }
}