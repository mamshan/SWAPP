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

        [HttpGet]
        [Route("refno")]
        public async Task<ActionResult<Appointment>> GetDetailRefno(string? refno)
        {
            var ressales = await  _context.s_comm
            .Where(r=> r.mtype == "TRADE") 
            .Where(r=> r.ref_no == refno)
            .OrderBy(r => r.id )
            .ToListAsync();

            return Ok(ressales); 
        }


        [HttpGet]
        [Route("invoicedetails")]
        public async Task<ActionResult<Appointment>> GetDetailInv(string? refno)
        {
           
      

            var combinedData = new CombinedDiscountData();
            var remark ="";
            double amount =0;
            foreach (var row in await _context.sp_discount_trn
                            .Where(r => r.ref_no == refno)
                            .OrderBy(r => r.id)
                            .ToListAsync())
            {

               Console.WriteLine(row.sptot);

                remark += row.reason;
                amount += row.sptot;

               
                
            }

            
            var ressales = await  _context.S_SALMA 
            .Where(r =>  r.ref_no == refno) 
            .OrderByDescending(r => r.id)
            .SingleAsync();

            var resscomm = await  _context.s_comm 
            .Where(r =>  r.invno == refno) 
            .OrderByDescending(r => r.id)
            .SingleOrDefaultAsync();

            var comamo =resscomm.amount ;


            var salesData = new
            {
                remark = remark,
                amount = amount,
                cus_name = ressales.cus_name,
                grand_tot = ressales.grand_tot,
                comamo = comamo,
                
            };
            

            return Ok(salesData); 
        }

    }

    public class CombinedDiscountData
{
    public string remark { get; set; }
    public double amount { get; set; }
}

}