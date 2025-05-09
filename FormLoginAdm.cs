namespace SistemaDeAgendementos
{
    public partial class FormLoginAdm : Form
    {
        private int contadorTentativas = 0;
        private const int TentativasMaximas = 3;
        private System.Windows.Forms.Timer temporizadorBloqueio;

        public FormLoginAdm()
        {
            InitializeComponent();

            temporizadorBloqueio = new System.Windows.Forms.Timer();
            temporizadorBloqueio.Interval = 30000;
            temporizadorBloqueio.Tick += TemporizadorBloqueio_Tick;

        }

        private void FormLoginAdm_Load(object sender, EventArgs e)
        {

        }

        private void loginAdm()
        {

            string senhaCorreta = "12345";
            string usuarioCorreto = "12345";


            if (txtSenhaAdmin.Text == senhaCorreta && txtUserAdmin.Text == usuarioCorreto)
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
                this.Hide();

            }
            else
            {

                contadorTentativas++;

                if (contadorTentativas >= TentativasMaximas)
                {

                    MessageBox.Show("Você excedeu o número máximo de tentativas. Tente novamente em 30 segundos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = false;
                    temporizadorBloqueio.Start();
                }
                else
                {

                    MessageBox.Show($"Usuário ou senha incorretos. Tentativas restantes: {TentativasMaximas - contadorTentativas}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtSenhaAdmin.Clear();
                    txtUserAdmin.Clear();
                    txtUserAdmin.Focus();
                }

               
            }
        }

        private void TemporizadorBloqueio_Tick(object sender, EventArgs e)
        {

            temporizadorBloqueio.Stop();
            btnLogin.Enabled = true;
            contadorTentativas = 0;
            MessageBox.Show("Você pode tentar novamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loginAdm();
        }



    }
}