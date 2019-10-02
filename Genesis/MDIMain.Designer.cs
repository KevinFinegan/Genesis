using System.Windows.Forms;

namespace GenesisGUI
{
    partial class MDIMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDashboards = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearchCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearchOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuickFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuickFindCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuickFindOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuSetSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmDashboards,
            this.tsmSearch,
            this.tsmNew,
            this.tsmQuickFind,
            this.mnuOpenWindows,
            this.mnuSetSkin});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.tsmFile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(35, 20);
            this.tsmFile.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // tsmDashboards
            // 
            this.tsmDashboards.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain});
            this.tsmDashboards.Name = "tsmDashboards";
            this.tsmDashboards.Size = new System.Drawing.Size(76, 20);
            this.tsmDashboards.Text = "Dashboards";
            // 
            // mnuMain
            // 
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(96, 22);
            this.mnuMain.Text = "Main";
            this.mnuMain.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // tsmSearch
            // 
            this.tsmSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSearchCustomers,
            this.mnuSearchOrders});
            this.tsmSearch.Name = "tsmSearch";
            this.tsmSearch.Size = new System.Drawing.Size(52, 20);
            this.tsmSearch.Text = "Search";
            // 
            // mnuSearchCustomers
            // 
            this.mnuSearchCustomers.Name = "mnuSearchCustomers";
            this.mnuSearchCustomers.Size = new System.Drawing.Size(125, 22);
            this.mnuSearchCustomers.Text = "Customers";
            this.mnuSearchCustomers.Click += new System.EventHandler(this.mnuSearchCustomers_Click);
            // 
            // mnuSearchOrders
            // 
            this.mnuSearchOrders.Name = "mnuSearchOrders";
            this.mnuSearchOrders.Size = new System.Drawing.Size(125, 22);
            this.mnuSearchOrders.Text = "Orders";
            this.mnuSearchOrders.Click += new System.EventHandler(this.mnuSearchOrders_Click);
            // 
            // tsmNew
            // 
            this.tsmNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewCustomer,
            this.mnuNewOrder});
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.Size = new System.Drawing.Size(40, 20);
            this.tsmNew.Text = "New";
            // 
            // mnuNewCustomer
            // 
            this.mnuNewCustomer.Name = "mnuNewCustomer";
            this.mnuNewCustomer.Size = new System.Drawing.Size(120, 22);
            this.mnuNewCustomer.Text = "Customer";
            this.mnuNewCustomer.Click += new System.EventHandler(this.mnuNewCustomer_Click);
            // 
            // mnuNewOrder
            // 
            this.mnuNewOrder.Name = "mnuNewOrder";
            this.mnuNewOrder.Size = new System.Drawing.Size(120, 22);
            this.mnuNewOrder.Text = "Order";
            this.mnuNewOrder.Click += new System.EventHandler(this.mnuNewOrder_Click);
            // 
            // tsmQuickFind
            // 
            this.tsmQuickFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuickFindCustomer,
            this.mnuQuickFindOrder});
            this.tsmQuickFind.Name = "tsmQuickFind";
            this.tsmQuickFind.Size = new System.Drawing.Size(68, 20);
            this.tsmQuickFind.Text = "Quick Find";
            // 
            // mnuQuickFindCustomer
            // 
            this.mnuQuickFindCustomer.Name = "mnuQuickFindCustomer";
            this.mnuQuickFindCustomer.Size = new System.Drawing.Size(120, 22);
            this.mnuQuickFindCustomer.Text = "Customer";
            this.mnuQuickFindCustomer.Click += new System.EventHandler(this.mnuQuickFindCustomer_Click);
            // 
            // mnuQuickFindOrder
            // 
            this.mnuQuickFindOrder.Name = "mnuQuickFindOrder";
            this.mnuQuickFindOrder.Size = new System.Drawing.Size(120, 22);
            this.mnuQuickFindOrder.Text = "Order";
            this.mnuQuickFindOrder.Click += new System.EventHandler(this.mnuQuickFindOrder_Click);
            // 
            // mnuOpenWindows
            // 
            this.mnuOpenWindows.Name = "mnuOpenWindows";
            this.mnuOpenWindows.Size = new System.Drawing.Size(91, 20);
            this.mnuOpenWindows.Text = "Open Windows";
            // 
            // mnuSetSkin
            // 
            this.mnuSetSkin.Name = "mnuSetSkin";
            this.mnuSetSkin.Size = new System.Drawing.Size(43, 20);
            this.mnuSetSkin.Text = "Skins";
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 552);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIMain";
            this.Text = "GenesisDemo";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem tsmSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchOrders;
        private System.Windows.Forms.ToolStripMenuItem tsmNew;
        private System.Windows.Forms.ToolStripMenuItem mnuNewCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuNewOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmDashboards;
        private System.Windows.Forms.ToolStripMenuItem mnuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmQuickFind;
        private System.Windows.Forms.ToolStripMenuItem mnuQuickFindCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuQuickFindOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenWindows;
        private ToolStripMenuItem mnuSetSkin;
    }
}



