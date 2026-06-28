using Microsoft.AspNetCore.Mvc;
using Pharmacy.Database;

namespace Pharmacy.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(MedicationData.Medications);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var medication = MedicationData.Medications.FirstOrDefault(m => m.Id == id);

        if (medication == null)
        {
            return NotFound();
        }

        return Ok(medication);
    }
}
