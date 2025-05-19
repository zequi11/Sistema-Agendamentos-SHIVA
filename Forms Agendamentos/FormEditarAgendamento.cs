using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos;
public partial class FormEditarAgendamento : Form
{
    private int idConsulta;

    private int idTerapia1 = 0;
    private int idTerapia2 = 0;
    private int idTerapia3 = 0;

    private DateTime dataHoraSelecionada;
    private string tipoDaConsulta;
    private string descricaoConsulta;

    public FormEditarAgendamento(int idConsulta)
    {
        InitializeComponent();
        this.idConsulta = idConsulta;

        cmb1.SelectedIndexChanged += cmb_SelectedIndexChanged;
        cmb2.SelectedIndexChanged += cmb_SelectedIndexChanged;
        cmb3.SelectedIndexChanged += cmb_SelectedIndexChanged;
    }

    private void FormEditarAgendamento_Load(object sender, EventArgs e)
    {
        CarregarTerapiasNoCombo(cmb1);
        CarregarTerapiasNoCombo(cmb2);
        CarregarTerapiasNoCombo(cmb3);

        CarregarDadosAgendamento();
    }

    private void CarregarTerapiasNoCombo(ComboBox combo)
    {
        combo.Items.Clear();

        using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
        {
            conn.Open();
            string query = "SELECT nome_terapia FROM Terapia ORDER BY nome_terapia";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        combo.Items.Add(reader.GetString(0));
                    }
                }
            }
        }
    }

    private void CarregarDadosAgendamento()
    {
        using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
        {
            conn.Open();
            string query = @"SELECT id_terapia_consulta1, id_terapia_consulta2, id_terapia_consulta3, dataHora_consulta, tipo_consulta, descricao_consulta
                             FROM Consulta WHERE id_consulta = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idConsulta);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idTerapia1 = reader.GetInt32(0);
                        idTerapia2 = reader.GetInt32(1);
                        idTerapia3 = reader.GetInt32(2);
                        dataHoraSelecionada = reader.GetDateTime(3);
                        tipoDaConsulta = reader.GetString(4);
                        descricaoConsulta = reader.GetString(5);
                    }
                }
            }
        }

        // Definir os nomes das terapias nos combos
        cmb1.SelectedItem = ObterNomeTerapiaPorId(idTerapia1);
        cmb2.SelectedItem = ObterNomeTerapiaPorId(idTerapia2);
        cmb3.SelectedItem = ObterNomeTerapiaPorId(idTerapia3);

        dtpDia.Value = dataHoraSelecionada.Date;
        dtpHora.Value = DateTime.Today.Add(dataHoraSelecionada.TimeOfDay);
        cmbTipoConsulta.Text = tipoDaConsulta;
        txtDescricaoConsulta.Text = descricaoConsulta;
    }

    private string ObterNomeTerapiaPorId(int idTerapia)
    {
        if (idTerapia == 0) return null;

        string nome = "";

        using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
        {
            conn.Open();
            string query = "SELECT nome_terapia FROM Terapia WHERE id_terapia = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idTerapia);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    nome = result.ToString();
            }
        }

        return nome;
    }

    private int ObterIdTerapiaPorNome(string nomeTerapia)
    {
        if (string.IsNullOrEmpty(nomeTerapia)) return 0;

        int id = 0;

        using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
        {
            conn.Open();
            string query = "SELECT id_terapia FROM Terapia WHERE nome_terapia = @nome";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nome", nomeTerapia);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Convert.ToInt32(result);
            }
        }

        return id;
    }

    private void cmb_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cmb = (ComboBox)sender;
        if (cmb.SelectedIndex == -1) return;

        string nomeTerapia = cmb.SelectedItem.ToString();

        DialogResult resultado = MessageBox.Show($"Você selecionou '{nomeTerapia}'. Confirma?", "Confirmar Seleção",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado == DialogResult.Yes)
        {
            int id = ObterIdTerapiaPorNome(nomeTerapia);

            if (cmb == cmb1) idTerapia1 = id;
            else if (cmb == cmb2) idTerapia2 = id;
            else if (cmb == cmb3) idTerapia3 = id;
        }
        else
        {
            cmb.SelectedIndex = -1;
            if (cmb == cmb1) idTerapia1 = 0;
            else if (cmb == cmb2) idTerapia2 = 0;
            else if (cmb == cmb3) idTerapia3 = 0;
        }
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        dataHoraSelecionada = dtpDia.Value.Date + dtpHora.Value.TimeOfDay;
        tipoDaConsulta = cmbTipoConsulta.Text;
        descricaoConsulta = txtDescricaoConsulta.Text;

        // Verifica se pelo menos uma terapia está selecionada (se desejar)
        if (idTerapia1 == 0 && idTerapia2 == 0 && idTerapia3 == 0)
        {
            MessageBox.Show("Selecione pelo menos uma terapia antes de salvar.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult confirm = MessageBox.Show("Confirma as alterações?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                conn.Open();

                string updateQuery = @"
                    UPDATE Consulta SET 
                        tipo_consulta = @tipo,
                        descricao_consulta = @descricao,
                        dataHora_consulta = @dataHora,
                        id_terapia_consulta1 = @idT1,
                        id_terapia_consulta2 = @idT2,
                        id_terapia_consulta3 = @idT3
                    WHERE id_consulta = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoDaConsulta);
                    cmd.Parameters.AddWithValue("@descricao", descricaoConsulta);
                    cmd.Parameters.AddWithValue("@dataHora", dataHoraSelecionada);
                    cmd.Parameters.AddWithValue("@idT1", idTerapia1);
                    cmd.Parameters.AddWithValue("@idT2", idTerapia2);
                    cmd.Parameters.AddWithValue("@idT3", idTerapia3);
                    cmd.Parameters.AddWithValue("@id", idConsulta);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Agendamento atualizado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult resultado = MessageBox.Show("Deseja cancelar a edição sem salvar?", "Cancelar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado == DialogResult.Yes)
        {
            this.Close();
        }
    }
}
