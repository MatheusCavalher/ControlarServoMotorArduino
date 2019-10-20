using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace ControlarServoMotor
{
    public partial class frmPrincipal : Form
    {

        SerialPort port;
        public frmPrincipal()
        {
            InitializeComponent();           
        }

        private void init()
        {
            port = new SerialPort();
            port.PortName = "COM4";
            port.BaudRate = 9600;

            try
            {
                port.Open();
                lblSituacao.Text = "Conectado";
                lblSituacao.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("1");
                //System.Threading.Thread.Sleep(500);
                port.WriteLine(Val_trackBar.Value.ToString());
                lblGraus.Text = "Graus =" + Val_trackBar.Value.ToString();
            }
        }

        private void Val_trackBar2_Scroll(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("2");
                //System.Threading.Thread.Sleep(500);
                port.WriteLine(Val_trackBar2.Value.ToString());
                lblGraus2.Text = "Graus =" + Val_trackBar2.Value.ToString();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            init();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            port.Close();
            lblSituacao.Text = "Desconectado";
            lblSituacao.BackColor = Color.Red;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port.IsOpen == true)  // se porta aberta
                port.Close();        	//fecha a porta
        }    
    }
}
