namespace SWAPP.Entities
{   
    public class Commision {
         
        

        public int id { get; set; }

        public  string? ref_no { get; set; }

        public  string? invno { get; set; }

        public DateOnly? sdate { get; set; } = null;

        public double  amount { get; set; } = 0;
        public  string? descr { get; set; }

        public  string? company { get; set; }

        public  string? mtype { get; set; }
        
        
    }



    public class CommissionPost
    {
        public string? ref_no { get; set; }
        public DateOnly sdate { get; set; }
        public string? descr { get; set; }
        public List<CommissionInvoice>? invoices { get; set; }
    }

// Define your Invoice class (adjust properties as needed)
    public class CommissionInvoice
    {
        public string? invno { get; set; }
        public DateOnly? invdate { get; set; }
        public string? cus_name { get; set; }
        public double? grand_tot { get; set; }
        public double? SDis { get; set; }
        public string? SDisRe { get; set; }
        public double? com { get; set; }
        public double? comAmt { get; set; }
    }

}