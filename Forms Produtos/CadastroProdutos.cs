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
    public partial class CadastroProdutos : Form
    {
        public CadastroProdutos()
        {
            InitializeComponent();
        }

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {

        }

        public void CadastrarProdutos()
        {
            int consumoMensal;
            int tempoReposicao;
            double custoUnitario;
            int estoqueAtual;
            double estoqueSeguranca;
            double custoDoPedido;
            double perArmazenagem;
            double lec;
            double consumoDiario;
            double estoqueMax;
            double coberturaEstoque;

            consumoMensal = int.Parse(txtConsumoMensal.Text);
            tempoReposicao = int.Parse(txtTempoReposicao.Text);
            custoUnitario = double.Parse(txtCustoUnitario.Text);
            estoqueAtual = int.Parse(txtEstoqueAnual.Text);
            custoDoPedido = double.Parse(txtCustoPedido.Text);
            perArmazenagem = double.Parse(txtArmazenagem.Text);

            //Formula para calcular o consumo diario
            consumoDiario = consumoMensal / 30;

            //Formula Estoque de segurança
            estoqueSeguranca = consumoDiario * tempoReposicao;

            //Formula do Lec

            lec = Math.Sqrt((2 * consumoMensal * 12 * custoDoPedido) / (custoUnitario * (perArmazenagem / 100)));

            //Formula Emax
            estoqueMax = estoqueSeguranca + lec;

            //Formula cobertura estoque

            coberturaEstoque = estoqueAtual / consumoDiario;

            label7.Text = consumoDiario.ToString();
            label8.Text = estoqueSeguranca.ToString();
            label9.Text = lec.ToString();
            label10.Text = estoqueMax.ToString();
            label11.Text = coberturaEstoque.ToString();





        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarProdutos();
        }
    }
}
