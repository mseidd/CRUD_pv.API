using crudPVdataService;
using crudPVmodels;
using Microsoft.Data.SqlClient; 

public class PVMSData : IPVdataService
{


    
    private string connectionString = @"Server=.\SQLEXPRESS;Database=pv_system;Trusted_Connection=True;TrustServerCertificate=True;";

    public List<VendorModel> GetVendors()
    {
        List<VendorModel> list = new List<VendorModel>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT vendor_id, name, address, contact FROM vendors";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new VendorModel
                {
                    VendorId = Convert.ToInt32(reader["vendor_id"]), 
                    Name = reader["name"].ToString(),
                    Address = reader["address"].ToString(),
                    Contact = reader["contact"].ToString()
                });
            }
        }
        return list;
    }

    public List<PurchaseModel> GetPurchases()
    {
        List<PurchaseModel> list = new List<PurchaseModel>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT vendor_name, item, quantity, total FROM purchases";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PurchaseModel
                {
                    VendorName = reader["vendor_name"].ToString(),
                    Item = reader["item"].ToString(),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    Total = Convert.ToInt32(reader["total"])
                });
            }
        }
        return list;
    }

    public void AddVendor(VendorModel v)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO vendors (name, address, contact) VALUES (@n, @a, @c)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@n", v.Name);
            cmd.Parameters.AddWithValue("@a", v.Address);
            cmd.Parameters.AddWithValue("@c", v.Contact);
            cmd.ExecuteNonQuery();
        }
    }

    public void AddPurchase(PurchaseModel p)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO purchases (vendor_name, item, quantity, total) VALUES (@v, @i, @q, @t)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@v", p.VendorName);
            cmd.Parameters.AddWithValue("@i", p.Item);
            cmd.Parameters.AddWithValue("@q", p.Quantity);
            cmd.Parameters.AddWithValue("@t", p.Total);
            cmd.ExecuteNonQuery();
        }
    }

    public bool UpdateVendor(int vendorId, string newName, string newAddress, string newContact)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE vendors SET name=@n, address=@a, contact=@c WHERE vendor_id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@n", newName);
            cmd.Parameters.AddWithValue("@a", newAddress);
            cmd.Parameters.AddWithValue("@c", newContact);
            cmd.Parameters.AddWithValue("@id", vendorId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public bool DeleteVendor(int vendorId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM vendors WHERE vendor_id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", vendorId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }

}