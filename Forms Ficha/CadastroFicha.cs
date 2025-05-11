using System.Diagnostics.Metrics;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;



namespace SistemaDeAgendementos
{
    public partial class CadastroFicha : Form
    {
        public CadastroFicha()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text) ||
                string.IsNullOrWhiteSpace(txtAtividadeFisica.Text) ||
                string.IsNullOrWhiteSpace(txtCirurgia.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaEmocional.Text) ||
                string.IsNullOrWhiteSpace(txtAlergia.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaMuscular.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaPele.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaCirculatória.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaRespiratoria.Text) ||
                string.IsNullOrWhiteSpace(txtDoencaNervoso.Text) ||
                string.IsNullOrWhiteSpace(txtOutraDoenca.Text) ||
                string.IsNullOrWhiteSpace(txtObjetivo.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos de texto antes de salvar a ficha.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TemSelecionado(groupBox1.Controls) ||
                !TemSelecionado(groupBox2.Controls) ||
                !TemSelecionado(groupBox3.Controls) ||
                !TemSelecionado(groupBox4.Controls) ||
                !TemSelecionado(groupBox5.Controls) ||
                !TemSelecionado(groupBox6.Controls))
            {
                MessageBox.Show("Por favor, selecione uma opção em todos os grupos de perguntas (radio buttons).", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }







            string NomeCliente = txtNomeCliente.Text;
            string AtividadeFisica = txtAtividadeFisica.Text;
            string Cirurgia = txtCirurgia.Text;
            string DoencaEmocinal = txtDoencaEmocional.Text;
            string Alergia = txtAlergia.Text;
            string DoencaMuscular = txtDoencaMuscular.Text;
            string DoencaPele = txtDoencaPele.Text;
            string DoencaCirculatoria = txtDoencaCirculatória.Text;
            string DoencaRespiratoria = txtDoencaRespiratoria.Text;
            string DoencaNervoso = txtDoencaNervoso.Text;
            string OutraDoenca = txtOutraDoenca.Text;
            string Objetivo = txtObjetivo.Text;
            string UsoMedicamento = txtUsoMedicamento.Text;

            string FrequenciaDeAtividade = "";
            string NivelFlexibilidade = "";
            string ExperienciaMassoterapia = "";
            string MarcaPasso = "";
            string Fumante = "";
            string UltimaSessao = "";




            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    UltimaSessao = radioButton.Text;
                    break;
                }
            }

            foreach (Control contro in groupBox6.Controls)
            {
                if (contro is RadioButton radioButton && radioButton.Checked)
                {
                    NivelFlexibilidade = radioButton.Text;
                    break;
                }
            }

            foreach (Control contr in groupBox5.Controls)
            {
                if (contr is RadioButton radioButton && radioButton.Checked)
                {
                    ExperienciaMassoterapia = radioButton.Text;
                    break;
                }
            }

            foreach (Control cont in groupBox4.Controls)
            {
                if (cont is RadioButton radioButton && radioButton.Checked)
                {
                    MarcaPasso = radioButton.Text;
                    break;
                }
            }

            foreach (Control con in groupBox3.Controls)
            {
                if (con is RadioButton radioButton && radioButton.Checked)
                {
                    Fumante = radioButton.Text;
                    break;
                }
            }

            foreach (Control co in groupBox2.Controls)
            {
                if (co is RadioButton radioButton && radioButton.Checked)
                {
                    FrequenciaDeAtividade = radioButton.Text;
                    break;
                }
            }

            // Conexão com o banco
            string conexaoString = "Server=localhost;Database=ShivaAnanda;User Id=sa;Password=123456;TrustServerCertificate=True;";




            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                string query = @"INSERT INTO Ficha (
        id_cliente_ficha, atividadeFisica_ficha, frequenciaAtividade_ficha,
        flexibilidade_ficha, experienciaMassoterapia_ficha, ultimaSessao_ficha,
        portadorMarcapasso_ficha, cirurgiasRecentes_ficha, alergias_ficha,
        fumante_ficha, doencaMuscular_ficha, doencaSistemaNervoso_ficha,
        doencaEmocional_ficha, doencaCirculatoria_ficha, doencaRespiratoria_ficha,
        doencaPele_ficha, outraDoenca_ficha, usaMedicamento_ficha, objetivoMassagem_ficha)
        VALUES (
        @IdCliente, @AtividadeFisica, @Frequencia, @Flexibilidade, @Experiencia,
        @UltimaSessao, @MarcaPasso, @Cirurgias, @Alergias, @Fumante,
        @DoencaMuscular, @DoencaNervoso, @DoencaEmocional, @DoencaCirculatoria,
        @DoencaRespiratoria, @DoencaPele, @OutraDoenca, @Medicamento, @Objetivo)";

                SqlCommand comando = new SqlCommand(query, conexao);

                // Adiciona os parâmetros usando as variáveis que você já criou acima
                comando.Parameters.AddWithValue("@IdCliente", 1); // depois você pode trocar isso para o ID do cliente real
                comando.Parameters.AddWithValue("@AtividadeFisica", AtividadeFisica);
                comando.Parameters.AddWithValue("@Frequencia", FrequenciaDeAtividade);
                comando.Parameters.AddWithValue("@Flexibilidade", NivelFlexibilidade);
                comando.Parameters.AddWithValue("@Experiencia", ExperienciaMassoterapia);
                comando.Parameters.AddWithValue("@UltimaSessao", UltimaSessao);
                comando.Parameters.AddWithValue("@MarcaPasso", MarcaPasso);
                comando.Parameters.AddWithValue("@Cirurgias", Cirurgia);
                comando.Parameters.AddWithValue("@Alergias", Alergia);
                comando.Parameters.AddWithValue("@Fumante", Fumante);
                comando.Parameters.AddWithValue("@DoencaMuscular", DoencaMuscular);
                comando.Parameters.AddWithValue("@DoencaNervoso", DoencaNervoso);
                comando.Parameters.AddWithValue("@DoencaEmocional", DoencaEmocinal);
                comando.Parameters.AddWithValue("@DoencaCirculatoria", DoencaCirculatoria);
                comando.Parameters.AddWithValue("@DoencaRespiratoria", DoencaRespiratoria);
                comando.Parameters.AddWithValue("@DoencaPele", DoencaPele);
                comando.Parameters.AddWithValue("@OutraDoenca", OutraDoenca);
                comando.Parameters.AddWithValue("@Medicamento", "Sim"); // ou coloque conforme seu formulário
                comando.Parameters.AddWithValue("@Objetivo", Objetivo);

                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Ficha salva com sucesso no banco de dados!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar no banco de dados: " + ex.Message);
                }
            }


            MessageBox.Show($"Dados da ficha:\n" +
                $"- Frequência de atividade: {FrequenciaDeAtividade}\n" +
                $"- Nível de flexibilidade: {NivelFlexibilidade}\n" +
                $"- Experiência com massoterapia: {ExperienciaMassoterapia}\n" +
                $"- Usuário de marca-passo: {MarcaPasso}\n" +
                $"- Fumante: {Fumante}\n" +
                $"- Última sessão de massoterapia: {UltimaSessao}\n" +
                $"- Nome do cliente: {NomeCliente}\n" +
                $"- Atividade física: {AtividadeFisica}\n" +
                $"- Cirurgia recente: {Cirurgia}\n" +
                $"- Doença emocional: {DoencaEmocinal}\n" +
                $"- Alergias: {Alergia}\n" +
                $"- Doença muscular: {DoencaMuscular}\n" +
                $"- Doença de pele: {DoencaPele}\n" +
                $"- Doença circulatória: {DoencaCirculatoria}\n" +
                $"- Doença respiratória: {DoencaRespiratoria}\n" +
                $"- Doença no sistema nervoso: {DoencaNervoso}\n" +
                $"- Outra doença: {OutraDoenca}\n" +
                $"- Objetivo da sessão: {Objetivo}",
                "Ficha do Cliente");

            MessageBox.Show("Ficha salva com êxito!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtAlergia.Clear();
            txtAtividadeFisica.Clear();
            txtCirurgia.Clear();
            txtDoencaCirculatória.Clear();
            txtDoencaEmocional.Clear();
            txtDoencaMuscular.Clear();
            txtDoencaNervoso.Clear();
            txtDoencaPele.Clear();
            txtDoencaRespiratoria.Clear();
            txtObjetivo.Clear();
            txtOutraDoenca.Clear();
            txtNomeCliente.Clear();
        }


        private bool TemSelecionado(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is RadioButton rb && rb.Checked)
                    return true;
            }
            return false;
        }

        private void rdbSimExperiencia_CheckedChanged(object sender, EventArgs e)
        {

            bool habilitar = rdbSimExperiencia.Checked;

            // Habilita ou desabilita os RadioButtons de "Última Sessão"
            rdbNesteAno.Enabled = habilitar;
            rdbNesteMes.Enabled = habilitar;
            rdbNestaSemana.Enabled = habilitar;
            rdbMaisdeUm.Enabled = habilitar;

            // Se desmarcar o "Sim", limpa a seleção
            if (!habilitar)
            {
                rdbNesteAno.Checked = false;
                rdbNesteMes.Checked = false;
                rdbNestaSemana.Checked = false;
                rdbMaisdeUm.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
