using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormListaClientes : Form
    {
        private DataTable dtClientes;

        public FormListaClientes()
        {
            InitializeComponent();
            dtClientes = new DataTable();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            string query = @"
                SELECT id_cliente, nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente,
                       logradouro_cliente, numero_cliente, complemento_cliente, bairro_cliente,
                       cep_cliente, cidade_cliente, uf_cliente, estadoCivil_cliente,
                       contato1_cliente, contato2_cliente, contatoEmergencia_cliente,
                       status_cliente, obs_cliente
                FROM Cliente";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                {
                    conn.Open();
                    dtClientes.Clear();
                    dataAdapter.Fill(dtClientes);
                    dataGridClientes.DataSource = dtClientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtcpf.Clear();
            txtNome.Clear();
            CarregarDados();
        }

        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                string cpfSelecionado = dataGridClientes.SelectedRows[0].Cells["cpf_cliente"].Value.ToString();

                
                FormPrincipal principal = this.MdiParent as FormPrincipal;

                foreach (Form f in principal.MdiChildren)
                {
                    if (f is FormEditarClientes)
                    {
                        f.Close();
                        break;
                    }
                }

                FormEditarClientes editarForm = new FormEditarClientes(cpfSelecionado)
                {
                    MdiParent = principal,
                };
                editarForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void btnFiltrarNome_Click(object sender, EventArgs e)
        {
            string nomeFiltro = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeFiltro))
            {
                MessageBox.Show("Por favor, digite um nome para filtrar.", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            string query = @"
                SELECT id_cliente, nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente,
                logradouro_cliente, numero_cliente, complemento_cliente, bairro_cliente,
                cep_cliente, cidade_cliente, uf_cliente, estadoCivil_cliente,
                contato1_cliente, contato2_cliente, contatoEmergencia_cliente,
                status_cliente, obs_cliente
                FROM Cliente
                WHERE nome_cliente LIKE @nomeCliente";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@nomeCliente", "%" + nomeFiltro + "%");
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        dtClientes = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dtClientes);
                        dataGridClientes.DataSource = dtClientes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar pelo nome: " + ex.Message);
            }
        }

        private void btnFiltrarCPF_Click(object sender, EventArgs e)
        {
            string cpfFiltro = txtcpf.Text.Trim();

            if (string.IsNullOrWhiteSpace(cpfFiltro))
            {
                MessageBox.Show("Por favor, digite um CPF para filtrar.", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcpf.Focus();
                return;
            }

            string query = @"
                SELECT id_cliente, nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente,
                       logradouro_cliente, numero_cliente, complemento_cliente, bairro_cliente,
                       cep_cliente, cidade_cliente, uf_cliente, estadoCivil_cliente,
                       contato1_cliente, contato2_cliente, contatoEmergencia_cliente,
                       status_cliente, obs_cliente
                FROM Cliente
                WHERE cpf_cliente = @cpfCliente";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@cpfCliente", cpfFiltro);
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        dtClientes = new DataTable();
                        conn.Open();
                        dataAdapter.Fill(dtClientes);
                        dataGridClientes.DataSource = dtClientes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar pelo CPF: " + ex.Message);
            }
        }
    }
}

