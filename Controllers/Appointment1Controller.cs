using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAPP.Data;
using SWAPP.Entities;

namespace SWAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
       
       private readonly DataContext _context;

        public AppointmentController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ActionResult<Appointment>> GetDetailList(string? dt)
        {       

              DateTime date = DateTime.Parse(dt);  
              DateTime dtfrom = date.AddDays(-30);
              DateTime dtto = date.AddDays(30);

              var ressales = await  _context.tb_appoinments
                .Where(r => r.aptype == "DETAIL")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }

        [HttpGet]
        [Route("detail/day")]
        public async Task<ActionResult<Appointment>> GetDetailDayList(string? dt)
        {       

              DateTime date = DateTime.Parse(dt);  
              
              var ressales = await  _context.tb_appoinments
                .Where(r => r.aptype == "DETAIL")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }


        [HttpGet]
        [Route("tyre")]
        public async Task<ActionResult<Appointment>> GetTyreList(string? dt)
        {       

              DateTime date = DateTime.Parse(dt);  
              DateTime dtfrom = date.AddDays(-30);
              DateTime dtto = date.AddDays(30);

              var ressales = await  _context.tb_appoinments
                .Where(r => r.aptype == "TYRE")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }   

        [HttpGet]
        [Route("tyre/day")]
        public async Task<ActionResult<Appointment>> GetTyreDayList(string? dt)
        {       

              DateTime date = DateTime.Parse(dt);  
              
              var ressales = await  _context.tb_appoinments
                .Where(r => r.aptype == "TYRE")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }


        [HttpPost]
        public async Task<ActionResult<Appointmentt>> GetDetailList1(Appointmentt appointment)
        {   
            
           Console.WriteLine(appointment);
           
          
            return Ok( _context.tb_appoinments.ToListAsync());
        }

        [HttpPut]
        public  async Task<ActionResult<List<Appointment>>> UpdateHero(Appointment appointment)
        {
            var dbHero = await _context.tb_appoinments.FindAsync(appointment.id);
            if (dbHero is null)
                return NotFound("Not Found");

            _context.Entry(dbHero).CurrentValues.SetValues(appointment);

            await _context.SaveChangesAsync();
            
            return Ok(await _context.tb_appoinments.ToListAsync());
        }


    }
}