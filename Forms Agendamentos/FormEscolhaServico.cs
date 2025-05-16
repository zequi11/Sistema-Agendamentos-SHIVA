using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeAgendementos
{
    public partial class FormEscolhaServico : Form
    {
        public string terapiaSelecionada;
        public DateTime dataSelecionada;
        public DateTime dataHoraSelecionada;
        public TimeSpan horaSelecionada;
        public string tipoDaConsulta;
        public string descricaoConsulta;

        public FormEscolhaServico()
        {
            InitializeComponent();

            var comboBoxes = new List<ComboBox> { cmb1, cmb2, cmb3 };
            foreach (var cmb in comboBoxes)
            {
                cmb.SelectedIndexChanged += cmb_SelectedIndexChanged;
            }

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

        private bool VerificarDisponibilidade()
        {
            dataSelecionada = dtpDia.Value.Date;
            horaSelecionada = dtpHora.Value.TimeOfDay;

            if (dataSelecionada < DateTime.Today)
            {
                MessageBox.Show("A data selecionada já passou.", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dataSelecionada.DayOfWeek == DayOfWeek.Saturday || dataSelecionada.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Selecione um dia útil (segunda a sexta).", "Data inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (horaSelecionada < TimeSpan.FromHours(7) || horaSelecionada >= TimeSpan.FromHours(17) ||
                (horaSelecionada >= TimeSpan.FromHours(12) && horaSelecionada < TimeSpan.FromHours(14)))
            {
                MessageBox.Show("Horário inválido. O SPA funciona das 07h às 17h, exceto das 12h às 14h.", "Horário inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            dataHoraSelecionada = dataSelecionada + horaSelecionada;


            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*) FROM Consulta
                WHERE 
                status_consulta = 'ATIVO' AND
                CAST(dataHora_consulta AS DATE) = @dataSelecionada AND
                ABS(DATEDIFF(MINUTE, dataHora_consulta, @dataHoraSelecionada)) < 60";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dataSelecionada", dataSelecionada);
                    cmd.Parameters.AddWithValue("@dataHoraSelecionada", dataHoraSelecionada);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Horário indisponível. Já existe uma consulta marcada muito próxima desse horário.");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool VerificarProdutosMassagem()
        {
            if (string.IsNullOrEmpty(terapiaSelecionada))
            {
                MessageBox.Show("Selecione uma massagem.", "Massagem não selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Dictionary<string, List<string>> produtosPorMassagem = new Dictionary<string, List<string>>
            {
                { "Massagem Relaxante", new List<string> { "Óleo Essencial de Lavanda", "Creme Neutro", "Toalhas Descartáveis" } },
                { "Massagem com Aromaterapia", new List<string> { "Óleo Essencial de Morango", "Difusor de Aromas", "Vela Perfumada" } },
                { "Massagem com Pedras Quentes", new List<string> { "Pedras Vulcânicas", "Óleo de Massagem Neutro", "Toalhas Aquecidas" } },
                { "Shiatsu", new List<string> { "Toalha Higienizada", "Lençol Descartável", "Álcool 70%" } },
                { "Reflexologia Podal", new List<string> { "Creme para Pés", "Óleo de Hortelã", "Toalhas Descartáveis" } },
                { "Massagem Desportiva", new List<string> { "Gel Anti-inflamatório", "Creme de Aquecimento Muscular", "Bandagem Elástica" } },
                { "Drenagem Linfática", new List<string> { "Gel Redutor", "Óleo de Semente de Uva", "Luvas Descartáveis" } },
                { "Tui Na", new List<string> { "Bálsamo Chinês", "Óleo Herbal", "Toalha Descartável" } },
                { "Massagem com Bambus", new List<string> { "Bambus de Massagem", "Óleo Vegetal", "Creme Neutro" } }
            };

            if (!produtosPorMassagem.ContainsKey(terapiaSelecionada))
            {
                MessageBox.Show("Massagem não cadastrada.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<string> produtosNecessarios = produtosPorMassagem[terapiaSelecionada];
            List<string> produtosIndisponiveis = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                conn.Open();

                foreach (string produto in produtosNecessarios)
                {
                    string query = @"SELECT COUNT(*) FROM Produto
                             WHERE nome_produto = @nome AND status_produto = 'ATIVO' AND qntd_produto > 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", produto);
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                        {
                            produtosIndisponiveis.Add(produto);
                        }
                    }
                }
            }

            if (produtosIndisponiveis.Count > 0)
            {
                string faltando = string.Join("\n", produtosIndisponiveis);
                MessageBox.Show($"Os seguintes produtos estão indisponíveis:\n{faltando}", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HabilitarTodosComboBoxes();
        }

        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            bool horarioDisponivel = VerificarDisponibilidade();
            bool produtosDisponiveis = VerificarProdutosMassagem();

            descricaoConsulta = txtDescricaoConsulta.Text;
            tipoDaConsulta = cmbTipoConsulta.Text;

            if (string.IsNullOrWhiteSpace(descricaoConsulta))
            {
                MessageBox.Show("Adicione uma descrição para a consulta", "Descrição não inserida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbTipoConsulta.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo da consulta", "Tipo não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (horarioDisponivel && produtosDisponiveis)
                {


                    FormProcurarCliente formProcurarCliente = new FormProcurarCliente(this);
                    formProcurarCliente.TerapiaSelecionada = this.terapiaSelecionada;
                    formProcurarCliente.DataSelecionada = this.dataSelecionada.ToString("dd/MM/yyyy");
                    formProcurarCliente.HoraSelecionada = $"{this.horaSelecionada.Hours:D2}:{this.horaSelecionada.Minutes:D2}";
                    formProcurarCliente.DataHoraSelecionada = this.dataHoraSelecionada;
                    formProcurarCliente.DescricaoConsulta = this.descricaoConsulta;
                    formProcurarCliente.TipoConsulta = this.tipoDaConsulta;
                    formProcurarCliente.Show();
                    this.Hide();
                }
            }

        }

        private void FormEscolhaServico_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
