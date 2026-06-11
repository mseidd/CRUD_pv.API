using crudPVmodels;

namespace crudPVdataService
{
    public interface IPVdataService
    {
        List<VendorModel> GetVendors();
        List<PurchaseModel> GetPurchases();
        void AddVendor(VendorModel v);
        void AddPurchase(PurchaseModel p);
        bool UpdateVendor(int vendorId, string newName, string newAddress, string newContact); 
        bool DeleteVendor(int vendorId); 
    }
}