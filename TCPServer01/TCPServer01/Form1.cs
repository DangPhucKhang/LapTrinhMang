using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Text;

namespace TCPServer01
{

    public partial class Form1 : Form
    {
        TcpListener mTCPListener;
        TcpClient mTCPClient;
        Byte[] mRx;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStartListening_Click(object sender, EventArgs e)
        {
            IPAddress ipaddr;
            int nPort;

            if (!int.TryParse(tbPort.Text, out nPort))
            {
                nPort = 23000;
            }
            if (!IPAddress.TryParse(tbIPAddress.Text, out ipaddr))
            {
                MessageBox.Show("Invalid IP address supplied . ");
                return;
            }
            mTCPListener = new TcpListener(ipaddr, nPort);

            mTCPListener.Start();

            mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);

        }

        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {
                mTCPClient = tcpl.EndAcceptTcpClient(iar);
                printLine("Client connected....");

                mRx = new byte[512];
                mTCPClient.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, mTCPClient);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tcpl.EndAcceptTcpClient(iar);
        }

        void onCompleteReadFromTCPClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                nCountReadBytes = tcpc.GetStream().EndRead(iar);

                if (nCountReadBytes == 0)
                {
                    MessageBox.Show("Client disconnected. ");
                    return;
                }
                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);

                printLine(strRecv);

                mRx = new byte[512];

                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, tcpc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void printLine(string _strPrint)
        {
            tbSonsoleOutput.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbSonsoleOutput.Text = _strPrint + Environment.NewLine + tbSonsoleOutput.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] tx = new byte[512];

            if (string.IsNullOrEmpty(tbPayload.Text)) return;

            try
            {
                if(mTCPClient != null)
                {
                    if(mTCPClient.Client.Connected)
                    {
                        tx = Encoding.ASCII.GetBytes(tbPayload.Text);
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc =(TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
