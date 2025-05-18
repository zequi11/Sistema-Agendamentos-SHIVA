using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeAgendementos
{
    public partial class FormEditarClientes : Form
    {
        string cpfCliente;

        public FormEditarClientes(string cpf)
        {
            InitializeComponent();
            cpfCliente = cpf;
            CarregarListas();
            CarregarDadosCliente();
        }

        private void CarregarListas()
        {
            string[] estados = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            cmbEstadoCliente.Items.AddRange(estados);

            string[] estadosCivis = { "Solteiro(a)", "Casado(a)", "Divorciado(a)", "Separado(a) Juridicamente", "Viúvo(a)" };
            cmbEstadoCivil.Items.AddRange(estadosCivis);
        }

        private void CarregarDadosCliente()
        {
            txtCpfClinte.ReadOnly = true;
            txtCpfClinte.BackColor = SystemColors.Control;
            txtCpfClinte.TabStop = false;

            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = "SELECT * FROM Cliente WHERE cpf_cliente = @cpf";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpfCliente);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNomeCliente.Text = reader["nome_cliente"].ToString();
                        dttmCliente.Value = Convert.ToDateTime(reader["nascimento_cliente"]);
                        txtRgCliente.Text = reader["rg_cliente"].ToString();
                        txtCpfClinte.Text = reader["cpf_cliente"].ToString();
                        txtEndereco.Text = reader["logradouro_cliente"].ToString();
                        txtNumeroEndereco.Text = reader["numero_cliente"].ToString();
                        txtComplementoCasa.Text = reader["complemento_cliente"].ToString();
                        txtCepCliente.Text = reader["cep_cliente"].ToString();
                        txtBairroCliente.Text = reader["bairro_cliente"].ToString();
                        txtCidadeCliente.Text = reader["cidade_cliente"].ToString();
                        cmbEstadoCliente.Text = reader["uf_cliente"].ToString();
                        cmbEstadoCivil.Text = reader["estadoCivil_cliente"].ToString();
                        txtNmroCelular1.Text = reader["contato1_cliente"].ToString();
                        txtNmroCelular2.Text = reader["contato2_cliente"].ToString();
                        txtNmroTelefone1.Text = reader["contatoEmergencia_cliente"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }

                }
            }
        }

        private bool ValidarCamposObrigatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text) ||
                string.IsNullOrWhiteSpace(txtRgCliente.Text) ||
                string.IsNullOrWhiteSpace(txtCpfClinte.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtCepCliente.Text) ||
                string.IsNullOrWhiteSpace(txtBairroCliente.Text) ||
                string.IsNullOrWhiteSpace(txtCidadeCliente.Text) ||
                cmbEstadoCliente.SelectedIndex == -1 ||
                cmbEstadoCivil.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNmroCelular1.Text) ||
                string.IsNullOrWhiteSpace(txtContatoEmail.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtCpfClinte.Text, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            {
                MessageBox.Show("CPF inválido. Use o formato 000.000.000-00.", "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtCepCliente.Text, @"^\d{5}-\d{3}$"))
            {
                MessageBox.Show("CEP inválido. Use o formato 00000-000.", "CEP inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtContatoEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido.", "E-mail inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dttmCliente.Value.Date > DateTime.Today)
            {
                MessageBox.Show("A data de nascimento não pode ser no futuro.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSalvarAlteracoes_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios()) return;

            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = @"
                    UPDATE Cliente SET 
                        nome_cliente = @nome,
                        nascimento_cliente = @nasc,
                        rg_cliente = @rg,
                        logradouro_cliente = @endereco,
                        numero_cliente = @numero,
                        complemento_cliente = @complemento,
                        bairro_cliente = @bairro,
                        cep_cliente = @cep,
                        cidade_cliente = @cidade,
                        uf_cliente = @uf,
                        estadoCivil_cliente = @estadoCivil,
                        contato1_cliente = @contato1,
                        contato2_cliente = @contato2,
                        contatoEmergencia_cliente = @contatoEmergencia
                    WHERE cpf_cliente = @cpf";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", txtNomeCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@nasc", dttmCliente.Value.Date);
                    cmd.Parameters.AddWithValue("@rg", txtRgCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.Trim());
                    cmd.Parameters.AddWithValue("@numero", txtNumeroEndereco.Text.Trim());
                    cmd.Parameters.AddWithValue("@complemento", string.IsNullOrWhiteSpace(txtComplementoCasa.Text) ? DBNull.Value : txtComplementoCasa.Text.Trim());
                    cmd.Parameters.AddWithValue("@bairro", txtBairroCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@cep", txtCepCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@cidade", txtCidadeCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@uf", cmbEstadoCliente.Text);
                    cmd.Parameters.AddWithValue("@estadoCivil", cmbEstadoCivil.Text);
                    cmd.Parameters.AddWithValue("@contato1", txtNmroCelular1.Text.Trim());
                    cmd.Parameters.AddWithValue("@contato2", string.IsNullOrWhiteSpace(txtNmroCelular2.Text) ? DBNull.Value : txtNmroCelular2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contatoEmergencia", txtNmroTelefone1.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpf", cpfCliente);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            txtRgCliente.Clear();
            txtCpfClinte.Clear();
            txtEndereco.Clear();
            txtNumeroEndereco.Clear();
            txtComplementoCasa.Clear();
            txtCepCliente.Clear();
            txtBairroCliente.Clear();
            txtCidadeCliente.Clear();
            cmbEstadoCliente.SelectedIndex = -1;
            cmbEstadoCivil.SelectedIndex = -1;
            txtNmroCelular1.Clear();
            txtNmroCelular2.Clear();
            txtNmroTelefone1.Clear();
            txtNmroTelefone2.Clear();
            txtContatoEmail.Clear();
            dttmCliente.Value = DateTime.Today;
            txtNomeCliente.Focus();
        }
    }
}
