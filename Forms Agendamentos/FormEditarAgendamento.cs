using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeAgendementos;
public partial class FormEditarAgendamento : Form
{
    private int idConsulta;
    private int idTerapia;


    public string terapiaSelecionada;
    public DateTime dataSelecionada;
    public DateTime dataHoraSelecionada;
    public TimeSpan horaSelecionada;
    public string tipoDaConsulta;
    public string descricaoConsulta;

    private bool carregandoDados = false;

    public FormEditarAgendamento(int idConsulta)
    {
        InitializeComponent();
        this.idConsulta = idConsulta;

    }

    private void FormEditarAgendamento_Load(object sender, EventArgs e)
    {
        carregandoDados = true;

        var comboBoxes = new List<ComboBox> { cmb1, cmb2, cmb3 };
        foreach (var cmb in comboBoxes)
        {
            cmb.SelectedIndexChanged += cmb_SelectedIndexChanged;
        }

        CarregarDadosAgendamento();

        carregandoDados = false;
    }

    private void cmb_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoDados) return;

        ComboBox cmb = sender as ComboBox;

        if (cmb.SelectedIndex != -1)
        {
            string nomeSelecionado = cmb.SelectedItem.ToString();

            DialogResult resultado = MessageBox.Show(
                $"Você selecionou '{nomeSelecionado}'. Confirma?",
                "Confirmar Seleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                terapiaSelecionada = nomeSelecionado;
                idTerapia = ObterIdTerapiaPorNome(nomeSelecionado);
                DesabilitarOutrosComboBoxes(cmb);
            }
            else
            {
                cmb.SelectedIndex = -1;
                HabilitarTodosComboBoxes();
            }
        }
    }

    private void DesabilitarOutrosComboBoxes(ComboBox cmbSelecionado)
    {
        if (cmbSelecionado != cmb1) cmb1.Enabled = false;
        if (cmbSelecionado != cmb2) cmb2.Enabled = false;
        if (cmbSelecionado != cmb3) cmb3.Enabled = false;
    }

    private void HabilitarTodosComboBoxes()
    {
        cmb1.Enabled = true;
        cmb2.Enabled = true;
        cmb3.Enabled = true;

        cmb1.SelectedIndex = -1;
        cmb2.SelectedIndex = -1;
        cmb3.SelectedIndex = -1;

        terapiaSelecionada = null;
    }

    private void CarregarDadosAgendamento()
    {
        using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
        {
            conn.Open();
            string query = @"SELECT id_terapia_consulta, dataHora_consulta, tipo_consulta, descricao_consulta
                             FROM Consulta WHERE id_consulta = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idConsulta);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idTerapia = reader.GetInt32(0);
                        dataHoraSelecionada = reader.GetDateTime(1);
                        tipoDaConsulta = reader.GetString(2);
                        descricaoConsulta = reader.GetString(3);
                    }
                }
            }
        }

        dtpDia.Value = dataHoraSelecionada.Date;
        dtpHora.Value = DateTime.Today.Add(dataHoraSelecionada.TimeOfDay);
        cmbTipoConsulta.Text = tipoDaConsulta;
        txtDescricaoConsulta.Text = descricaoConsulta;

        string nomeTerapia = ObterNomeTerapiaPorId(idTerapia);
        SelecionarTerapiaNosCombos(nomeTerapia);
    }

    private void SelecionarTerapiaNosCombos(string nomeTerapia)
    {
        foreach (ComboBox cmb in new[] { cmb1, cmb2, cmb3 })
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                var item = cmb.Items[i];
                if (item.ToString().Equals(nomeTerapia, StringComparison.OrdinalIgnoreCase))
                {
                    cmb.SelectedIndexChanged -= cmb_SelectedIndexChanged;
                    cmb.SelectedIndex = i;
                    cmb.SelectedIndexChanged += cmb_SelectedIndexChanged;

                    terapiaSelecionada = nomeTerapia;
                    idTerapia = ObterIdTerapiaPorNome(nomeTerapia);
                    return;
                }
            }
        }
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

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult confirmarExclusaoAgendamento = MessageBox.Show("Deseja realmente cancelar este agendamento? Esta alteração não pode ser desfeita", "Confirmar Desagendamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirmarExclusaoAgendamento == DialogResult.Yes)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                string query = @"
                    UPDATE Consulta SET 
                        status_consulta = 'CANCELADA'
                    WHERE id_consulta = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idConsulta);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Consulta cancelada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
        else
        {
            MessageBox.Show("Consulta não cancelada", "Dados não alterados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
    

    private void btnProsseguir_Click(object sender, EventArgs e)
    {
        dataHoraSelecionada = dtpDia.Value.Date + dtpHora.Value.TimeOfDay;
        tipoDaConsulta = cmbTipoConsulta.Text;
        descricaoConsulta = txtDescricaoConsulta.Text;

        if (idTerapia == 0)
        {
            MessageBox.Show("Selecione pelo menos uma terapia antes de salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        id_terapia_consulta = @idT
                    WHERE id_consulta = @idConsulta";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoDaConsulta);
                    cmd.Parameters.AddWithValue("@descricao", descricaoConsulta);
                    cmd.Parameters.AddWithValue("@dataHora", dataHoraSelecionada);
                    cmd.Parameters.AddWithValue("@idT", idTerapia);
                    cmd.Parameters.AddWithValue("@idConsulta", idConsulta);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Agendamento atualizado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }

    private void btnLimparOpcao_Click(object sender, EventArgs e)
    {
        HabilitarTodosComboBoxes();
    }
}
