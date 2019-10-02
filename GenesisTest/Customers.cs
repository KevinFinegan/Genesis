using System;
using System.Collections.Generic;
using GenesisGUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bus = GenesisBusiness;

namespace GenesisTest
{
    [TestClass]
    public class Customers
    {
        //KF In a full application these tests would cover every fuction in the business layer and would be run as part of
        //the build process.

        [TestMethod]
        public void SelectAllCustomers() {
            Bus.Customers customers = new Bus.Customers();

            SortedDictionary<System.Guid, GenesisModels.Customer> dict = customers.SelectAll();

            if(dict == null || dict.Count == 0) {
                Assert.Fail("No Customers returned");
            }

            customers = null;
        }

        [TestMethod]
        public void UpdateCustomer() {
            GenesisModels.Customer modelCustomer = new GenesisModels.Customer();
            modelCustomer.Id = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571");
            modelCustomer.FirstName = "Kevin";
            modelCustomer.LastName = "Finegan";
            
            Bus.Customer customer = new Bus.Customer(modelCustomer);

            customer.Update();

            customer = null;
        }

        [TestMethod]
        public void ValidateCustomer() {
            //KF: In a full solution each piece of validation could have its own test

            frmCustomer frm = new frmCustomer();
            
            frm.CustomerId = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571");
            frm.LoadData();
            //KF: Should be able to implement a way of finding controls by name or by tag
            frm.txtFirstName.Text = "";
            frm.txtLastName.Text = "";

            GenesisModels.Customer modelCustomer = new GenesisModels.Customer();
            modelCustomer.Id = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571");
            modelCustomer.FirstName = "Kevin";
            modelCustomer.LastName = "Finegan";

            Bus.Customer customer = new Bus.Customer(modelCustomer);

            frm.SuppressMessages = true;
            Assert.IsFalse(frm.ValidateData(customer));
                        
            customer = null;
        }

        
        [TestMethod]
        public void ValidateDuplicateCustomer() {

            frmCustomer frm = new frmCustomer();
            
            frm.CustomerId = Guid.Parse("A0A21498-8538-4539-9F44-B283803AFD1C");
            frm.LoadData();
            frm.txtFirstName.Text = "Kevin";
            frm.txtLastName.Text = "Finegan";

            GenesisModels.Customer modelCustomer = new GenesisModels.Customer();
            modelCustomer.Id = Guid.Parse("A0A21498-8538-4539-9F44-B283803AFD1C");
            modelCustomer.FirstName = "Kevin";
            modelCustomer.LastName = "Finegan";

            Bus.Customer customer = new Bus.Customer(modelCustomer);

            frm.SuppressMessages = true;
            Assert.IsFalse(frm.SaveData());
                        
            customer = null;
        }

    }
}
