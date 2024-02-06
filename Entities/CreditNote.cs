namespace SWAPP.Entities
{   
public class CreditNote {
        public int Id { get; set; }

        public required string refno { get; set; }

        public DateTime? c_date { get; set; } = null;

        public required string cuscode { get; set; }

        public int c_setinv { get; set; }

        public double  c_payment { get; set; } = 0;

        public string  trn_type { get; set; } = string.Empty;

        public double gst { get; set; } =0;

        public int cancell { get; set; } =0;

    }
}