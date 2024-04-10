#region Copyright Syncfusion Inc. 2001 - 2014
// Copyright Syncfusion Inc. 2001 - 2014. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJGrid.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ChildItem
    {
        public decimal Test { get; set; }
    }
    public class Prodduct
    {
        public int ProductID { get; set; }
        public string ProductName{get;set;}
        public bool Discontinued { get; set; }
    }
    public class EMployee
    {
        public int TrueCount
        {
            get;
            set;
        }
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    public class EditableOrder
    {
        public ChildItem Child { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "OrderID must be greater than 0.")]
        public int OrderID
        {
            get;
            set;
        }
        [StringLength(5, ErrorMessage = "CustomerID must be 5 characters.")]
        public string CustomerID
        {
            get;
            set;
        }

        [Range(1, 9, ErrorMessage = "EmployeeID must be between 0 and 9.")]
        public int? EmployeeID
        {
            get;
            set;
        }

        [RegularExpression(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$", ErrorMessage = "Date is required")]
        public DateTime? OrderDate
        {
            get;
            set;
        }


        public string ShipName
        {
            get;
            set;
        }

        [StringLength(15, ErrorMessage = "ShipCity must be 15 characters.")]
        public string ShipCity
        {
            get;
            set;
        }

        public string ShipAddress
        {
            get;
            set;
        }

        public string ShipRegion
        {
            get;
            set;
        }

        public string ShipPostalCode
        {
            get;
            set;
        }

        [StringLength(15, ErrorMessage = "ShipName must be 15 characters.")]
        public string Country
        {
            get;
            set;
        }

        [Range(1.00, 1000.00, ErrorMessage = "Freight must be between 1.00 & 1000")]
        public decimal? Freight
        {
            get;
            set;
        }

        public bool Verified
        {
            get;
            set;
        }

    }
}