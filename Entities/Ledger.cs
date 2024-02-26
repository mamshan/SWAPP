namespace SWAPP.Entities
{   
    public class Ledger {
        public int id { get; set; }

        public string? l_refno { get; set; }
        public DateOnly? l_date { get; set; }
        public  double? l_amount { get; set; } 
 
        public string? l_code { get; set; }
        public string? l_flag { get; set; }
        public string? l_flag1 { get; set; }
        public string? l_head { get; set; }
 public string? l_lmem { get; set; }
 public string? chno { get; set; }
 public string? comcode { get; set; }
 public string? acyear { get; set; }

       
    }
}