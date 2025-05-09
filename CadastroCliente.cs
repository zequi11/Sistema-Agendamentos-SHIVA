using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaDeAgendementos
{
    public partial class CadastroCliente: Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
    
            cmbEstadoCliente.Items.Add("AC");
            cmbEstadoCliente.Items.Add("AL");
            cmbEstadoCliente.Items.Add("AP");
            cmbEstadoCliente.Items.Add("AM");
            cmbEstadoCliente.Items.Add("BA");
            cmbEstadoCliente.Items.Add("CE");
            cmbEstadoCliente.Items.Add("DF");
            cmbEstadoCliente.Items.Add("ES");
            cmbEstadoCliente.Items.Add("GO");
            cmbEstadoCliente.Items.Add("MA");
            cmbEstadoCliente.Items.Add("MT");
            cmbEstadoCliente.Items.Add("MS");
            cmbEstadoCliente.Items.Add("MG");
            cmbEstadoCliente.Items.Add("PA");
            cmbEstadoCliente.Items.Add("PB");
            cmbEstadoCliente.Items.Add("PR");
            cmbEstadoCliente.Items.Add("PE");
            cmbEstadoCliente.Items.Add("PI");
            cmbEstadoCliente.Items.Add("RJ");
            cmbEstadoCliente.Items.Add("RN");
            cmbEstadoCliente.Items.Add("RS");
            cmbEstadoCliente.Items.Add("RO");
            cmbEstadoCliente.Items.Add("RR");
            cmbEstadoCliente.Items.Add("SC");
            cmbEstadoCliente.Items.Add("SP");
            cmbEstadoCliente.Items.Add("SE");
            cmbEstadoCliente.Items.Add("TO");
            cmbEstadoCivil.Items.Add("Solteiro(a)");
            cmbEstadoCivil.Items.Add("Casado(a)");
            cmbEstadoCivil.Items.Add("Divorciado(a)");
            cmbEstadoCivil.Items.Add("Separado(a) Juridicamente");
            cmbEstadoCivil.Items.Add("Viúvo(a)");
        }

        //Group Box - Dados do Cliente
        string nomeCliente;
        string dataNascimento;
        string rgCliente;
        string cpfCliente;
        string EstadoCivilCliente;

        //Group Box - Endereço do Cliente
        string enderecoCliente;
        string numeroEnderecoCliente;
        string compEnderecoCliente;
        string cepCliente;
        string bairroCliente;
        string cidadeCliente;
        string estadoCliente;

        //Group Box - Contatos do Cliente
        string contatoCelular1;
        string contatoCelular2;
        string contatoTelefone1;
        string contatoTelefone2;
        string contatoEmail;
        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            //Group Box - Dados do Cliente
            nomeCliente = txtNomeCliente.Text;
            dataNascimento = dttmCliente.Value.ToShortDateString();
            rgCliente = txtRgCliente.Text;
            cpfCliente = txtCpfClinte.Text;
            EstadoCivilCliente = cmbEstadoCivil.Text;

            //Group Box - Endereço do Cliente
            string enderecoCliente = txtEndereco.Text;
            string numeroEnderecoCliente = txtNumeroEndereco.Text;
            string compEnderecoCliente = txtComplementoCasa.Text;
            string cepCliente = txtCepCliente.Text;
            string bairroCliente = txtBairroCliente.Text;
            string cidadeCliente = txtCidadeCliente.Text;
            string estadoCliente = cmbEstadoCliente.Text;

            //Group Box - Contatos do Cliente
            string contatoCelular1 = txtNmroCelular1.Text;
            string contatoCelular2 = txtNmroCelular2.Text;
            string contatoTelefone1 = txtNmroTelefone1.Text;
            string contatoTelefone2 = txtNmroTelefone2.Text;
            string contatoEmail = txtContatoEmail.Text;

            if (!string.IsNullOrWhiteSpace(txtNomeCliente.Text) && !string.IsNullOrWhiteSpace(dttmCliente.ToString()) &&
                !string.IsNullOrWhiteSpace(txtRgCliente.Text) && !string.IsNullOrWhiteSpace(txtCpfClinte.Text) &&
                !string.IsNullOrWhiteSpace(txtEndereco.Text) && !string.IsNullOrWhiteSpace(txtNumeroEndereco.Text) &&
                !string.IsNullOrWhiteSpace(txtCepCliente.Text) && !string.IsNullOrWhiteSpace(txtBairroCliente.Text) &&
                !string.IsNullOrWhiteSpace(txtCidadeCliente.Text) && !string.IsNullOrWhiteSpace(cmbEstadoCliente.ToString()) &&
                !string.IsNullOrWhiteSpace(txtNmroCelular1.Text) && !string.IsNullOrWhiteSpace(txtContatoEmail.Text))
            {
                string connectionString = "Server=localhost;Database=SistemaAgendamento;User Id=sa;Password=123456;TrustServerCertificate=True;";
                string query = @"
            INSERT INTO Cliente 
            (nome_cliente, nascimento_cliente, rg_cliente, cpf_cliente, 
             logradouro_cliente, numero_cliente, complemento_cliente, 
             bairro_cliente, cep_cliente, cidade_cliente, uf_cliente, 
             estadoCivil_cliente, contato1_cliente, contato2_cliente, 
             contatoEmergencia_cliente) 
            VALUES 
            (@nome, @nasc, @rg, @cpf, 
             @endereco, @numero, @complemento, 
             @bairro, @cep, @cidade, @uf, 
             @estadoCivil, @contato1, @contato2, @contatoEmergencia)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nomeCliente);
                    cmd.Parameters.AddWithValue("@nasc", dataNascimento);
                    cmd.Parameters.AddWithValue("@rg", rgCliente);
                    cmd.Parameters.AddWithValue("@cpf", cpfCliente);
                    cmd.Parameters.AddWithValue("@endereco", enderecoCliente);
                    cmd.Parameters.AddWithValue("@numero", numeroEnderecoCliente);
                    cmd.Parameters.AddWithValue("@complemento", (object)compEnderecoCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@bairro", bairroCliente);
                    cmd.Parameters.AddWithValue("@cep", cepCliente);
                    cmd.Parameters.AddWithValue("@cidade", cidadeCliente);
                    cmd.Parameters.AddWithValue("@uf", estadoCliente);
                    cmd.Parameters.AddWithValue("@estadoCivil", EstadoCivilCliente); // ou pega de outro campo, se tiver
                    cmd.Parameters.AddWithValue("@contato1", contatoCelular1);
                    cmd.Parameters.AddWithValue("@contato2", (object)contatoCelular2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@contatoEmergencia", contatoTelefone1);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cliente cadastrado com sucesso!");
                        lstbResumoCadastro.Items.Add($"Nome: {nomeCliente} - Data de Nascimento: {dataNascimento} - CPF: {cpfCliente} - Contato: {contatoCelular1} - Estado: {estadoCliente}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Opa! Tem campo obrigatório vazio. Dá uma olhada antes de prosseguir.", "Campos Não Preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeCliente.Clear();
            txtRgCliente.Clear();
            txtCpfClinte.Clear();
            txtEndereco.Clear();
            txtNumeroEndereco.Clear();
            txtComplementoCasa.Clear();
            txtCepCliente.Clear();
            txtBairroCliente.Clear();
            txtCidadeCliente.Clear();
            txtNmroCelular1.Clear();
            txtNmroCelular2.Clear();
            txtNmroTelefone1.Clear();
            txtNmroTelefone2.Clear();
            txtContatoEmail.Clear();
            txtNomeCliente.Focus();
            nomeCliente = null;
            dataNascimento = null;
            rgCliente = null;
            cpfCliente = null;
            enderecoCliente = null;
            numeroEnderecoCliente = null;
            compEnderecoCliente = null;
            bairroCliente = null;
            cepCliente = null;
            cidadeCliente = null;
            estadoCliente = null;
            EstadoCivilCliente = null;
            contatoCelular1 = null;
            contatoCelular2 = null;
            contatoTelefone1 = null;
        }
    }
}
