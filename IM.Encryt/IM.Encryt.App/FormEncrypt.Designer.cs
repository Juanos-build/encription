namespace IM.Encryt.App
{
    partial class FormEncrypt
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar recursos.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            label1 = new Label();
            txtSecretKey = new TextBox();
            label2 = new Label();
            txtText = new TextBox();
            txtResult = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            groupBox1 = new GroupBox();
            rdRSA = new RadioButton();
            rdModern = new RadioButton();
            rdLegacy = new RadioButton();
            txtPublicKey = new TextBox();
            label3 = new Label();

            groupBox1.SuspendLayout();
            SuspendLayout();

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 65);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Input Text";

            // 
            // txtSecretKey
            // 
            txtSecretKey.Location = new Point(95, 25);
            txtSecretKey.Name = "txtSecretKey";
            txtSecretKey.Size = new Size(280, 23);
            txtSecretKey.TabIndex = 1;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Secret Key";

            // 
            // txtText
            // 
            txtText.Location = new Point(95, 62);
            txtText.Name = "txtText";
            txtText.Size = new Size(500, 23);
            txtText.TabIndex = 3;

            // 
            // txtResult
            // 
            txtResult.Location = new Point(18, 145);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(577, 180);
            txtResult.TabIndex = 4;

            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(18, 102);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(100, 30);
            btnEncrypt.TabIndex = 5;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;

            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(124, 102);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(100, 30);
            btnDecrypt.TabIndex = 6;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;

            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdRSA);
            groupBox1.Controls.Add(rdModern);
            groupBox1.Controls.Add(rdLegacy);
            groupBox1.Location = new Point(390, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(205, 42);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Encryption Mode";

            // 
            // rdLegacy
            // 
            rdLegacy.AutoSize = true;
            rdLegacy.Location = new Point(10, 18);
            rdLegacy.Name = "rdLegacy";
            rdLegacy.Size = new Size(67, 19);
            rdLegacy.TabIndex = 0;
            rdLegacy.Text = "Legacy";
            rdLegacy.UseVisualStyleBackColor = true;

            // 
            // rdModern
            // 
            rdModern.AutoSize = true;
            rdModern.Checked = true;
            rdModern.Location = new Point(83, 18);
            rdModern.Name = "rdModern";
            rdModern.Size = new Size(73, 19);
            rdModern.TabIndex = 1;
            rdModern.TabStop = true;
            rdModern.Text = "Modern";
            rdModern.UseVisualStyleBackColor = true;

            // 
            // rdRSA
            // 
            rdRSA.AutoSize = true;
            rdRSA.Location = new Point(162, 18);
            rdRSA.Name = "rdRSA";
            rdRSA.Size = new Size(47, 19);
            rdRSA.TabIndex = 2;
            rdRSA.Text = "RSA";
            rdRSA.UseVisualStyleBackColor = true;
            rdRSA.CheckedChanged += rdRSA_CheckedChanged;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 338);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 8;
            label3.Text = "Public Key";

            // 
            // txtPublicKey
            // 
            txtPublicKey.Location = new Point(18, 360);
            txtPublicKey.Multiline = true;
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.ScrollBars = ScrollBars.Vertical;
            txtPublicKey.Size = new Size(577, 120);
            txtPublicKey.TabIndex = 9;

            // 
            // FormEncrypt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(615, 500);
            Controls.Add(label3);
            Controls.Add(txtPublicKey);
            Controls.Add(groupBox1);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtResult);
            Controls.Add(txtText);
            Controls.Add(label2);
            Controls.Add(txtSecretKey);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormEncrypt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Encrypt / Decrypt";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSecretKey;
        private Label label2;
        private TextBox txtText;
        private TextBox txtResult;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private GroupBox groupBox1;
        private RadioButton rdLegacy;
        private RadioButton rdModern;
        private RadioButton rdRSA;
        private TextBox txtPublicKey;
        private Label label3;
    }
}
