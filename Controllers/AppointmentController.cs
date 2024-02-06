using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SWAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
       

        [HttpGet(Name = "appointment")]
        public ActionResult Get()
        {



              var ressales = DbContext.Vendor
                .Where(r => r.code.Contains(code) || r.name.Contains(name) ||  r.town.Contains(town))
                 .OrderBy(r => r.code)
                 .Take(5)
                 .ToList();

            return Ok(ressales);



        }
    }
}