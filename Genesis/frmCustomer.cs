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

using Bus = GenesisBusiness;
using Models = GenesisModels;
using VF = CommonFunctions.ValidationFunctions;

namespace GenesisGUI
{
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        private string _originalFirstName;
        private string _originalSurname;

        public bool SuppressMessages{get; set; }        
        public Guid CustomerId{ get; set;}
        
        public delegate void EventHandler(Object sender, CustomerSaveEventArgs e);
        public event EventHandler CustomerSave;

        protected virtual void OnCustomerSave(Object sender, CustomerSaveEventArgs e) {
            CustomerSave?.Invoke(this, e);
        }

        public frmCustomer() {
            InitializeComponent();
            
            //KF:  I put in the ID because users often want it and know the IDs of their customers (maybe not with a guid though).  They might want to copy it somewhere else.
            txtId.Enabled = true;
            txtId.ReadOnly = true;
            txtFirstName.Properties.MaxLength = 50;
            txtFirstName.Enabled = true;
            txtFirstName.ReadOnly = false;
            txtLastName.Properties.MaxLength = 50;
            txtLastName.Enabled = true;
            txtFirstName.ReadOnly = false;
        }

        public void LoadData() {
            Bus.Customer customer = new Bus.Customer();

            if(this.CustomerId != null && this.CustomerId != Guid.Empty ){

                customer = customer.Select(this.CustomerId);

                txtId.Text = customer.Model.Id.ToString();
                txtFirstName.Text = customer.Model.FirstName;
                txtLastName.Text = customer.Model.LastName;

                _originalFirstName  = customer.Model.FirstName; 
                _originalSurname = customer.Model.LastName;
            }
        }

        private Bus.Customer ModelFromView() {
            Models.Customer modCustomer = new Models.Customer();
            modCustomer.Id = this.CustomerId;
            modCustomer.FirstName = txtFirstName.Text;
            modCustomer.LastName = txtLastName.Text;

            Bus.Customer customer = new Bus.Customer(modCustomer);
                       
            return customer;
        }

        private bool HasChanged() {
            //KF If there were more than two fields I'd implement ICompareable or something similar in the business class.  It would be in the business layer so that the 
            //models can all be auto-generated without losing code
            if(txtFirstName.Text != _originalFirstName ||
               txtLastName.Text != _originalSurname) {
                return true;
            } else {
                return false;
            }
        }

        public bool ValidateData(Bus.Customer customer) {
            //KF There are lots of ways and places of doing these checks
            //Generally I put the screen logic here, that is mandatory fields are filled in and similar, anything that only needs the data on the screen
            //Then any business logic goes into the business layer, only it loads up other data from outside the screen
            //the validation can (and should) also go into the database so that any scripts also have it follow the business rules
            //However the front end shouldn't just handle the database exceptions it should do it's own validation and give the user a sensible
            //error message

            StringBuilder sb = new StringBuilder();
            
            VF.RequiredFieldHasText(txtFirstName, lblFirstName, sb);
            VF.RequiredFieldHasText(txtLastName, lblLastName, sb);

            customer.Validate(sb);

            if(sb.ToString() != "") {
                if(!this.SuppressMessages)
                    XtraMessageBox.Show(sb.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else{
                return true;
            }
        }

        public bool SaveData() {
            Bus.Customer customer = ModelFromView();

            if(this.HasChanged()){
                if(this.ValidateData(customer)){

                    try {
                        customer.Update();                

                        CustomerSaveEventArgs args = new CustomerSaveEventArgs();
                        args.CustomerId = this.CustomerId;
                        args.NewFullName = customer.Model.LastName + ", " + customer.Model.FirstName;
                        OnCustomerSave(this, args);
                
                        customer = null;

                        return true;

                    } catch(Exception x){
                        //KF: This is only very basic exception handling, a full solution would look for inner exceptions, particular types and much more
                        g.LogEvent("Save Error: " +  x.Message, EventLogging.Events.EventLevel.Exception);
                    }
                }
                return false;
            } else {
                //If nothing to do return true
                return true;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e) {
            if(SaveData()){
                //KF could split this out to a "No changes made" or Saved
                XtraMessageBox.Show("Customer Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) {
            //KF Uncomment this to test the unhandled exception
            //Exception x = new Exception("Dummy");
            //throw(x);
           
            this.Close();
        }
    }
}