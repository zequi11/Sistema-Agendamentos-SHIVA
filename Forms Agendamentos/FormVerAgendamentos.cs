using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormVerAgendamentos : Form
    {
        private DataTable dtConsultas;

        public FormVerAgendamentos()
        {
            InitializeComponent();
            dtConsultas = new DataTable();
        }

        private void FormAgendamentos_Load(object sender, EventArgs e)
        {
            CarregarTodasConsultas();
        }

        private void CarregarTodasConsultas()
        {
            string query = @"
                SELECT
                    c.id_consulta,
                    cl.nome_cliente,
                    c.dataHora_consulta,
                    c.tipo_consulta,
                    c.descricao_consulta,
                    c.status_consulta,
                    c.obs_consulta
                FROM Consulta c
                INNER JOIN Cliente cl ON cl.id_cliente = c.id_cliente_consulta";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    conn.Open();
                    dtConsultas.Clear();
                    adapter.Fill(dtConsultas);
                    dataGridConsultas.DataSource = dtConsultas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar agendamentos: " + ex.Message);
            }
        }

        private void btnFiltrarData_Click(object sender, EventArgs e)
        {
            DateTime dataSelecionada = dtpDataSelecionada.Value.Date;

            string query = @"
                SELECT
                    c.id_consulta,
                    cl.nome_cliente,
                    c.dataHora_consulta,
                    c.tipo_consulta,
                    c.descricao_consulta,
                    c.status_consulta,
                    c.obs_consulta
                FROM Consulta c
                INNER JOIN Cliente cl ON cl.id_cliente = c.id_cliente_consulta
                WHERE CAST(c.dataHora_consulta AS DATE) = @data";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@data", dataSelecionada);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        dtConsultas = new DataTable();
                        conn.Open();
                        adapter.Fill(dtConsultas);
                        dataGridConsultas.DataSource = dtConsultas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar por data: " + ex.Message);
            }
        }

        private void btnFiltrarSemana_Click(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Today;
            DayOfWeek primeiroDia = DayOfWeek.Sunday;
            int diasAtras = (7 + (hoje.DayOfWeek - primeiroDia)) % 7;
            DateTime inicioSemana = hoje.AddDays(-diasAtras).Date;
            DateTime fimSemana = inicioSemana.AddDays(6).Date;

            string query = @"
                SELECT
                    c.id_consulta,
                    cl.nome_cliente,
                    c.dataHora_consulta,
                    c.tipo_consulta,
                    c.descricao_consulta,
                    c.status_consulta,
                    c.obs_consulta
                FROM Consulta c
                INNER JOIN Cliente cl ON cl.id_cliente = c.id_cliente_consulta
                WHERE CAST(c.dataHora_consulta AS DATE) BETWEEN @inicio AND @fim";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@inicio", inicioSemana);
                    comando.Parameters.AddWithValue("@fim", fimSemana);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        dtConsultas = new DataTable();
                        conn.Open();
                        adapter.Fill(dtConsultas);
                        dataGridConsultas.DataSource = dtConsultas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar por semana: " + ex.Message);
            }
        }

        private void btnFiltrarNome_Click(object sender, EventArgs e)
        {
            string nome = txtNomeCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Digite o nome do cliente.", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCliente.Focus();
                return;
            }

            string query = @"
                SELECT
                    c.id_consulta,
                    cl.nome_cliente,
                    c.dataHora_consulta,
                    c.tipo_consulta,
                    c.descricao_consulta,
                    c.status_consulta,
                    c.obs_consulta
                FROM Consulta c
                INNER JOIN Cliente cl ON cl.id_cliente = c.id_cliente_consulta
                WHERE cl.nome_cliente LIKE @nome";

            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        dtConsultas = new DataTable();
                        conn.Open();
                        adapter.Fill(dtConsultas);
                        dataGridConsultas.DataSource = dtConsultas;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar por nome: " + ex.Message);
            }
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            dtpDataSelecionada.Value = DateTime.Today;
            CarregarTodasConsultas();
        }
    }
}