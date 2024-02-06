namespace SWAPP.Entities
{   
    public class Sale {
        public int Id { get; set; }

        public required string ref_no { get; set; }

        public required string c_code { get; set; }

        public DateTime? sdate { get; set; } = null;

        public double  grand_tot { get; set; } = 0;
        
        public double  gst { get; set; } = 0;
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