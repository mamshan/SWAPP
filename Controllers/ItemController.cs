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
    public class ItemController : ControllerBase
    {
         private readonly DataContext _context;

        public ItemController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Appointment>> GetDetailList(string size)
        {
            //var sql = "SELECT * FROM YourEntities WHERE Name = {0}";
            var sql = "SELECT id, stk_no, part_no, substitute, brand_name FROM s_mas WHERE ((PART_NO LIKE '%" + size + "%') OR (REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(PART_NO,'Z',''),'R',''),'-',''),'/',''),'F',''),'X',''),' ','') LIKE '%" + size + "%')) AND (company = 'B' OR company = 'I') ORDER BY spromot";
           // sql = "select * from s_mas";

            var parameter = $"%{size}%";
            var result = await _context.s_mas.FromSqlRaw(sql).ToListAsync();
            var data = new {
                sql = sql
            };
            return Ok(result);
        }

    }

}