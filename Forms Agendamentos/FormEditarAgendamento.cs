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
        var comboBoxes = new List<ComboBox> { cmb1, cmb2, cmb3 };
        foreach (var cmb in comboBoxes)
        {
            cmb.SelectedIndexChanged += cmb_SelectedIndexChanged;
        }

        CarregarDadosAgendamento();

    }

    private void cmb_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cmb = sender as ComboBox;

        if (cmb.SelectedIndex != -1)
        {
            terapiaSelecionada = cmb.SelectedItem.ToString();

            DialogResult resultado = MessageBox.Show($"Você selecionou '{cmb.SelectedItem.ToString()}'. Confirma?", "Confirmar Seleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                DesabilitarOutrosComboBoxes(cmb);
            }
            else
            {
                cmb.SelectedIndex = -1;
                HabilitarTodosComboBoxes();
                terapiaSelecionada = null;
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
        DialogResult resultado = MessageBox.Show("Deseja cancelar a edição sem salvar?", "Cancelar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado == DialogResult.Yes)
        {
            this.Close();
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
                        id_terapia_consulta = @idT,
                    WHERE id_consulta = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoDaConsulta);
                    cmd.Parameters.AddWithValue("@descricao", descricaoConsulta);
                    cmd.Parameters.AddWithValue("@dataHora", dataHoraSelecionada);
                    cmd.Parameters.AddWithValue("@idT1", idTerapia);
                    cmd.Parameters.AddWithValue("@id", idConsulta);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Agendamento atualizado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
