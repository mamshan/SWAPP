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
    public class CommisionController : ControllerBase
    {
         private readonly DataContext _context;

        public CommisionController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Appointment>> GetDetailList(string? size)
        {
            var ressales = await  _context.s_comm
            .Where(r=> r.mtype == "TRADE") 
            .OrderByDescending(r => r.id )
            .Take(200)
            .ToListAsync();

            return Ok(ressales); 
        }

    }

}