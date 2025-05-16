using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormFiltrarClientes : Form
    {
        private string stringConexao = "Server=localhost;Database=SistemaAgendamento;User Id=sa;Password=123456;TrustServerCertificate=True;";
        private SqlConnection conexao;
        private SqlDataAdapter dataAdapter;
        private DataTable dtClientes;

        public FormFiltrarClientes()
        {
            InitializeComponent();
            conexao = new SqlConnection(stringConexao);
            dtClientes = new DataTable();
            dataAdapter = new SqlDataAdapter();
        }

        private void FormFiltrarClientes_Load(object sender, EventArgs e)
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
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    dataAdapter.SelectCommand = comando;
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT id_cliente, nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente,
                           logradouro_cliente, numero_cliente, complemento_cliente, bairro_cliente,
                           cep_cliente, cidade_cliente, uf_cliente, estadoCivil_cliente,
                           contato1_cliente, contato2_cliente, contatoEmergencia_cliente,
                           status_cliente, obs_cliente
                    FROM Cliente
                    WHERE 1=1";

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;

                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    query += " AND nome_cliente LIKE @nomeCliente";
                    comando.Parameters.AddWithValue("@nomeCliente", "%" + txtNome.Text.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(txtcpf.Text))
                {
                    query += " AND cpf_cliente LIKE @cpfCliente";
                    comando.Parameters.AddWithValue("@cpfCliente", "%" + txtcpf.Text.Trim() + "%");
                }

                comando.CommandText = query;

                dataAdapter = new SqlDataAdapter(comando);
                dtClientes = new DataTable();
                dataAdapter.Fill(dtClientes);
                dataGridClientes.DataSource = dtClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar os dados: " + ex.Message);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            txtcpf.Clear();
            txtNome.Clear();
            CarregarDados();
        }
    }
}
