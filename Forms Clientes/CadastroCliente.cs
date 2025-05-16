using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeAgendementos
{
    public partial class CadastroCliente : Form
    {
        // Dados do cliente
        string nomeCliente;
        DateTime dataNascimento;
        string rgCliente;
        string cpfCliente;
        string estadoCivilCliente;

        // Endereço
        string enderecoCliente;
        string numeroEnderecoCliente;
        string compEnderecoCliente;
        string cepCliente;
        string bairroCliente;
        string cidadeCliente;
        string estadoCliente;

        // Contatos
        string contatoCelular1;
        string contatoCelular2;
        string contatoTelefone1;
        string contatoTelefone2;
        string contatoEmail;

        public CadastroCliente()
        {
            InitializeComponent();
            CarregarListas();
            txtNomeCliente.Focus();
        }

        private void CarregarListas()
        {
            string[] estados = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            cmbEstadoCliente.Items.AddRange(estados);

            string[] estadosCivis = { "Solteiro(a)", "Casado(a)", "Divorciado(a)", "Separado(a) Juridicamente", "Viúvo(a)" };
            cmbEstadoCivil.Items.AddRange(estadosCivis);
        }

        // NOVO MÉTODO PARA VERIFICAR EXISTÊNCIA DO CPF NO BANCO
        private bool ClienteExiste(string cpf)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = "SELECT COUNT(*) FROM Cliente WHERE cpf_cliente = @cpf";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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

        private void btnCadastrarCliente_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios()) return;

            // Captura os valores
            nomeCliente = txtNomeCliente.Text.Trim();
            dataNascimento = dttmCliente.Value.Date;
            rgCliente = txtRgCliente.Text.Trim();
            cpfCliente = txtCpfClinte.Text.Trim();
            estadoCivilCliente = cmbEstadoCivil.Text;

            enderecoCliente = txtEndereco.Text.Trim();
            numeroEnderecoCliente = txtNumeroEndereco.Text.Trim();
            compEnderecoCliente = txtComplementoCasa.Text.Trim();
            cepCliente = txtCepCliente.Text.Trim();
            bairroCliente = txtBairroCliente.Text.Trim();
            cidadeCliente = txtCidadeCliente.Text.Trim();
            estadoCliente = cmbEstadoCliente.Text;

            contatoCelular1 = txtNmroCelular1.Text.Trim();
            contatoCelular2 = txtNmroCelular2.Text.Trim();
            contatoTelefone1 = txtNmroTelefone1.Text.Trim();
            contatoTelefone2 = txtNmroTelefone2.Text.Trim();
            contatoEmail = txtContatoEmail.Text.Trim();

            // VERIFICA SE JÁ EXISTE UM CLIENTE COM O MESMO CPF
            if (ClienteExiste(cpfCliente))
            {
                MessageBox.Show("Já existe um cliente cadastrado com este CPF.", "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                INSERT INTO Cliente 
                (nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente, 
                 logradouro_cliente, numero_cliente, complemento_cliente, 
                 bairro_cliente, cep_cliente, cidade_cliente, uf_cliente, 
                 estadoCivil_cliente, contato1_cliente, contato2_cliente, 
                 contatoEmergencia_cliente) 
                VALUES 
                (@nome, @nasc, @rg, @cpf, 
                 @endereco, @numero, @complemento, 
                 @bairro, @cep, @cidade, @uf, 
                 @estadoCivil, @contato1, @contato2, @contatoEmergencia)";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeCliente);
                    cmd.Parameters.AddWithValue("@nasc", dataNascimento);
                    cmd.Parameters.AddWithValue("@rg", rgCliente);
                    cmd.Parameters.AddWithValue("@cpf", cpfCliente);
                    cmd.Parameters.AddWithValue("@endereco", enderecoCliente);
                    cmd.Parameters.AddWithValue("@numero", numeroEnderecoCliente);
                    cmd.Parameters.AddWithValue("@complemento", string.IsNullOrWhiteSpace(compEnderecoCliente) ? DBNull.Value : compEnderecoCliente);
                    cmd.Parameters.AddWithValue("@bairro", bairroCliente);
                    cmd.Parameters.AddWithValue("@cep", cepCliente);
                    cmd.Parameters.AddWithValue("@cidade", cidadeCliente);
                    cmd.Parameters.AddWithValue("@uf", estadoCliente);
                    cmd.Parameters.AddWithValue("@estadoCivil", estadoCivilCliente);
                    cmd.Parameters.AddWithValue("@contato1", contatoCelular1);
                    cmd.Parameters.AddWithValue("@contato2", string.IsNullOrWhiteSpace(contatoCelular2) ? DBNull.Value : contatoCelular2);
                    cmd.Parameters.AddWithValue("@contatoEmergencia", contatoTelefone1);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lstbResumoCadastro.Items.Add($"Nome: {nomeCliente} - Nascimento: {dataNascimento:dd/MM/yyyy} - CPF: {cpfCliente} - Contato: {contatoCelular1} - Estado: {estadoCliente}");

                    btnLimpar.PerformClick(); // Limpa os campos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
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
