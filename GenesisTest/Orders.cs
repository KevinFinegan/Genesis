using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bus = GenesisBusiness;

namespace GenesisTest
{
    [TestClass]
    public class Orders
    {
        [TestMethod]
        public void SelectAllOrders() {

            Bus.Orders orders = new Bus.Orders();

            SortedDictionary<System.Guid, GenesisBusiness.Order> dict = orders.SelectAll();

            if(dict == null || dict.Count == 0) {
                Assert.Fail("No Orders returned");

            }
        }

        [TestMethod]
        public void InsertAndDelete() {

            Guid customerId = Guid.Parse("88A96958-A302-4913-9ADC-1997B49C7571");
            string referenceNumber = "8";
            decimal orderValue = 10.2m;

            Bus.Order order = new Bus.Order();

            Guid orderId = order.Insert(customerId, referenceNumber, orderValue);

            order.Delete(orderId);
        }


    }
}
