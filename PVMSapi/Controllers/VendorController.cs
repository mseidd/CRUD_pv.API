using crudPVappService;
using crudPVmodels;
using Microsoft.AspNetCore.Mvc;

namespace PVMSapi.Controllers
{
    [ApiController]
    [Route("api/vendors")]
    public class VendorsController : ControllerBase
    {
        private readonly PVappService _appService;

        public VendorsController()
        {
            _appService = new PVappService(new PVMSData());
        }

        [HttpGet]
        public ActionResult<IEnumerable<VendorModel>> GetAllVendors()
        {
            var vendors = _appService.ViewVendor();
            return Ok(vendors);
        }

      
        [HttpGet("{id:int}")]
        public ActionResult<VendorModel> GetVendorById(int id)
        {
            var vendor = _appService.ViewVendor()
                .FirstOrDefault(v => v.VendorId == id);

            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }

        [HttpPost]
        public ActionResult AddVendor([FromBody] VendorModel vendor)
        {
            if (vendor == null)
                return BadRequest("Vendor data is required.");

            _appService.AddVendor(vendor.Name!, vendor.Address!, vendor.Contact!);
            return CreatedAtAction(nameof(GetAllVendors), new { }, vendor);
        }

        
        [HttpPut("{id:int}")]
        public IActionResult UpdateVendor(int id, [FromBody] VendorModel updated)
        {
            if (updated == null)
                return BadRequest("Vendor data is required.");

            bool success = _appService.UpdateVendor(id, updated.Name!, updated.Address!, updated.Contact!);
            if (!success)
                return NotFound();

            return NoContent();
        }

     
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVendor(int id)
        {
            bool success = _appService.DeleteVendor(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}