using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

using DevExpress.XtraEditors;

using GF = CommonDXFunctions.GridFunctions;
using Business = GenesisBusiness;
using Grids = Genesis.GridClasses;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GenesisGUI
{
    public partial class ucOrdersSearch : DevExpress.XtraEditors.XtraUserControl
    {
        //KF: In a real application some of the basic layout and data loading code would be in a base usercontrol class and/or library functions.
        //Alternatively the code could be adjusted to use an Interface that covers all of the GridClasses and this usercontrl could be re-used for all GetAll searches.

        private BackgroundWorker _bgwLoadData; 
        private DateTime _lastLoaded;

        private System.Timers.Timer _timerProgress;
        private System.Timers.Timer _timerDataAge;
        private int _timerMaximum;
        private int _dataAgeMaximum;

        public delegate void InvokeProgressTimerDelegate();
        public delegate void InvokeDataAgeTimerDelegate();

        public ucOrdersSearch() {
            InitializeComponent();

            _bgwLoadData = new BackgroundWorker();
            _bgwLoadData.WorkerSupportsCancellation = true;
            _bgwLoadData.DoWork += bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += bgwLoadData_RunWorkerCompleted;

            //Assume that loading the data takes 1 second.  In a real project this might be a configuration taken from the database and cached.  The time used would be
            //the average (or maybe the maximum) time that a successful load of the data takes. This could be calculated from logging data.
            _timerMaximum = 100;
            //The length of time before the time turns red, the idea is to let the user know that the data is old.
            _dataAgeMaximum = 30000;

            pbLoading.Properties.Step = 1; 
            pbLoading.Properties.PercentView = true;
            pbLoading.Properties.Minimum = 0;
            pbLoading.Properties.Maximum = _timerMaximum;

            Grids.Orders.SetupGrid(gvOrders);

            
            
            LoadData();
        }
        
        private void StartProgressTimer(){
            _timerProgress = null;
            _timerProgress = new System.Timers.Timer(1);
            _timerProgress.Elapsed += ProgressEventHandler;
            _timerProgress.Enabled = true;
        }

        private void EndProgressTimer(){
            _timerProgress = null;
        }

        private void ProgressEventHandler(object sender, ElapsedEventArgs e) {
            if(pbLoading.InvokeRequired){
                txtAge.BeginInvoke(new InvokeProgressTimerDelegate(SetProgress));
            } else {
                SetProgress();
            }
        }

        private void SetProgress() {
            pbLoading.PerformStep();
            pbLoading.Update();
        }

        private void StartDataAgeTimer(){
            _timerDataAge = null;
            _timerDataAge = new System.Timers.Timer(_dataAgeMaximum);
            _timerDataAge.Elapsed += DataAgeEventHandler;
            _timerDataAge.Enabled = true;
        }

        private void EndDataAgeTimer(){
            _timerDataAge = null;
        }

        private void DataAgeEventHandler(object sender, ElapsedEventArgs e) {
            if(txtAge.InvokeRequired){
                txtAge.BeginInvoke(new InvokeDataAgeTimerDelegate(SetAgeTextboxAppearance));
            } else {
                SetAgeTextboxAppearance();
            }
        }
        
        private void SetAgeTextboxAppearance() {
            txtAge.Properties.Appearance.BackColor = Color.IndianRed;
            EndDataAgeTimer();
        }

        public object GetData() {
          StartProgressTimer();

          var busOrders = new Business.Orders();
          busOrders.SelectAll();

          var grdOrders = new Grids.Orders(busOrders);

          return grdOrders.Dictionary.Values;
        }


        public void LoadData(){
            if (!_bgwLoadData.IsBusy){
                gcOrders.DataSource = null;
                gcOrders.Enabled = false;

                _bgwLoadData.RunWorkerAsync();
            }            
        }

        private void bgwLoadData_DoWork(object sender, DoWorkEventArgs e){
            e.Result = this.GetData();
        }

        private void bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (this.IsDisposed ){
                return;
            }

            if(e.Error == null && e.Result != null){
                txtCount.Text = ((SortedDictionary<Guid, Grids.Order>.ValueCollection)e.Result).Count.ToString();
                _lastLoaded = DateTime.Now;
                
                //Set the progress bar to the end
                pbLoading.EditValue = pbLoading.Properties.Maximum;
                

                gcOrders.DataSource = null;
                gcOrders.DataSource = e.Result;
                gcOrders.Enabled = true;

                gvOrders.BestFitMaxRowCount = 10;
                gvOrders.BestFitColumns();

                txtAge.Text = _lastLoaded.ToLongTimeString();
                StartDataAgeTimer();

                this.Cursor = Cursors.Default;

            } else {
                //Log the error
                if(e.Error != null){
                    int x = 1;
                    //EH.EventLog.Events.AddExceptionWithDefaults(e.Error);                    
                }

            XtraMessageBox.Show("The data could not be displayed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GridHitInfo _MouseInfo;

        private void gcOrders_Click(object sender, EventArgs e) {
            if(g.CanUser(Authorization.SecurityFunctions.EditCustomer)){
                if(_MouseInfo != null) {
                    if(_MouseInfo.Column.Name == "colOpenCustomer" && gvOrders.SelectedRowsCount == 1) {
                        OpenCustomerForm(gvOrders.FocusedRowHandle);
                    }                
                }
            } else {
                XtraMessageBox.Show("You do not have access to this screen", "Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcOrders_MouseDown(object sender, MouseEventArgs e) {
            _MouseInfo = gvOrders.CalcHitInfo(e.Location);

        }

        private void OpenCustomerForm(int rowHandle) {
            this.Cursor = Cursors.WaitCursor;

            Grids.Order order = (Grids.Order)gvOrders.GetRow(rowHandle);

            frmCustomer frm = new frmCustomer();
            frm.CustomerId = order.CustomerId;
            frm.LoadData();
            frm.CustomerSave += CustomerHasBeenSaved;

            this.Cursor = Cursors.Default;

            frm.ShowDialog(this);
            frm.Dispose();
            frm = null;
        }

        private void CustomerHasBeenSaved(Object sender, CustomerSaveEventArgs e) {
            //Update the grid with the new data            
            
            SortedDictionary<Guid, Grids.Order>.ValueCollection data = (SortedDictionary<Guid, Grids.Order>.ValueCollection)gcOrders.DataSource;
            
            foreach(Grids.Order order in data) {
                if(order.CustomerId == e.CustomerId) {
                    order.CustomerName = e.NewFullName;
                }
            }

            //Refresh all the rows in case the data has been sorted and just the one column for speed
            for (int i = 0; i < data.Count; i++){
                gvOrders.RefreshRowCell(i, gvOrders.Columns["CustomerName"]);
            }           

        }

    }
}
