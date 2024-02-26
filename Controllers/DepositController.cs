using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mysqlx;
using SWAPP.Data;
using SWAPP.Entities;

namespace SWAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositController : ControllerBase
    {
         private readonly DataContext _context;

        public DepositController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        [Route("card/list")]
        public async Task<ActionResult<Appointment>> GetDetailList(string? size)
        {

            var ressales = await  _context.dep_cheq_mas
             .Include(o => o.DepositTrans)
             .Where(r=> r.flag =="C/Card")
            .OrderByDescending(r => r.id )
            .Take(50)
            .ToListAsync();

            return Ok(ressales); 
        }



        [HttpGet]
        [Route("card/pending")]
        public async Task<ActionResult<Appointment>> GetCardPending()
        {

            var comp = Request.Headers["x-auth-company"].ToString();
            

            

            var sqlcomb = "select selected, id,invno, company, settled_no, settlmentid, st_chno, pdno, ord_no, st_date , amount,dele_no";
            sqlcomb += " from (";
            sqlcomb += "  select 0 as selected, s_sttr.id,s_sttr.st_invono as invno, s_sttr.company, s_sttr.settled_no, s_sttr.settlmentid, s_sttr.st_chno, s_sttr.st_refno as pdno, s_salma.ord_no, s_sttr.st_date, s_sttr.st_paid as amount,s_salma.dele_no";
            sqlcomb += "  from s_sttr inner join s_salma on s_salma.ref_no = s_sttr.st_invono";
            sqlcomb += "  where (s_sttr.settled_no is null) and (s_sttr.st_chno = 'c/card') and (s_sttr.company = '" + comp + "')";
            sqlcomb += "  union all ";
            sqlcomb += "  select 0 as selected, s_ut.id,s_salma_1.ref_no as invno, s_ut.company, s_ut.d as settled_no, s_ut.id as settlmentid, s_salma_1.type as st_chno, s_ut.c_refno as pdno, s_salma_1.ord_no, s_ut.c_date as st_date, ";
            sqlcomb += "         s_ut.c_payment * - 1 as amount , s_salma_1.dele_no ";
            sqlcomb += "  from s_ut inner join s_crnma on s_ut.cre_no_no = s_crnma.ref_no inner join s_salma as s_salma_1 on s_crnma.invoiceno = s_salma_1.ref_no";
            sqlcomb += "  where (s_salma_1.type = 'cc') and (s_ut.company = '" + comp + "') and (s_ut.type = 'cas') and (s_ut.lid = '1')";
            sqlcomb += ") as combined"; 
            sqlcomb += " order by invno,st_date"; 
            var ressalesc = await  _context.Database.SqlQueryRaw<CardTran>(sqlcomb).ToListAsync();



 
 

            return Ok(ressalesc); 

        }



        
        [HttpPost]
       public async Task<ActionResult<DepositMaster>> Save(DepositMaster jsonData) {

        var comp = Request.Headers["x-auth-company"].ToString();
        var transaction = _context.Database.BeginTransaction();
        try
        {


                var arr = jsonData.DepositTrans;
                var arr2 = arr.OrderBy(x => x.dele_no);
                var dele_no = "";
                foreach (var tran in jsonData.DepositTrans)
                {
                    if (dele_no == "") {
                         dele_no = tran.dele_no;
                    }
                    if (dele_no != tran.dele_no) {
                        await transaction.RollbackAsync();    
                        return BadRequest("An error occurred");
                    }
                    dele_no = tran.dele_no;

                }


                var refno =   await GetNoAsync(comp);
                var depdata = new DepositTran();
                
                //_context.dep_cheq_mas.Add(jsonData);
                var combinedData = new DepositMaster();
                
                combinedData.refno = refno;
                combinedData.sdate = jsonData.sdate;
                combinedData.dep_bank = "";
                combinedData.amount = jsonData.amount;  
                combinedData.department = comp;
                combinedData.bankCharge = jsonData.bankCharge;
                combinedData.bankChargeAmt = jsonData.bankChargeAmt;   
                combinedData.dele_no = dele_no;
                combinedData.flag = "C/Card";   
                


                _context.dep_cheq_mas.Add(combinedData);
                int id = await _context.SaveChangesAsync();

                var invno = "C/Card Deposits of ";

                foreach (var tran in jsonData.DepositTrans)
                {
                    var combinedData2 = new DepositTran();

                    // Ensure foreign key is set correctly
                    combinedData2.depositid = combinedData.id;
                    combinedData2.pdno = tran.pdno;
                    combinedData2.amount = tran.amount;
                    combinedData2.refno = combinedData.refno;
                    combinedData2.department = comp;
                    _context.Add(combinedData2);

                    invno +=  tran.pdno + " ,";
                   
                    var entityToUpdate = _context.s_sttr.FirstOrDefault(e => e.st_refno == tran.pdno && e.id == tran.id);
                    if (entityToUpdate != null)
                    {
                        entityToUpdate.settled_no = combinedData.refno;
                        _context.Update(entityToUpdate);
                        _context.SaveChanges();
                    }



                }
                await _context.SaveChangesAsync();


                var Data = new
                {
                    id = combinedData.id,
                    refno = refno 
                };

                


                var compdata =  await _context.company
                .Where(r=> r.comcode ==comp)   
                .FirstOrDefaultAsync();

                var _dbcontext = new GlDataContext();
              
                var constring = "Server=192.168.1.57;Database=" + compdata.gl_db + ";User Id=sa;Password=123;TrustServerCertificate=true;";
                
                _dbcontext.Database.SetConnectionString(constring);

                var glData = new Ledger();
                glData.l_refno = combinedData.refno;
                glData.l_date = combinedData.sdate;
                glData.l_head = invno;
                glData.l_lmem = invno;
                glData.l_amount = combinedData.amount-combinedData.bankChargeAmt;
                glData.l_code = compdata.cash_book_acc;
                glData.l_flag = "INV";
                glData.l_flag1 = "DEB";
                glData.comcode = comp;
                glData.acyear = compdata.accyear;
                _dbcontext.Add(glData);

                glData = new Ledger();
                glData.l_refno = combinedData.refno;
                glData.l_date = combinedData.sdate;
                glData.l_amount = combinedData.amount;
                glData.l_code = compdata.trade_deb;
                glData.l_head = invno;
                glData.l_lmem = invno;
                glData.l_flag = "INV";
                glData.l_flag1 = "CRE";
                glData.comcode = comp;
                glData.acyear = compdata.accyear;
                _dbcontext.Add(glData);

                glData = new Ledger();
                glData.l_refno = combinedData.refno;
                glData.l_date = combinedData.sdate;
                glData.l_amount = combinedData.bankChargeAmt;
                glData.l_head = invno;
                glData.l_lmem = invno;
                glData.l_code = "P5324";
                glData.l_flag = "INV";
                glData.l_flag1 = "DEB";
                glData.comcode = comp;
                glData.acyear = compdata.accyear;
                _dbcontext.Add(glData);

                await _dbcontext.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(Data);

            }
                catch (Exception ex)
                {
                    // Handle the exception here, potentially:
                    // - Log the error
                    // - Rollback the transaction (if it hasn't been committed yet)
                    // - Return an error response
                    // ...

                    // Example (for demonstration purposes):
                    Console.WriteLine("Error occurred: " + ex.Message);

                    // If transaction hasn't been committed, rollback it.
                    if (transaction != null)
                    {
                        await transaction.RollbackAsync();
                    }

                    return BadRequest("An error occurred");
                }
        }

     
        private async Task<string> GetNoAsync(string comcode) {


            try
            {
                var ressales =  await _context.dep_cheq_mas
                .Where(r=> r.flag == "C/Card") 
                .Where(r=> r.department == comcode)
                .OrderByDescending(r => r.refno )
                .FirstOrDefaultAsync();

                Console.WriteLine("GETNO1");
                var refno="000000";

                if (ressales == null) {
                     refno = "000000" ;
                } else {
                    
                      refno =   ressales?.refno ;
                }
                
                Console.WriteLine(refno);
                int last4Digits = Int32.Parse(refno.Substring(refno.Length - 5)) +1 ;

                string lastno = "00000"+  last4Digits.ToString();


                refno = comcode + "/CCDEP/" + lastno.Substring(lastno.Length-5);     
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
