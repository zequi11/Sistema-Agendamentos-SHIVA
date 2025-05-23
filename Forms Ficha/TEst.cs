using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaDeAgendamentos
{
    public partial class TEst : Form
    {
        public TEst()
        {
            InitializeComponent();
        }

        private void TEst_Load(object sender, EventArgs e)
        {

        }

        private string GetCheckedRadioButtonText(GroupBox groupBox)
        {
            foreach (Control ctrl in groupBox.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    return rb.Text;
                }
            }
            return "Nenhuma opção selecionada";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = this.txt1.Text;
            string email = this.txt2.Text;
            string telefone = this.txt3.Text;

            string terapia = this.GetCheckedRadioButtonText(this.groupBox2);
            string yogaMeditacao = this.GetCheckedRadioButtonText(this.groupBox3);
            string aromaterapia = this.GetCheckedRadioButtonText(this.groupBox4);
            string fitoterapia = this.GetCheckedRadioButtonText(this.groupBox5);
            string meditacaoRegular = this.GetCheckedRadioButtonText(this.groupBox6);

            MessageBox.Show($"Nome: {nome}\nEmail: {email}\nTelefone: {telefone}\n" +
                $"Terapias integrativas: {terapia}\nYoga/Meditacao: {yogaMeditacao}\n" +
                $"Aromaterapia: {aromaterapia}\nFitoterapia: {fitoterapia}\nMeditação regular: {meditacaoRegular}",
                "Ficha Anamnese");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.txt1.Clear();
            this.txt2.Clear();
            this.txt3.Clear();

            foreach (GroupBox gb in new GroupBox[] { groupBox2, groupBox3, groupBox4, groupBox5, groupBox6 })
            {
                foreach (Control ctrl in gb.Controls)
                {
                    if (ctrl is RadioButton rb)
                    {
                        rb.Checked = false;
                    }
                }
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
