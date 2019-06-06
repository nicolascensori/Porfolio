namespace FinalCensori
{
    partial class Config
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
            this.trackBarConfig = new System.Windows.Forms.TrackBar();
            this.iniciarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarConfig
            // 
            this.trackBarConfig.Location = new System.Drawing.Point(12, 12);
            this.trackBarConfig.Minimum = 3;
            this.trackBarConfig.Name = "trackBarConfig";
            this.trackBarConfig.Size = new System.Drawing.Size(260, 45);
            this.trackBarConfig.TabIndex = 0;
            this.trackBarConfig.Value = 3;
            // 
            // iniciarBtn
            // 
            this.iniciarBtn.Location = new System.Drawing.Point(75, 63);
            this.iniciarBtn.Name = "iniciarBtn";
            this.iniciarBtn.Size = new System.Drawing.Size(136, 23);
            this.iniciarBtn.TabIndex = 1;
            this.iniciarBtn.Text = "Iniciar juego";
            this.iniciarBtn.UseVisualStyleBackColor = true;
            this.iniciarBtn.Click += new System.EventHandler(this.iniciarBtn_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 98);
            this.Controls.Add(this.iniciarBtn);
            this.Controls.Add(this.trackBarConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Config";
            this.Text = "Configuración";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button iniciarBtn;
        public System.Windows.Forms.TrackBar trackBarConfig;
    }
}