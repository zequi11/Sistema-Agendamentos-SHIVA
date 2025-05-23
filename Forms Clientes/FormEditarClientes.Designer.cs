﻿namespace SistemaDeAgendementos
{
    partial class FormEditarClientes
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
            txtCepCliente = new MaskedTextBox();
            label10 = new Label();
            label5 = new Label();
            label8 = new Label();
            txtRgCliente = new MaskedTextBox();
            txtContatoEmail = new MaskedTextBox();
            txtBairroCliente = new MaskedTextBox();
            label19 = new Label();
            label15 = new Label();
            label18 = new Label();
            label16 = new Label();
            label17 = new Label();
            txtCpfClinte = new MaskedTextBox();
            label1 = new Label();
            txtEndereco = new MaskedTextBox();
            gpbEnderecoCliente = new GroupBox();
            txtNumeroEndereco = new MaskedTextBox();
            label6 = new Label();
            label7 = new Label();
            label12 = new Label();
            cmbEstadoCliente = new ComboBox();
            txtComplementoCasa = new MaskedTextBox();
            label11 = new Label();
            label9 = new Label();
            txtCidadeCliente = new MaskedTextBox();
            btnLimpar = new Button();
            gpbDadosCliente = new GroupBox();
            label13 = new Label();
            cmbEstadoCivil = new ComboBox();
            txtNomeCliente = new MaskedTextBox();
            label2 = new Label();
            dttmCliente = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            btnSalvarAlteracoes = new Button();
            gpbContatoCliente = new GroupBox();
            txtContatoEmergenciaCel = new MaskedTextBox();
            txtCelular1 = new MaskedTextBox();
            txtContatoEmergenciaTel = new MaskedTextBox();
            txtTelefone1 = new MaskedTextBox();
            btnDeletarCliente = new Button();
            btnAtivarCliente = new Button();
            gpbEnderecoCliente.SuspendLayout();
            gpbDadosCliente.SuspendLayout();
            gpbContatoCliente.SuspendLayout();
            SuspendLayout();
            // 
            // txtCepCliente
            // 
            txtCepCliente.Location = new Point(73, 51);
            txtCepCliente.Mask = "00000-000";
            txtCepCliente.Name = "txtCepCliente";
            txtCepCliente.Size = new Size(100, 23);
            txtCepCliente.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(192, 54);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 17;
            label10.Text = "Bairro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(376, 59);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 8;
            label5.Text = "CPF";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(342, 25);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 13;
            label8.Text = "Complemento";
            // 
            // txtRgCliente
            // 
            txtRgCliente.Location = new Point(410, 27);
            txtRgCliente.Mask = "00,000,000-0";
            txtRgCliente.Name = "txtRgCliente";
            txtRgCliente.Size = new Size(100, 23);
            txtRgCliente.TabIndex = 3;
            // 
            // txtContatoEmail
            // 
            txtContatoEmail.Location = new Point(95, 96);
            txtContatoEmail.Name = "txtContatoEmail";
            txtContatoEmail.Size = new Size(343, 23);
            txtContatoEmail.TabIndex = 17;
            // 
            // txtBairroCliente
            // 
            txtBairroCliente.Location = new Point(236, 51);
            txtBairroCliente.Name = "txtBairroCliente";
            txtBairroCliente.Size = new Size(100, 23);
            txtBairroCliente.TabIndex = 10;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(47, 99);
            label19.Name = "label19";
            label19.Size = new Size(41, 15);
            label19.TabIndex = 34;
            label19.Text = "E-mail";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(36, 41);
            label15.Name = "label15";
            label15.Size = new Size(53, 15);
            label15.TabIndex = 23;
            label15.Text = "Celular 1";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(236, 70);
            label18.Name = "label18";
            label18.Size = new Size(61, 15);
            label18.TabIndex = 33;
            label18.Text = "Telefone 2";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(244, 46);
            label16.Name = "label16";
            label16.Size = new Size(53, 15);
            label16.TabIndex = 29;
            label16.Text = "Celular 2";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(28, 70);
            label17.Name = "label17";
            label17.Size = new Size(61, 15);
            label17.TabIndex = 30;
            label17.Text = "Telefone 1";
            // 
            // txtCpfClinte
            // 
            txtCpfClinte.Location = new Point(410, 56);
            txtCpfClinte.Mask = "000,000,000-00";
            txtCpfClinte.Name = "txtCpfClinte";
            txtCpfClinte.Size = new Size(100, 23);
            txtCpfClinte.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(302, 29);
            label1.Name = "label1";
            label1.Size = new Size(290, 32);
            label1.TabIndex = 53;
            label1.Text = "Editar Cadastro de Cliente";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(73, 22);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(100, 23);
            txtEndereco.TabIndex = 6;
            // 
            // gpbEnderecoCliente
            // 
            gpbEnderecoCliente.Controls.Add(txtEndereco);
            gpbEnderecoCliente.Controls.Add(txtNumeroEndereco);
            gpbEnderecoCliente.Controls.Add(label6);
            gpbEnderecoCliente.Controls.Add(label7);
            gpbEnderecoCliente.Controls.Add(label12);
            gpbEnderecoCliente.Controls.Add(label8);
            gpbEnderecoCliente.Controls.Add(cmbEstadoCliente);
            gpbEnderecoCliente.Controls.Add(txtComplementoCasa);
            gpbEnderecoCliente.Controls.Add(label11);
            gpbEnderecoCliente.Controls.Add(label9);
            gpbEnderecoCliente.Controls.Add(txtCidadeCliente);
            gpbEnderecoCliente.Controls.Add(txtCepCliente);
            gpbEnderecoCliente.Controls.Add(txtBairroCliente);
            gpbEnderecoCliente.Controls.Add(label10);
            gpbEnderecoCliente.Location = new Point(166, 255);
            gpbEnderecoCliente.Name = "gpbEnderecoCliente";
            gpbEnderecoCliente.Size = new Size(566, 126);
            gpbEnderecoCliente.TabIndex = 54;
            gpbEnderecoCliente.TabStop = false;
            gpbEnderecoCliente.Text = "Endereço do Cliente";
            // 
            // txtNumeroEndereco
            // 
            txtNumeroEndereco.Location = new Point(236, 22);
            txtNumeroEndereco.Name = "txtNumeroEndereco";
            txtNumeroEndereco.Size = new Size(100, 23);
            txtNumeroEndereco.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 25);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 11;
            label6.Text = "Endereço";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(179, 25);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 12;
            label7.Text = "Número";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 83);
            label12.Name = "label12";
            label12.Size = new Size(42, 15);
            label12.TabIndex = 22;
            label12.Text = "Estado";
            // 
            // cmbEstadoCliente
            // 
            cmbEstadoCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCliente.FormattingEnabled = true;
            cmbEstadoCliente.Location = new Point(73, 80);
            cmbEstadoCliente.Name = "cmbEstadoCliente";
            cmbEstadoCliente.Size = new Size(459, 23);
            cmbEstadoCliente.TabIndex = 12;
            // 
            // txtComplementoCasa
            // 
            txtComplementoCasa.Location = new Point(432, 22);
            txtComplementoCasa.Name = "txtComplementoCasa";
            txtComplementoCasa.Size = new Size(100, 23);
            txtComplementoCasa.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(382, 54);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 20;
            label11.Text = "Cidade";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(39, 54);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 15;
            label9.Text = "CEP";
            // 
            // txtCidadeCliente
            // 
            txtCidadeCliente.Location = new Point(432, 51);
            txtCidadeCliente.Name = "txtCidadeCliente";
            txtCidadeCliente.Size = new Size(100, 23);
            txtCidadeCliente.TabIndex = 11;
            // 
            // btnLimpar
            // 
            btnLimpar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpar.Location = new Point(452, 553);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(280, 49);
            btnLimpar.TabIndex = 52;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // gpbDadosCliente
            // 
            gpbDadosCliente.Controls.Add(label13);
            gpbDadosCliente.Controls.Add(cmbEstadoCivil);
            gpbDadosCliente.Controls.Add(txtNomeCliente);
            gpbDadosCliente.Controls.Add(label2);
            gpbDadosCliente.Controls.Add(dttmCliente);
            gpbDadosCliente.Controls.Add(label3);
            gpbDadosCliente.Controls.Add(label4);
            gpbDadosCliente.Controls.Add(txtRgCliente);
            gpbDadosCliente.Controls.Add(label5);
            gpbDadosCliente.Controls.Add(txtCpfClinte);
            gpbDadosCliente.Location = new Point(166, 98);
            gpbDadosCliente.Name = "gpbDadosCliente";
            gpbDadosCliente.Size = new Size(566, 151);
            gpbDadosCliente.TabIndex = 55;
            gpbDadosCliente.TabStop = false;
            gpbDadosCliente.Text = "Dados do Cliente";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(60, 88);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 26;
            label13.Text = "Estado Civil";
            // 
            // cmbEstadoCivil
            // 
            cmbEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCivil.FormattingEnabled = true;
            cmbEstadoCivil.Location = new Point(134, 85);
            cmbEstadoCivil.Name = "cmbEstadoCivil";
            cmbEstadoCivil.Size = new Size(376, 23);
            cmbEstadoCivil.TabIndex = 5;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(134, 27);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(236, 23);
            txtNomeCliente.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 30);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome Completo";
            // 
            // dttmCliente
            // 
            dttmCliente.Location = new Point(134, 56);
            dttmCliente.Name = "dttmCliente";
            dttmCliente.Size = new Size(236, 23);
            dttmCliente.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 56);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 3;
            label3.Text = "Data de Nascimento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 30);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 5;
            label4.Text = "RG";
            // 
            // btnSalvarAlteracoes
            // 
            btnSalvarAlteracoes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalvarAlteracoes.Location = new Point(166, 553);
            btnSalvarAlteracoes.Name = "btnSalvarAlteracoes";
            btnSalvarAlteracoes.Size = new Size(280, 49);
            btnSalvarAlteracoes.TabIndex = 51;
            btnSalvarAlteracoes.Text = "Salvar Edição";
            btnSalvarAlteracoes.UseVisualStyleBackColor = true;
            btnSalvarAlteracoes.Click += btnSalvarAlteracoes_Click_1;
            // 
            // gpbContatoCliente
            // 
            gpbContatoCliente.Controls.Add(txtContatoEmergenciaCel);
            gpbContatoCliente.Controls.Add(txtContatoEmail);
            gpbContatoCliente.Controls.Add(txtCelular1);
            gpbContatoCliente.Controls.Add(label19);
            gpbContatoCliente.Controls.Add(txtContatoEmergenciaTel);
            gpbContatoCliente.Controls.Add(txtTelefone1);
            gpbContatoCliente.Controls.Add(label15);
            gpbContatoCliente.Controls.Add(label18);
            gpbContatoCliente.Controls.Add(label16);
            gpbContatoCliente.Controls.Add(label17);
            gpbContatoCliente.Location = new Point(166, 387);
            gpbContatoCliente.Name = "gpbContatoCliente";
            gpbContatoCliente.Size = new Size(566, 160);
            gpbContatoCliente.TabIndex = 56;
            gpbContatoCliente.TabStop = false;
            gpbContatoCliente.Text = "Contatos do Cliente";
            // 
            // txtContatoEmergenciaCel
            // 
            txtContatoEmergenciaCel.Location = new Point(303, 38);
            txtContatoEmergenciaCel.Mask = "(99) 00000-0000";
            txtContatoEmergenciaCel.Name = "txtContatoEmergenciaCel";
            txtContatoEmergenciaCel.Size = new Size(135, 23);
            txtContatoEmergenciaCel.TabIndex = 59;
            // 
            // txtCelular1
            // 
            txtCelular1.Location = new Point(95, 38);
            txtCelular1.Mask = "(99) 00000-0000";
            txtCelular1.Name = "txtCelular1";
            txtCelular1.Size = new Size(135, 23);
            txtCelular1.TabIndex = 58;
            // 
            // txtContatoEmergenciaTel
            // 
            txtContatoEmergenciaTel.Location = new Point(303, 67);
            txtContatoEmergenciaTel.Mask = "(99) 00000-0000";
            txtContatoEmergenciaTel.Name = "txtContatoEmergenciaTel";
            txtContatoEmergenciaTel.Size = new Size(135, 23);
            txtContatoEmergenciaTel.TabIndex = 61;
            // 
            // txtTelefone1
            // 
            txtTelefone1.Location = new Point(95, 67);
            txtTelefone1.Mask = "(99) 00000-0000";
            txtTelefone1.Name = "txtTelefone1";
            txtTelefone1.Size = new Size(135, 23);
            txtTelefone1.TabIndex = 60;
            // 
            // btnDeletarCliente
            // 
            btnDeletarCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeletarCliente.ForeColor = Color.Red;
            btnDeletarCliente.Location = new Point(166, 608);
            btnDeletarCliente.Name = "btnDeletarCliente";
            btnDeletarCliente.Size = new Size(566, 49);
            btnDeletarCliente.TabIndex = 57;
            btnDeletarCliente.Text = "Desativar Cliente";
            btnDeletarCliente.UseVisualStyleBackColor = true;
            btnDeletarCliente.Click += btnDeletarCliente_Click;
            // 
            // btnAtivarCliente
            // 
            btnAtivarCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAtivarCliente.ForeColor = Color.Blue;
            btnAtivarCliente.Location = new Point(166, 663);
            btnAtivarCliente.Name = "btnAtivarCliente";
            btnAtivarCliente.Size = new Size(566, 49);
            btnAtivarCliente.TabIndex = 58;
            btnAtivarCliente.Text = "Ativar Cliente";
            btnAtivarCliente.UseVisualStyleBackColor = true;
            btnAtivarCliente.Click += btnAtivarCliente_Click_1;
            // 
            // FormEditarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 784);
            Controls.Add(btnAtivarCliente);
            Controls.Add(btnDeletarCliente);
            Controls.Add(label1);
            Controls.Add(gpbEnderecoCliente);
            Controls.Add(btnLimpar);
            Controls.Add(gpbDadosCliente);
            Controls.Add(btnSalvarAlteracoes);
            Controls.Add(gpbContatoCliente);
            Name = "FormEditarClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Cadastro de Cliente";
            Load += FormEditarClientes_Load;
            gpbEnderecoCliente.ResumeLayout(false);
            gpbEnderecoCliente.PerformLayout();
            gpbDadosCliente.ResumeLayout(false);
            gpbDadosCliente.PerformLayout();
            gpbContatoCliente.ResumeLayout(false);
            gpbContatoCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtCepCliente;
        private Label label10;
        private Label label5;
        private Label label8;
        private MaskedTextBox txtRgCliente;
        private MaskedTextBox txtContatoEmail;
        private MaskedTextBox txtBairroCliente;
        private Label label19;
        private Label label15;
        private Label label18;
        private Label label16;
        private Label label17;
        private MaskedTextBox txtCpfClinte;
        private Label label1;
        private MaskedTextBox txtEndereco;
        private GroupBox gpbEnderecoCliente;
        private MaskedTextBox txtNumeroEndereco;
        private Label label6;
        private Label label7;
        private Label label12;
        private ComboBox cmbEstadoCliente;
        private MaskedTextBox txtComplementoCasa;
        private Label label11;
        private Label label9;
        private MaskedTextBox txtCidadeCliente;
        private Button btnLimpar;
        private GroupBox gpbDadosCliente;
        private Label label13;
        private ComboBox cmbEstadoCivil;
        private MaskedTextBox txtNomeCliente;
        private Label label2;
        private DateTimePicker dttmCliente;
        private Label label3;
        private Label label4;
        private Button btnSalvarAlteracoes;
        private GroupBox gpbContatoCliente;
        private MaskedTextBox txtContatoEmergenciaCel;
        private MaskedTextBox txtCelular1;
        private MaskedTextBox txtContatoEmergenciaTel;
        private MaskedTextBox txtTelefone1;
        private Button btnDeletarCliente;
        private Button btnAtivarCliente;
    }
}