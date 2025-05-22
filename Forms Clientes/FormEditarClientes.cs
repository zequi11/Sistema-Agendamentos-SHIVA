using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeAgendementos
{
    public partial class FormEditarClientes : Form
    {
        private readonly string cpfCliente;
        public string statusCliente;

        public FormEditarClientes(string cpf)
        {
            InitializeComponent();
            cpfCliente = cpf;
            CarregarListas();
            CarregarDadosCliente();
            StatusClienteAtivo();
        }

        private void FormEditarClientes_Load(object sender, EventArgs e)
        {

        }

        private void StatusClienteAtivo()
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = @"
                    UPDATE Cliente SET
                    status_cliente = @statusCliente 
                    WHERE cpf_cliente = @cpf;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@statusCliente", txtStatusCliente.Text.Trim());
                }
            }
            statusCliente = txtStatusCliente.Text;
            if (txtStatusCliente.Text == "ATIVADO")
            {
                btnAtivarCliente.Enabled = false;
            }
            else if(txtStatusCliente.Text == "DESATIVADO")
            {
                btnDeletarCliente.Enabled = false;
            }
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
                        txtContatoEmergenciaCel.Text = reader["contatoEmergenciaCel_cliente"].ToString();
                        txtContatoEmergenciaTel.Text = reader["contatoEmergenciaTel_cliente"].ToString();
                        txtContatoEmail.Text = reader["email_cliente"].ToString();
                        txtCelular1.Text = reader["celular1_cliente"].ToString();
                        txtTelefone1.Text = reader["telefone1_cliente"].ToString();
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
                string.IsNullOrWhiteSpace(txtCelular1.Text) ||
                string.IsNullOrWhiteSpace(txtContatoEmergenciaCel.Text) ||
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            txtRgCliente.Clear();
            txtEndereco.Clear();
            txtNumeroEndereco.Clear();
            txtComplementoCasa.Clear();
            txtCepCliente.Clear();
            txtBairroCliente.Clear();
            txtCidadeCliente.Clear();
            cmbEstadoCliente.SelectedIndex = -1;
            cmbEstadoCivil.SelectedIndex = -1;
            txtContatoEmergenciaCel.Clear();
            txtContatoEmergenciaTel.Clear();
            txtTelefone1.Clear();
            txtCelular1.Clear();
            txtContatoEmail.Clear();
            dttmCliente.Value = DateTime.Today;
            txtNomeCliente.Focus();
        }

        private void btnSalvarAlteracoes_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCamposObrigatorios())
                return;

            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = @"
                    UPDATE Cliente SET 
                        nome_cliente = @nome,
                        nascimento_cliente = @nascimento,
                        rg_cliente = @rg,
                        logradouro_cliente = @logradouro,
                        numero_cliente = @numero,
                        complemento_cliente = @complemento,
                        bairro_cliente = @bairro,
                        cep_cliente = @cep,
                        cidade_cliente = @cidade,
                        uf_cliente = @uf,
                        estadoCivil_cliente = @estadoCivil,
                        celular1_cliente = @celular1,
                        telefone1_cliente = @telefone1,
                        email_cliente = @email,
                        contatoEmergenciaTel_cliente = @contatoEmergenciaTel,
                        contatoEmergenciaCel_cliente = @contatoEmergenciaCel 
                    WHERE cpf_cliente = @cpf";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", txtNomeCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@nascimento", dttmCliente.Value.Date);
                    cmd.Parameters.AddWithValue("@rg", txtRgCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@logradouro", txtEndereco.Text.Trim());
                    cmd.Parameters.AddWithValue("@numero", txtNumeroEndereco.Text.Trim());
                    cmd.Parameters.AddWithValue("@complemento", string.IsNullOrWhiteSpace(txtComplementoCasa.Text) ? DBNull.Value : txtComplementoCasa.Text.Trim());
                    cmd.Parameters.AddWithValue("@bairro", txtBairroCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@cep", txtCepCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@cidade", txtCidadeCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@uf", cmbEstadoCliente.Text);
                    cmd.Parameters.AddWithValue("@estadoCivil", cmbEstadoCivil.Text);
                    cmd.Parameters.AddWithValue("@celular1", txtCelular1.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefone1", string.IsNullOrWhiteSpace(txtTelefone1.Text) ? DBNull.Value : txtTelefone1.Text.Trim());
                    cmd.Parameters.AddWithValue("@contatoEmergenciaTel", string.IsNullOrWhiteSpace(txtContatoEmergenciaTel.Text) ? DBNull.Value : txtContatoEmergenciaTel.Text.Trim());
                    cmd.Parameters.AddWithValue("@contatoEmergenciaCel", txtContatoEmergenciaCel.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtContatoEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpf", cpfCliente);

                    conn.Open();
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum dado foi atualizado. Verifique se o cliente existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDeletarCliente_Click(object sender, EventArgs e)
        {
            DialogResult confirmarExclusaoCliente = MessageBox.Show("Tem certeza que deseja desativar este cliente?", "Confirmar ação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmarExclusaoCliente == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                {
                    string query = @"
                    UPDATE Cliente SET 
                        status_cliente = 'DESATIVADO'
                    WHERE cpf_cliente = @cpf";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfCliente);

                        conn.Open();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente desativado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    statusCliente = "DESATIVADO";
                    btnAtivarCliente.Enabled = true;
                    btnDeletarCliente.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Cliente não desativado", "Dados não alterados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmarAtivacaoCliente = MessageBox.Show("Tem certeza que deseja ativar este cliente?", "Confirmar ação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmarAtivacaoCliente == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                {
                    string query = @"
                    UPDATE Cliente SET 
                        status_cliente = 'ATIVADO'
                    WHERE cpf_cliente = @cpf";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cpf", cpfCliente);

                        conn.Open();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente ativado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    statusCliente = "ATIVADO";
                    btnAtivarCliente.Enabled = false;
                    btnDeletarCliente.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Cliente não desativado", "Dados não alterados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
