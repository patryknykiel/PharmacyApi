using Microsoft.AspNetCore.Mvc;
using Pharmacy.Database;

namespace Pharmacy.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    private readonly PharmacyDbContext _context;

    public MedicationController(PharmacyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var medications = _context.Medication.ToList();
        return Ok(medications);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var medication = _context.Medication.FirstOrDefault(m => m.Id == id);

        if (medication == null)
        {
            return NotFound();
        }

        return Ok(medication);
    }
}
