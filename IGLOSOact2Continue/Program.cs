using crudPVappService;
using crudPVdataService;
using crudPVmodels;

class Program
{
    static void Main(string[] args)
    {

        PVappService app = new PVappService(new PVMSData());

        while (true)
        {
            Console.WriteLine("--------Vendor/Purchase Management System------");
            Console.WriteLine("1. Add Vendor");
            Console.WriteLine("2. Add Purchase");
            Console.WriteLine("3. View Vendors / Purchases");
            Console.WriteLine("4. Update Vendors");
            Console.WriteLine("5. Delete Vendors");
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------------------------");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    string add = Console.ReadLine();
                    Console.Write("Enter Contact: ");
                    string contact = Console.ReadLine();
                    app.AddVendor(name, add, contact);
                    Console.WriteLine("Vendor Added!");
                    break;

                case "2":
                    Console.Write("Vendor Name: ");
                    string vName = Console.ReadLine();

                    if (!app.VendorExists(vName))
                    {
                        Console.WriteLine("Vendor not found! Please add the vendor first (Option 1).");
                        break;
                    }

                    Console.WriteLine("----------SUPPLEMENTS-------------");
                    Console.WriteLine("1. Creatine == Php 700");
                    Console.WriteLine("2. Protein Powder == Php 1,500");
                    Console.WriteLine("3. Pre-workout == Php 300");
                    Console.Write("Select Item (1-3): ");
                    string itemChoice = Console.ReadLine();

                    string item = itemChoice switch
                    {
                        "1" => "Creatine",
                        "2" => "Protein Powder",
                        "3" => "Pre-workout",
                        _ => null
                    };

                    if (item == null)
                    {
                        Console.WriteLine("Invalid selection.");
                        break;
                    }

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    app.AddPurchase(vName, item, qty);
                    Console.WriteLine("Purchase Added!");
                    break;

                case "3":
                    var result = app.ViewVendorPurchase();

                    Console.WriteLine("\n--- Vendors ---");
                    int i2 = 1;
                    foreach (var v in result.Item1)
                        Console.WriteLine("[" + i2++ + "] " + v);

                    Console.WriteLine("\n--- Purchases ---");
                    int j = 1;
                    foreach (var p in result.Item2)
                        Console.WriteLine("[" + j++ + "] " + p);
                    break;

                case "4":
                    Console.Write("Find Vendor: ");
                    string find = Console.ReadLine();
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("New Address: ");
                    string newAdd = Console.ReadLine();
                    Console.Write("New Contact: ");
                    string newCon = Console.ReadLine();

                    if (app.UpdateVendor(find, newName, newAdd, newCon))
                        Console.WriteLine("Vendor Updated!");
                    else
                        Console.WriteLine("Update Failed");
                    break;

                case "5":
                    var list = app.ViewVendor();
                    int k = 1;
                    foreach (var v in list)
                        Console.WriteLine("[" + k++ + "] " + v);

                    Console.Write("Index: ");
                    int index = int.Parse(Console.ReadLine()) - 1;

                    if (app.DeleteVendor(index))
                        Console.WriteLine("Vendor Deleted!");
                    else
                        Console.WriteLine("Invalid Index");
                    break;

                case "6": return;
            }
        }
    }
}
