namespace GenesisGUI
{
    partial class xfrmMainDashboard
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
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.splLeftTopBottom2 = new DevExpress.XtraEditors.SplitterControl();
            this.hp2 = new CommonUserControls.ucHeadedPanel();
            this.splLeftTopBottom1 = new DevExpress.XtraEditors.SplitterControl();
            this.hp1Top = new CommonUserControls.ucHeadedPanel();
            this.splLeftRight = new DevExpress.XtraEditors.SplitterControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.splLeftTopBottom2);
            this.pnlLeft.Controls.Add(this.hp2);
            this.pnlLeft.Controls.Add(this.splLeftTopBottom1);
            this.pnlLeft.Controls.Add(this.hp1Top);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 607);
            this.pnlLeft.TabIndex = 0;
            // 
            // splLeftTopBottom2
            // 
            this.splLeftTopBottom2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splLeftTopBottom2.Location = new System.Drawing.Point(2, 207);
            this.splLeftTopBottom2.Name = "splLeftTopBottom2";
            this.splLeftTopBottom2.Size = new System.Drawing.Size(196, 5);
            this.splLeftTopBottom2.TabIndex = 3;
            this.splLeftTopBottom2.TabStop = false;
            // 
            // hp2
            // 
            this.hp2.BuddySplitter = null;
            this.hp2.Dock = System.Windows.Forms.DockStyle.Top;
            this.hp2.HeaderBackColor = System.Drawing.Color.Transparent;
            this.hp2.HeaderText = "New";
            this.hp2.Images = CommonUserControls.Enums.ImageSet.TripleArrow;
            this.hp2.InitialState = CommonUserControls.Enums.State.Expanded;
            this.hp2.Location = new System.Drawing.Point(2, 107);
            this.hp2.Name = "hp2";
            this.hp2.ReducedHeight = 17;
            this.hp2.ReducedWidth = 40;
            this.hp2.ReductionDirection = CommonUserControls.Enums.Direction.UpDown;
            this.hp2.Size = new System.Drawing.Size(196, 100);
            this.hp2.TabIndex = 1;
            // 
            // splLeftTopBottom1
            // 
            this.splLeftTopBottom1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splLeftTopBottom1.Location = new System.Drawing.Point(2, 102);
            this.splLeftTopBottom1.Name = "splLeftTopBottom1";
            this.splLeftTopBottom1.Size = new System.Drawing.Size(196, 5);
            this.splLeftTopBottom1.TabIndex = 2;
            this.splLeftTopBottom1.TabStop = false;
            // 
            // hp1Top
            // 
            this.hp1Top.BuddySplitter = null;
            this.hp1Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.hp1Top.HeaderBackColor = System.Drawing.Color.Transparent;
            this.hp1Top.HeaderText = "Search";
            this.hp1Top.Images = CommonUserControls.Enums.ImageSet.TripleArrow;
            this.hp1Top.InitialState = CommonUserControls.Enums.State.Expanded;
            this.hp1Top.Location = new System.Drawing.Point(2, 2);
            this.hp1Top.Name = "hp1Top";
            this.hp1Top.ReducedHeight = 17;
            this.hp1Top.ReducedWidth = 40;
            this.hp1Top.ReductionDirection = CommonUserControls.Enums.Direction.UpDown;
            this.hp1Top.Size = new System.Drawing.Size(196, 100);
            this.hp1Top.TabIndex = 0;
            // 
            // splLeftRight
            // 
            this.splLeftRight.Location = new System.Drawing.Point(200, 0);
            this.splLeftRight.Name = "splLeftRight";
            this.splLeftRight.Size = new System.Drawing.Size(5, 607);
            this.splLeftRight.TabIndex = 1;
            this.splLeftRight.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(205, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(726, 607);
            this.pnlMain.TabIndex = 2;
            // 
            // xfrmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 607);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.splLeftRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "xfrmMainDashboard";
            this.ShowMdiChildCaptionInParentTitle = true;
            this.Text = "Dashboard-Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.SplitterControl splLeftRight;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private CommonUserControls.ucHeadedPanel hp2;
        private DevExpress.XtraEditors.SplitterControl splLeftTopBottom2;
        private DevExpress.XtraEditors.SplitterControl splLeftTopBottom1;
        private CommonUserControls.ucHeadedPanel hp1Top;
    }
}