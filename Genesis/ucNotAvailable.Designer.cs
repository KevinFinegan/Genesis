namespace GenesisGUI
{
    partial class ucNotAvailable
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblNotAvailable = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblNotAvailable
            // 
            this.lblNotAvailable.Location = new System.Drawing.Point(117, 127);
            this.lblNotAvailable.Name = "lblNotAvailable";
            this.lblNotAvailable.Size = new System.Drawing.Size(280, 13);
            this.lblNotAvailable.TabIndex = 0;
            this.lblNotAvailable.Text = "This screen is not available in this version of Genesis Demo";
            // 
            // ucNotAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNotAvailable);
            this.Name = "ucNotAvailable";
            this.Size = new System.Drawing.Size(612, 548);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNotAvailable;
    }
}
