using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Skinning = CommonDXFunctions.SkinFunctions;
using CommonUserControls;

namespace GenesisGUI
{
    public partial class xfrmMainDashboard : DevExpress.XtraEditors.XtraForm, IGenesisGUIForm
    {
        private MDIMain _parent;
        private string _description;

        public int Id { get; set;}

        private Dictionary<string, ucHeadedPanel> _dictHeadedPanels;
        private Dictionary<string, Control> _dictSearchScreens;

        public string Description { 
            get {return _description;} 
        }

        public void SetDescription() {
            _description =  "Main Dashboard (" + this.Id.ToString() + ")";
            this.Text = _description;            
        }

        public MDIMain GUIParent { get{return _parent; } set {_parent = value; }}

        public int CompareTo(object obj) {
            if ((obj) is xfrmMainDashboard){
                if (this == (xfrmMainDashboard)obj){
                    return 0;
                } else {
                    return Id.CompareTo(obj);
                }
            } else {
                return 1;
            }
        }

        public void RemoveFormFromListOfWindows() {
            if(g.Forms.Contains(this)){
                g.Forms.Remove(this);
                if(g.ActiveForm == this){
                    g.ActiveForm = null;
                }
            }

        }
       
        public xfrmMainDashboard() {
            InitializeComponent();

            _dictHeadedPanels = new Dictionary<string, ucHeadedPanel>();
            _dictSearchScreens = new Dictionary<string, Control>();

            _dictHeadedPanels.Add("hp1Top", hp1Top);
            _dictHeadedPanels.Add("hp2", hp2);

            hp1Top.BuddySplitter = splLeftTopBottom1;
            hp2.BuddySplitter = splLeftTopBottom2;

            hp1Top.HeaderText = "Search";
            hp1Top.AddBanner("Customers");
            hp1Top.AddBanner("Orders");

            hp1Top.evBannerClicked += HandleBannerMouseClick;
            hp2.evBannerClicked += HandleBannerMouseClick;

            hp2.HeaderText = "New";
            hp2.AddBanner("Customer");
            hp2.AddBanner("Order");
        
            //hp1Top.

            Skinning.SetSkin(this, g.DefaultSkin);
            Skinning.SetHeadingsToBold(this);            

        }

        private void CustomFormClosed(object sender, FormClosedEventArgs e) {
             RemoveFormFromListOfWindows();
        }

        public void HandleBannerMouseClick(System.Object sender, System.EventArgs e){
            LoadSearch(((Label)sender).Text);

            ResetAllUnclickedBanners(sender);
        }

        public void ResetAllUnclickedBanners(System.Object sender) {
            foreach(ucHeadedPanel hp in _dictHeadedPanels.Values) {
                if(hp.Name != ((Label)sender).Parent.Name) {
                    hp.BannerLeaveAll();
                }
            }
        }

        public void LoadSearch(string searchName) {
            //KF:  in a real application this usercontrol might have been pre-loaded and cached and held in the background until the user wanted it.
            //This makes the application very fast.  It is only suitable for slow-moving data though.  Alternatively if the user has already run a search that screen
            //can be held in memory and re-displayed.  As this application uses a MDI the user can do this this for themselves.

            while(_dictSearchScreens.Values.Count > 0) {
                Control ctrl = _dictSearchScreens.Values.First();
                _dictSearchScreens.Remove(ctrl.Name);
                ctrl.Visible = false;                
                ctrl = null;
            }

            switch(searchName){
                case "Orders":
                    LoadOrdersSearch();
                    break;
                default:
                    LoadNotAvailable();
                    break;
            }

        }

        public void LoadOrdersSearch() {
            if(g.CanUser(Authorization.SecurityFunctions.ViewOrders)){
                Control ctrl = new ucOrdersSearch();
                _dictSearchScreens.Add(ctrl.Name, ctrl);
                pnlMain.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;
            } else {
                XtraMessageBox.Show("You do not have access to this screen", "Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadNotAvailable() {
            Control ctrl = new ucNotAvailable();
            _dictSearchScreens.Add(ctrl.Name, ctrl);
            pnlMain.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }

    }
}