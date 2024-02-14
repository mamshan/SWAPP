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

            var comamo =resscomm?.amount ?? 0 ;


            var salesData = new
            {
                remark = remark,
                amount = amount,
                cus_name = ressales.cus_name,
                grand_tot = (ressales.grand_tot/(1+ressales.gst/100)),
                comamo = comamo,
                comp = Math.Round(comamo/ (ressales.grand_tot/(1+ressales.gst/100)) * 100),
            };
            

            return Ok(salesData); 
        }



        [HttpPost]
       public async Task<ActionResult<CommissionPost>> SaveCom(CommissionPost jsonData) {

    
            Console.WriteLine(DateTime.Now);

            var comp = Request.Headers["x-auth-company"].ToString();
           
            

            Console.WriteLine(DateTime.Now);
            var refno = "";
            var data = jsonData;
            if (data.ref_no == null) {
                refno =   await GetNoAsync(comp);
            } else {
                refno =  data.ref_no;

                var ressales =  await _context.s_comm
                .Where(r=> r.mtype == "TRADE") 
                .Where(r=> r.ref_no == refno)
                .Where(r=> r.company == comp)
                .OrderByDescending(r => r.ref_no )
                .FirstAsync();

                _context.s_comm.Remove(ressales);
    
                // commit the change to the database
                _context.SaveChanges();

            }

            // Access properties of the purchase order

            string refNo = refno.ToString();
            DateOnly sDate = data.sdate;
            string descr = data.descr;

            // Accessing invoices as an array
       
            foreach (dynamic invoice in data.invoices)
            {
            string invNo = invoice.invno;
            DateOnly invDate = invoice.invdate;
            string cusName = invoice.cus_name;
            double grandTot = invoice.grand_tot;

            // Access other invoice properties as needed
            
           var combinedData = new Commision();

            combinedData.ref_no = refNo;
            combinedData.sdate = sDate;
            combinedData.descr = descr;
            combinedData.invno = invNo;
 
            combinedData.amount = invoice.comAmt;
            combinedData.mtype = "TRADE";
            combinedData.company = "I";
           
            _context.s_comm.Add(combinedData);
            int id = await _context.SaveChangesAsync();


            }


            
            var Data = new
            {
                id = refNo, 
            };

            return Ok(Data);
        
            
        }

     
        public async Task<string> GetNoAsync(string comcode) {


            try
            {
                var ressales =  await _context.s_comm
                .Where(r=> r.mtype == "TRADE") 
                .Where(r=> r.company == comcode)
                .OrderByDescending(r => r.ref_no )
                .FirstAsync();

                Console.WriteLine("GETNO1");
                var refno =   ressales?.ref_no ?? "1" ;
                int last4Digits = Int32.Parse(refno.Substring(refno.Length - 4)) +1 ;

                string lastno = "0000"+  last4Digits.ToString();


                refno = comcode + "/COM/" + lastno.Substring(lastno.Length-4);     
                Console.WriteLine(last4Digits);

                return refno; 
    
            }
            catch ( System.Exception e)
            {
                
                Console.WriteLine(e.Message);
                return "false";
            }
            
            
           

        }

       

    }



}