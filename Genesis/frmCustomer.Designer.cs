namespace GenesisGUI
{
    partial class frmCustomer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpData = new DevExpress.XtraEditors.GroupControl();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblLastName = new DevExpress.XtraEditors.LabelControl();
            this.lblFirstName = new DevExpress.XtraEditors.LabelControl();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.grpActions = new DevExpress.XtraEditors.GroupControl();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).BeginInit();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpActions)).BeginInit();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtLastName);
            this.grpData.Controls.Add(this.txtFirstName);
            this.grpData.Controls.Add(this.txtId);
            this.grpData.Controls.Add(this.lblLastName);
            this.grpData.Controls.Add(this.lblFirstName);
            this.grpData.Controls.Add(this.lblId);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(690, 355);
            this.grpData.TabIndex = 0;
            this.grpData.Text = "Data";
            // 
            // txtLastName
            // 
            this.txtLastName.AllowDrop = true;
            this.txtLastName.Enabled = false;
            this.txtLastName.Location = new System.Drawing.Point(82, 67);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLastName.Properties.Appearance.Options.UseBackColor = true;
            this.txtLastName.Size = new System.Drawing.Size(114, 20);
            this.txtLastName.TabIndex = 7;
            this.txtLastName.Tag = "";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AllowDrop = true;
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Location = new System.Drawing.Point(82, 44);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFirstName.Size = new System.Drawing.Size(114, 20);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Tag = "";
            // 
            // txtId
            // 
            this.txtId.AllowDrop = true;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(82, 21);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtId.Properties.Appearance.Options.UseBackColor = true;
            this.txtId.Size = new System.Drawing.Size(359, 20);
            this.txtId.TabIndex = 5;
            this.txtId.Tag = "";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(12, 69);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(50, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(13, 47);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(51, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(13, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(11, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.cmdCancel);
            this.grpActions.Controls.Add(this.cmdSave);
            this.grpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpActions.Location = new System.Drawing.Point(0, 355);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(690, 51);
            this.grpActions.TabIndex = 1;
            this.grpActions.Text = "Actions";
            // 
            // cmdCancel
            // 
            this.cmdCancel.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmdCancel.Location = new System.Drawing.Point(82, 23);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmdSave.Location = new System.Drawing.Point(5, 23);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "Save";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 406);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpActions);
            this.Name = "frmCustomer";
            this.Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).EndInit();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpActions)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpData;
        private DevExpress.XtraEditors.GroupControl grpActions;
        private DevExpress.XtraEditors.LabelControl lblLastName;
        private DevExpress.XtraEditors.LabelControl lblFirstName;
        private DevExpress.XtraEditors.LabelControl lblId;
        public DevExpress.XtraEditors.TextEdit txtLastName;
        public DevExpress.XtraEditors.TextEdit txtFirstName;
        internal DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdSave;
    }
}