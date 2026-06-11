using crudPVappService;
using crudPVmodels;
using Microsoft.AspNetCore.Mvc;
using PVMSapi.Models;

namespace PVMSapi.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly PVappService _appService;

        public PurchasesController()
        {
            _appService = new PVappService(new PVMSData());
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseModel>> GetAllPurchases()
        {
            var (_, purchases) = _appService.ViewVendorPurchase();
            return Ok(purchases);
        }

        [HttpPost]
        public IActionResult AddPurchase([FromBody] PurchaseViewModel purchase)
        {
            if (purchase == null)
                return BadRequest("Purchase data is required.");

            if (!_appService.VendorExists(purchase.VendorName!))
                return NotFound("Vendor not found.");

            _appService.AddPurchase(purchase.VendorName!, purchase.Item!, purchase.Quantity);
            return CreatedAtAction(nameof(GetAllPurchases), new { }, purchase);
        }
    }
}