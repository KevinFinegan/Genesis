using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models = GenesisModels;
using Business = GenesisBusiness;
using GF = CommonDXFunctions.GridFunctions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System.Drawing;

namespace Genesis.GridClasses
{
    //KF The business classes could be used for display also, it would reduce some of the duplicated code and allow the same storage classes to be re-used
    //I've split them out so that all of the visual stuff is in this project/layer only.  As this kind of code is easily generated the extra coding does not add 
    //much extra effort.

    //The kind of thing that might go here is the colours that are used in the grids to highlight old orders, unfilled orders etc.  Also any splitting of data across
    //columns, hidden columns, column formatting etc.

    //If there were several of these classes needed I would make an interface for the common methods e.g. SetupGrid

    public class Orders {
        public SortedDictionary<System.Guid, Order> Dictionary{ get;}

        public Orders(GenesisBusiness.Orders busOrders) {

            this.Dictionary = new SortedDictionary<Guid, Order>();

            foreach (GenesisBusiness.Order busOrder in busOrders.Dictionary.Values) {
                Order order = new Order(busOrder);
                order.Parent = this;

                this.Dictionary.Add(order.OrderId, order);
            }

        }

        public static void SetupGrid(GridView grd) {            
            //KF There are lots of places that the grid setup could go
            //I've seen it in configuration files, in the editor, in code on the form, in code in classes ....
            //I prefer doing it this way as I think it is the most maintainable way and is the easiest to find

            grd.OptionsBehavior.Editable = false;

            grd.Columns.Clear();

            grd.Columns.Add(GF.CreateGridColumn("colReferenceNumber", "ReferenceNumber", true, 10));
            grd.Columns.Add(GF.CreateGridColumn("colOrderValue", "OrderValue", true, 10, "", FormatType.Numeric, "LocalMoney"));
            grd.Columns.Add(GF.CreateGridColumn("colOrderDate", "OrderDate", true, 10, "", FormatType.DateTime, "dd-MMM-yyyy"));
            grd.Columns.Add(GF.CreateGridColumn("colCustomerName", "CustomerName", true, 10));
                        
            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
            GridColumn col = GF.CreatePictureEditColumn(pictureEdit, "colOpenCustomer", "SearchPicture", true, 10, "Edit Customer");
            grd.GridControl.RepositoryItems.Add(pictureEdit);
            grd.Columns.Add(col);

            grd.Columns.Add(GF.CreateGridColumn("colCustomerId", "CustomerId", false, 0));
        }


    }

    public class Order{
        public Guid OrderId { get; set; }
        public string ReferenceNumber { get; set;}
        public decimal OrderValue { get; set;} 
        public DateTime OrderDate { get; set;} 
        public string CustomerName { get; set;} 
        public Image SearchPicture { get; set;} 
        public Guid CustomerId { get; set;} 

        public Orders Parent {get; set;}

        public Order(Business.Order o) {
            this.OrderId = o.OrderWithCustomer.OrderId;
            this.ReferenceNumber = o.OrderWithCustomer.ReferenceNumber;
            this.OrderValue = o.OrderWithCustomer.OrderValue;
            this.OrderDate = o.OrderWithCustomer.OrderDate;
            this.CustomerName = o.OrderWithCustomer.LastName + ", " +  o.OrderWithCustomer.FirstName;
            this.CustomerId = o.OrderWithCustomer.CustomerId;

            //KF: A better picture would be a trasparent one so that it doesn't stand out when the row is highlighted
            this.SearchPicture = (Image)GenesisGUI.Properties.Resources.ResourceManager.GetObject("Search");

                
            //if(o.Model.Customer != null) {
            //    this.CustomerName = o.Model.Customer.LastName + ", " + o.Model.Customer.FirstName; 
            //}
           
        }
    }


}
