using crudPVdataService;
using crudPVmodels;

namespace crudPVappService
{
    public class PVappService
    {
        private IPVdataService data;

        public PVappService(IPVdataService dataService)
        {
            data = dataService;
        }

        
        public void AddVendor(string vendorName, string vendorAdd, string vendorContact)
        {
            VendorModel vendor = new VendorModel
            {
                Name = vendorName,
                Address = vendorAdd,
                Contact = vendorContact
            };

            data.AddVendor(vendor);
        }

        
        public List<VendorModel> ViewVendor()
        {
            return data.GetVendors();
        }

        
        public void AddPurchase(string vendorName, string purchaseItem, int purchaseQuantity)
        {
            int price = 0;

            if (purchaseItem.ToLower() == "creatine")
                price = 700;
            else if (purchaseItem.ToLower() == "protein powder")
                price = 1500;
            else if (purchaseItem.ToLower() == "pre-workout")
                price = 300;
            else
                return;

            int total = price * purchaseQuantity;

            PurchaseModel purchase = new PurchaseModel
            {
                VendorName = vendorName,
                Item = purchaseItem,
                Quantity = purchaseQuantity,
                Total = total
            };

            data.AddPurchase(purchase);
        }

        
        public (List<VendorModel>, List<PurchaseModel>) ViewVendorPurchase()
        {
            return (data.GetVendors(), data.GetPurchases());
        }


        public bool UpdateVendor(int vendorId, string newName, string newAddress, string newContact)
        {
            return data.UpdateVendor(vendorId, newName, newAddress, newContact);
        }

        public bool DeleteVendor(int vendorId)
        {
            return data.DeleteVendor(vendorId);
        }

        public bool VendorExists(string vendorName)
        {
            return data.GetVendors()
                .Any(v => v.Name!.Equals(vendorName, StringComparison.OrdinalIgnoreCase));
        }
    }
}