
namespace crudPVmodels
{
    public class PurchaseModel
    {
        public string ? VendorName { get; set; }
        public string ? Item{ get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            return "Vendor Name: " + VendorName +
                   " | Item: " + Item +
                   " | Quantity: " + Quantity +
                   " | Total: Php " + Total;
        }
    }
}