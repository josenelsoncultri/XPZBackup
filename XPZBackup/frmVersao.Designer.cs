namespace XPZBackup
{
    partial class frmVersao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersao));
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtVersao
            // 
            this.txtVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersao.Location = new System.Drawing.Point(12, 12);
            this.txtVersao.MaxLength = 8;
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(342, 20);
            this.txtVersao.TabIndex = 0;
            this.txtVersao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVersao_KeyDown);
            this.txtVersao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVersao_KeyPress);
            // 
            // frmVersao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 45);
            this.ControlBox = false;
            this.Controls.Add(this.txtVersao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVersao";
            this.Text = "Informe a versão e pressione ENTER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVersao;
    }
}