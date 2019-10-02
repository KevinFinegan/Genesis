using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Skinning = CommonDXFunctions.SkinFunctions;


namespace GenesisGUI
{
    public partial class MDIMain : DevExpress.XtraEditors.XtraForm
    {
        public static g g = new g();

        public MDIMain() {
            InitializeComponent();

            this.mnuOpenWindows.MouseDown += new MouseEventHandler(this.mnuOpenWindows_MouseDown);

            SetSkinItemsCreate();

            Skinning.SetSkin(this, g.DefaultSkin);
            Skinning.SetHeadingsToBold(this);
        }

        private void ShowNewForm(object sender, EventArgs e) {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Show();
        }



        private void mnuExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void mnuMain_Click(object sender, EventArgs e) {
            //Load the main dashboard
            xfrmMainDashboard frm = new xfrmMainDashboard();
            ShowForm(frm);
        }

        private void mnuSearchCustomers_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The Search " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuSearchOrders_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The Search " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuNewCustomer_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The New " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuNewOrder_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The New " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuQuickFindCustomer_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The Quick Find " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuQuickFindOrder_Click(object sender, EventArgs e) {
            XtraMessageBox.Show("The Quick Find " + sender.ToString()  +  " screen is not available in this version of Genesis Demo", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuOpenWindows_MouseDown(object sender, MouseEventArgs e) {
            RefreshOpenWindowsList(e);
        }

        internal void ShowForm(IGenesisGUIForm frm){
            this.Cursor = Cursors.WaitCursor;

            ((Form)frm).MdiParent = this;
            ((Form)frm).Visible = false;

            frm.GUIParent = this;
        
            frm.Id = g.MaxFormId;
            frm.SetDescription();

            g.MaxFormId ++;
            g.FormsAdd(frm);
            g.ActiveForm = frm;
    
            ((Form)frm).Show();

            if (g.Forms.Count == 1){
                ((Form)frm).WindowState = FormWindowState.Minimized;
                ((Form)frm).WindowState = FormWindowState.Maximized;
            }

            //RefreshOpenWindowsList();

            this.Cursor = Cursors.Default;
        }
               
        private void OpenWindowsEventHandler(object sender, EventArgs e){
            foreach (IGenesisGUIForm frm in g.Forms){
                if (frm.Id == System.Convert.ToInt32(((ToolStripMenuItem)sender).Tag)){
                    ((Form)frm).BringToFront();
                    break;
                }
            }
            mnuOpenWindows.DropDownItems.Clear();            
            mnuOpenWindows.DropDown.Close();
        }

        private void RefreshOpenWindowsList(MouseEventArgs e){
            mnuOpenWindows.DropDownItems.Clear();

            foreach(IGenesisGUIForm frm in g.Forms){
                var tsi = new ToolStripMenuItem();
                tsi.Text = frm.Description;
                tsi.Tag = frm.Id;
                tsi.MouseDown += OpenWindowsEventHandler;
                
                mnuOpenWindows.DropDownItems.Add(tsi);

                Point p = this.PointToScreen(e.Location);
                mnuOpenWindows.DropDown.Show(p);
            }
        }


        private void SetSkinItemsCreate(){
            if (mnuSetSkin.DropDownItems.Count == 0){
                foreach (SkinContainer cnt in SkinManager.Default.Skins){
                    ToolStripMenuItem mnu = new ToolStripMenuItem(cnt.SkinName, null, new System.EventHandler(onSkinNameClick));

                    mnuSetSkin.DropDownItems.Add(mnu);
                }
            }
        }

        private void onSkinNameClick(object sender, EventArgs e) {
            g.DefaultSkin = sender.ToString();

            Skinning.SetSkin(this, g.DefaultSkin);
        }
    }
}
