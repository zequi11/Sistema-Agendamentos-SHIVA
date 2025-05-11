using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
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
            dtClientes = new DataTable();  // Inicializando o DataTable
            dataAdapter = new SqlDataAdapter();
        }
        private void CarregarDados()
        {
            string query = "SELECT id_cliente, nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente, logradouro_cliente, numero_cliente, complemento_cliente, bairro_cliente, cep_cliente, cidade_cliente, uf_cliente, estadoCivil_cliente, contato1_cliente, contato2_cliente, contatoEmergencia_cliente, status_cliente, obs_cliente FROM Cliente";

            try
            {
                SqlCommand comando = new SqlCommand(query, conexao);

                dataAdapter.SelectCommand = comando;  // Definir o comando SELECT para o dataAdapter
                dtClientes.Clear();  // Limpar o DataTable antes de preencher novamente
                dataAdapter.Fill(dtClientes);  // Preencher o DataTable com os dados da consulta
                dataGridClientes.DataSource = dtClientes;  // Atribuir o DataTable ao DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Cliente";
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                query = "SELECT * FROM Cliente WHERE nome_cliente = " + "'" + txtNome.Text + "'";
            }
            else if (!string.IsNullOrWhiteSpace(txtcpf.Text))
            {
                query = "SELECT * FROM Cliente WHERE cpf_cliente = " + "'" + txtcpf.Text + "'";
            }
            try
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    comando.Parameters.AddWithValue("@nomeCliente", "%" + txtNome.Text + "%");
                }
                if (!string.IsNullOrWhiteSpace(txtcpf.Text))
                {
                    comando.Parameters.AddWithValue("@cpfCliente", "%" + txtcpf.Text + "%");
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            CarregarDados();
            txtcpf.Text = null;
            txtNome.Text = null;

        }

        private void FormFiltrarClientes_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
