namespace GenesisGUI
{
    partial class ucOrdersSearch
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
            this.gcOrders = new DevExpress.XtraGrid.GridControl();
            this.gvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReferenceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pbLoading = new DevExpress.XtraEditors.ProgressBarControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlCount = new DevExpress.XtraEditors.PanelControl();
            this.txtAge = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCount = new DevExpress.XtraEditors.TextEdit();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCount)).BeginInit();
            this.pnlCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcOrders
            // 
            this.gcOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOrders.Location = new System.Drawing.Point(0, 0);
            this.gcOrders.MainView = this.gvOrders;
            this.gcOrders.Name = "gcOrders";
            this.gcOrders.Size = new System.Drawing.Size(965, 584);
            this.gcOrders.TabIndex = 0;
            this.gcOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrders});
            this.gcOrders.Click += new System.EventHandler(this.gcOrders_Click);
            this.gcOrders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gcOrders_MouseDown);
            // 
            // gvOrders
            // 
            this.gvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReferenceNumber,
            this.colOrderValue,
            this.colOrderDate,
            this.colCustomerName});
            this.gvOrders.GridControl = this.gcOrders;
            this.gvOrders.Name = "gvOrders";
            // 
            // colReferenceNumber
            // 
            this.colReferenceNumber.Caption = "gridColumn1";
            this.colReferenceNumber.Name = "colReferenceNumber";
            this.colReferenceNumber.Visible = true;
            this.colReferenceNumber.VisibleIndex = 0;
            // 
            // colOrderValue
            // 
            this.colOrderValue.Caption = "gridColumn1";
            this.colOrderValue.Name = "colOrderValue";
            this.colOrderValue.Visible = true;
            this.colOrderValue.VisibleIndex = 1;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "gridColumn1";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 2;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "gridColumn1";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            // 
            // pbLoading
            // 
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoading.Location = new System.Drawing.Point(2, 2);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(710, 25);
            this.pbLoading.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pbLoading);
            this.pnlBottom.Controls.Add(this.pnlCount);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 584);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(965, 29);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCount
            // 
            this.pnlCount.Controls.Add(this.txtAge);
            this.pnlCount.Controls.Add(this.labelControl1);
            this.pnlCount.Controls.Add(this.txtCount);
            this.pnlCount.Controls.Add(this.lblCount);
            this.pnlCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCount.Location = new System.Drawing.Point(712, 2);
            this.pnlCount.Name = "pnlCount";
            this.pnlCount.Size = new System.Drawing.Size(251, 25);
            this.pnlCount.TabIndex = 2;
            // 
            // txtAge
            // 
            this.txtAge.AllowDrop = true;
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(171, 3);
            this.txtAge.Name = "txtAge";
            this.txtAge.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAge.Properties.Appearance.Options.UseBackColor = true;
            this.txtAge.Size = new System.Drawing.Size(75, 20);
            this.txtAge.TabIndex = 4;
            this.txtAge.Tag = "txtAge";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(132, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Loaded";
            // 
            // txtCount
            // 
            this.txtCount.AllowDrop = true;
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(51, 3);
            this.txtCount.Name = "txtCount";
            this.txtCount.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCount.Properties.Appearance.Options.UseBackColor = true;
            this.txtCount.Size = new System.Drawing.Size(75, 20);
            this.txtCount.TabIndex = 2;
            this.txtCount.Tag = "txtCount";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(6, 6);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(39, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Records";
            // 
            // ucOrdersSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcOrders);
            this.Controls.Add(this.pnlBottom);
            this.Name = "ucOrdersSearch";
            this.Size = new System.Drawing.Size(965, 613);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCount)).EndInit();
            this.pnlCount.ResumeLayout(false);
            this.pnlCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderValue;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraEditors.ProgressBarControl pbLoading;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlCount;
        internal DevExpress.XtraEditors.TextEdit txtCount;
        private DevExpress.XtraEditors.LabelControl lblCount;
        internal DevExpress.XtraEditors.TextEdit txtAge;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
