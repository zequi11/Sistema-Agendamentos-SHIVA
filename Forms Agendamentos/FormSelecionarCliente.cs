using Microsoft.Data.SqlClient;
using SistemaDeAgendementos;
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
    public partial class FormSelecionarCliente : Form
    {
        public string nomeClienteProcurado;
        public string cpfClienteProcurado;
        public string clienteSelecionado;

        public int idTerapia;
        public int idCliente;

        public string TerapiaSelecionada { get; set; }
        public string DataSelecionada { get; set; }
        public string HoraSelecionada { get; set; }
        public DateTime DataHoraSelecionada { get; set; }
        public string DescricaoConsulta { get; set; }
        public string TipoConsulta { get; set; }

        FormEscolhaServico formEscolhaServico;
        public FormSelecionarCliente(FormEscolhaServico formAnterior)
        {
            InitializeComponent();
            this.formEscolhaServico = formAnterior;
        }

        private void FormProcurarCliente_Load(object sender, EventArgs e)
        {

        }

        public bool BuscarClientePorCPF(string cpf)
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                listBox1.Items.Clear();

                conn.Open();

                string query = @"SELECT nome_cliente, cpf_cliente FROM Cliente WHERE cpf_cliente = @cpf";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nomeClienteProcurado = reader["nome_cliente"].ToString();
                            cpfClienteProcurado = reader["cpf_cliente"].ToString();


                            listBox1.Items.Add($"{nomeClienteProcurado} | {cpfClienteProcurado}");

                            MessageBox.Show("Cliente encontrado no sistema.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
        }

        public string FormatarCPF(string cpf)
        {
            if (cpf.Length == 11)
            {
                return cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
            }
            return cpf;
        }

        public void buscarCLienteNome()
        {
            listBox1.Items.Clear();

            string nomeBusca = txtNome.Text.Trim();

            if (string.IsNullOrEmpty(nomeBusca))
            {
                MessageBox.Show("Por favor, insira o nome para a busca.");
                return;
            }


            SqlConnection conn = new SqlConnection(Conexao.stringConexao);

            try
            {

                conn.Open();

                string query = @"
                SELECT nome_cliente, cpf_cliente
                FROM Cliente
                WHERE nome_cliente LIKE @NomeBusca + '%';";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NomeBusca", nomeBusca);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nomeCliente = reader["nome_cliente"].ToString();
                    string cpfCliente = reader["cpf_cliente"].ToString();

                    string cpfFormatado = FormatarCPF(cpfCliente);

                    listBox1.Items.Add($"Nome: {nomeCliente} | CPF: {cpfFormatado}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar no banco de dados: " + ex.Message);
            }
            finally
            {

                conn.Close();
            }
        }

        public void buscarIdTerapia()
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                conn.Open();

                string query = @"SELECT id_terapia FROM Terapia WHERE nome_terapia = @nome";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", TerapiaSelecionada);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        idTerapia = Convert.ToInt32(resultado);
                    }
                }
            }
        }

        public void buscarIdCliente()
        {
            using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
            {
                conn.Open();

                string nomeExtraido = clienteSelecionado.Split('|')[0].Replace("Nome:", "").Trim();

                string query = @"SELECT id_cliente FROM Cliente WHERE nome_cliente = @nome";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeExtraido);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        idCliente = Convert.ToInt32(resultado);
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado. Verifique o nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void inserirAgendamento()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao.stringConexao))
                {
                    conn.Open();

                    string queryInserirConsulta = @"
                    INSERT INTO Consulta (id_cliente_consulta, id_terapia_consulta, dataHora_consulta, tipo_consulta, descricao_consulta)
                    VALUES (@idCliente, @idTerapia, @dataHora, @tipo, @descricao)";

                    using (SqlCommand cmd = new SqlCommand(queryInserirConsulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        cmd.Parameters.AddWithValue("@idTerapia", idTerapia);
                        cmd.Parameters.AddWithValue("@dataHora", DataHoraSelecionada);
                        cmd.Parameters.AddWithValue("@tipo", TipoConsulta);
                        cmd.Parameters.AddWithValue("@descricao", DescricaoConsulta);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Agendamento realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum agendamento foi inserido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erro ao inserir agendamento no banco de dados:\n{ex.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void confirmarAgendamento()
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clienteSelecionado = listBox1.SelectedItem.ToString();

            if (MessageBox.Show($"Confirmar agendamento de {TerapiaSelecionada} para {clienteSelecionado} em {DataSelecionada} às {HoraSelecionada}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                buscarIdCliente();
                buscarIdTerapia();
                inserirAgendamento();
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string cpfDigitado = txtCpf.Text.Trim();

            if (string.IsNullOrEmpty(cpfDigitado))
            {
                MessageBox.Show("Digite um CPF.", "CPF não informado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BuscarClientePorCPF(cpfDigitado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buscarCLienteNome();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            confirmarAgendamento();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            formEscolhaServico.Show();
            this.Hide();
        }
    }
}

