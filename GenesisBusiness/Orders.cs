using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models = GenesisModels;

namespace GenesisBusiness
{
    //KF: In a real business layer I would add an Interface or abstract base class with all the standard methods, insert, update, select all, delete, etc
    //One interface for the collection class and one for the row-class.  This is why I did not use static methods

    public class Orders{
        public SortedDictionary<System.Guid, GenesisBusiness.Order> Dictionary{ get; private set;}
        
        public SortedDictionary<System.Guid, GenesisBusiness.Order> SelectAll(){
            
            var dict = new SortedDictionary<System.Guid, GenesisBusiness.Order>();
            var db = new Models.OrdersEntities();
                        
            db.Configuration.LazyLoadingEnabled = false;

            //KF: There are several ways that the Orders can be combined with the Customer data to return the Customer names.

            //The orders Entity Framework could load the data using lazy-loading.  However in a display grid every orders customer would be loaded
            //one at a time.  For a large grid the performance hit would be quite large.  If several tables data were used in the grid the performance hit
            //would be even larger.

            //The customer data could be selected separately and then knitted into the grid using the customer id and CustomUnboundColumnData.  This method is most suitable
            //for static data that can be cached in memory.  For instance Customer or Order type.  This method reduces the amount of data returned from the database and so
            //improves performance.

            //I have chosen to write a stored procedure that returns the data that the grid needs.  As not every customer is needed and the data is not static it is the 
            //most suitable method.


            var orders = db.SelectAllOrdersWithCustomers();

            foreach (Models.spr_SelectAllOrdersWithCustomers_Result item in orders) {
                Order order = new Order(item);
                order.Parent = this;

                dict.Add(item.OrderId, order);
            }

            db.Dispose();

            this.Dictionary = dict;

            return dict;
        }




    }

    public class Order 
    {
        //If I'd gone with inheritance or there were more classes I'd use something like AutoMapper, or a code generation tool to write the code 
        //for copying the properties
        
        public Models.Order Model{get; }
        public Models.spr_SelectAllOrdersWithCustomers_Result OrderWithCustomer{get; }
        
        public Orders Parent {get; set;}

        public Order() {
        }

        public Order(Models.Order item) {

            this.Model = item;
        }

        public Order(Models.spr_SelectAllOrdersWithCustomers_Result item) {                     
            this.OrderWithCustomer = item;
        }

        public Guid Insert(Guid customerId, string referenceNumber, decimal orderValue) {

            var db = new Models.OrdersEntities();

            var order = new Models.Order {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                ReferenceNumber = referenceNumber,
                OrderValue = orderValue,
                OrderDate = DateTime.Now
            };

            db.Orders.Add(order); 
            db.SaveChanges();

            db.Dispose();

            return order.Id;
        }

        public void Delete(Guid orderId) {
            var db = new Models.OrdersEntities();
   
            var del = (from d in db.Orders where d.Id == orderId select d).Single();
            db.Orders.Remove(del);
            db.SaveChanges();

            db.Dispose();
        }

    }

}
