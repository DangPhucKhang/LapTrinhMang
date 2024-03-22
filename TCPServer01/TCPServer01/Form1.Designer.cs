namespace TCPServer01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbSonsoleOutput = new TextBox();
            tbIPAddress = new TextBox();
            tbPort = new TextBox();
            label1 = new Label();
            btnStartListening = new Button();
            btnSend = new Button();
            tbPayload = new TextBox();
            SuspendLayout();
            // 
            // tbSonsoleOutput
            // 
            tbSonsoleOutput.Location = new Point(12, 23);
            tbSonsoleOutput.Multiline = true;
            tbSonsoleOutput.Name = "tbSonsoleOutput";
            tbSonsoleOutput.Size = new Size(776, 311);
            tbSonsoleOutput.TabIndex = 0;
            tbSonsoleOutput.TextChanged += textBox1_TextChanged;
            // 
            // tbIPAddress
            // 
            tbIPAddress.Location = new Point(119, 372);
            tbIPAddress.Name = "tbIPAddress";
            tbIPAddress.Size = new Size(168, 23);
            tbIPAddress.TabIndex = 1;
            tbIPAddress.Text = "  192.168.1.7";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(293, 372);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(96, 23);
            tbPort.TabIndex = 2;
            tbPort.Text = "  23000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 372);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "IP / Port";
            label1.Click += label1_Click;
            // 
            // btnStartListening
            // 
            btnStartListening.Location = new Point(119, 401);
            btnStartListening.Name = "btnStartListening";
            btnStartListening.Size = new Size(270, 23);
            btnStartListening.TabIndex = 4;
            btnStartListening.Text = "Start Listening";
            btnStartListening.UseVisualStyleBackColor = true;
            btnStartListening.Click += btnStartListening_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(590, 400);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(164, 23);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // tbPayload
            // 
            tbPayload.Location = new Point(590, 371);
            tbPayload.Name = "tbPayload";
            tbPayload.Size = new Size(164, 23);
            tbPayload.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbPayload);
            Controls.Add(btnSend);
            Controls.Add(btnStartListening);
            Controls.Add(label1);
            Controls.Add(tbPort);
            Controls.Add(tbIPAddress);
            Controls.Add(tbSonsoleOutput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbSonsoleOutput;
        private TextBox tbIPAddress;
        private TextBox tbPort;
        private Label label1;
        private Button btnStartListening;
        private Button btnSend;
        private TextBox tbPayload;
    }
}
