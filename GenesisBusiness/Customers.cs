using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models = GenesisModels;

namespace GenesisBusiness
{
    public class Customers{

        public SortedDictionary<System.Guid, Models.Customer> SelectAll(){
            
            var dict = new SortedDictionary<System.Guid, Models.Customer>();
            var db = new Models.OrdersEntities();
                        
            db.Configuration.LazyLoadingEnabled = false;

            IOrderedQueryable query = from C in db.Customers orderby C.LastName select C;

            foreach (Models.Customer item in query) {
               dict.Add(item.Id, item);
            }

            db.Dispose();

            return dict;
        }
    }

    public class Customer{
        public Models.Customer Model{get; }
        public Customers Parent {get; set;}
        
        public Customer() {
        }

        public Customer(Models.Customer item) {

            this.Model = item;
        }

        public Customer Select(Guid customerId) {

            var db = new Models.OrdersEntities();

            Models.Customer customer = (from d in db.Customers where d.Id == customerId select d).Single();
            
            db.Dispose();

            return new Customer(customer);
        }

        public void Update() {

            var db = new Models.OrdersEntities();

            Models.Customer customer = (from d in db.Customers where d.Id == this.Model.Id select d).Single();
            
            customer.FirstName = this.Model.FirstName;
            customer.LastName = this.Model.LastName;

            db.SaveChanges();

            db.Dispose();

        }

        public bool Validate(StringBuilder sb) {
            //Assume true and set to false if error found
            bool result = true;

            //Is there another customer with this name?
            //KF: Could use a stored procedure too, might be quicker
            var db = new Models.OrdersEntities();
            bool customers = (from d in db.Customers 
                                        where d.Id != this.Model.Id && d.FirstName == this.Model.FirstName && d.LastName == this.Model.LastName 
                                        select d).Any();


            if(customers) {
                result = false;
                sb.AppendLine("Another customer has this name");
            }

            return result;
        }

    }
    
}

