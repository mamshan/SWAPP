using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SWAPP.Data;
using SWAPP.Entities;

namespace SWAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
         private readonly DataContext _context;

        public InvoiceController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Appointment>> GetDetailList(string? invno)
        {

            var parameter = "%" + invno + "%";
            var ressales = await  _context.S_SALMA 
            .Where(r => EF.Functions.Like( r.ref_no, parameter)) 
            .OrderByDescending(r => r.id)
            .Take(20)
            .ToListAsync();

            return Ok(ressales); 
        }

    }

}