namespace SWAPP.Entities
{   
    public class Commision {
        public int id { get; set; }

        public required string ref_no { get; set; }

        public required string invno { get; set; }

        public DateTime? sdate { get; set; } = null;

        public double  amount { get; set; } = 0;
        public  string? descr { get; set; }

        public  string? company { get; set; }

        public  string? mtype { get; set; }
        
        
    }

}