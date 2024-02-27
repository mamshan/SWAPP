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
        public async Task<ActionResult<Appointment>> GetDetailList(string dt)
        {       

              DateOnly date = DateOnly.Parse(dt);  
              DateOnly dtfrom = date.AddDays(-30);
              DateOnly dtto = date.AddDays(30);

              var ressales = await  _context.tb_appoinments
              .Where(r => r.sdate >= dtfrom && r.sdate <= dtto)
                .Where(r => r.aptype == "DETAIL")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }

        [HttpGet]
        [Route("detail/day")]
        public async Task<ActionResult<Appointment>> GetDetailDayList(string dt)
        {       

              DateOnly date = DateOnly.Parse(dt);  
              
              var ressales = await  _context.tb_appoinments
               .Where(r => r.sdate == date)
                .Where(r => r.aptype == "DETAIL")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }


        [HttpGet]
        [Route("tyre")]
        public async Task<ActionResult<Appointment>> GetTyreList(string dt)
        {       

              DateOnly date = DateOnly.Parse(dt);  
              DateOnly dtfrom = date.AddDays(-30);
              DateOnly dtto = date.AddDays(30);

              var ressales = await  _context.tb_appoinments
                .Where(r => r.sdate >= dtfrom && r.sdate <= dtto)
                .Where(r => r.aptype == "TYRE")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }   

        [HttpGet]
        [Route("tyre/day")]
        public async Task<ActionResult<Appointment>> GetTyreDayList(string dt)
        {       

              DateOnly date = DateOnly.Parse(dt);  
              
              var ressales = await  _context.tb_appoinments
                .Where(r => r.sdate == date)
                .Where(r => r.aptype == "TYRE")
                .OrderBy(r => r.id)
                .ToListAsync();

            return Ok(ressales);
        }


        [HttpPost]
        public async Task<ActionResult<Appointment>> GetDetailList1(Appointment appointment)
        {   
            
            var dbHero = await _context.tb_appoinments
             .Where(r => r.sdate == appointment.sdate)
             .Where(r => r.aptype == appointment.aptype)
             .Where(r => r.slot == appointment.slot)
             .FirstOrDefaultAsync();

            if (dbHero is not null)
                return NotFound("Found");


              _context.tb_appoinments.Add(appointment);
            int id = await _context.SaveChangesAsync();
          

            var Data = new
            {
                id = appointment.id, 
            };

            return Ok(Data);
 
        }

        [HttpPut]
        public  async Task<ActionResult<List<Appointment>>> UpdateHero(Appointment appointment)
        {
            var dbHero = await _context.tb_appoinments.FindAsync(appointment.id);
            if (dbHero is null)
                return NotFound("Not Found");

            _context.Entry(dbHero).CurrentValues.SetValues(appointment);

            await _context.SaveChangesAsync();
            
            var Data = new
            {
                id = appointment.id, 
            };

            return Ok(Data);
        }


    }
}