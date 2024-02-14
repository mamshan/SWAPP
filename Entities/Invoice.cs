namespace SWAPP.Entities
{   
    public class Sale {
        public int id { get; set; }

        public required string ref_no { get; set; }

        public required string c_code { get; set; }


public required string cus_name { get; set; }

        public DateOnly? sdate { get; set; } = null;

        public double  grand_tot { get; set; } = 0;
        
        public double  gst { get; set; } = 0;

       public string  company { get; set; } = string.Empty;

       
    }

    public class SpDiscount
{

     public int id { get; set; }

    public DateOnly sdate { get; set; }

    public string stk_no { get; set; } // Foreign key to Sale.RefNo

    public double dis1 { get; set; } // Foreign key to Sale.RefNo

    public double dis2 { get; set; } // Foreign key to Sale.RefNo

    public double sptot { get; set; } // Foreign key to Sale.RefNo

    public string reason { get; set; } // Foreign key to Sale.RefNo

    // Add other discount-related properties as needed
public int? inv_id { get; set; }
    public string ref_no { get; set; }
}

    public class Return {
        public int Id { get; set; }

        public required string refno { get; set; }

        public DateTime? sdate { get; set; } = null;

        public required string cuscode { get; set; }

        public double  amount { get; set; } = 0;

        public string  trn_type { get; set; } = string.Empty;

        public double gst { get; set; } =0;


    }
}