using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormSelecionarAgendamento : Form
    {
        private DataTable dtConsultas;

        public FormSelecionarAgendamento()
        {
            InitializeComponent();
            dtConsultas = new DataTable();
        }

        private void FormSelecionarAgendamento_Load(object sender, EventArgs e)
        {
            CarregarTodasConsultas();

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Enabled = false;
        }

        private void CarregarTodasConsultas()
        {
            string query = @"
                SELECT
                    id_consulta,
                    nome_cliente,
                    dataHora_consulta,
                    tipo_consulta,
                    descricao_consulta,
                    status_consulta,
                    obs_consulta
                FROM Consulta 
                INNER JOIN Cliente ON id_cliente = id_cliente_consulta";

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridConsultas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um agendamento para editar.", "Nenhuma seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idConsulta = Convert.ToInt32(dataGridConsultas.SelectedRows[0].Cells["id_consulta"].Value);

            FormEditarAgendamento formEditar = new FormEditarAgendamento(idConsulta);
            formEditar.ShowDialog();
        }

        private void btnLimparFiltros_Click_1(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            dtpDataSelecionada.Value = DateTime.Today;
            CarregarTodasConsultas();
        }

        private void btnFiltrarNome_Click_1(object sender, EventArgs e)
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

        private void btnFiltrarData_Click_1(object sender, EventArgs e)
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

        private void btnFiltrarSemana_Click_1(object sender, EventArgs e)
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
    }
}