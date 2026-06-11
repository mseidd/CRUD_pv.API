using System;
using System.Collections.Generic;
using System.Text;
namespace crudPVmodels
{
    public class VendorModel
    {
        public int VendorId { get; set; }  
        public string ? Name { get; set; }
        public string ? Address { get; set; }
        public string ? Contact { get; set; }

        public override string ToString()
        {
            return " VendorId: " + VendorId +
                   " | Name: " + Name +
                   " | Address: " + Address +
                   " | Contact: " + Contact;
        }
    }
}