namespace SWAPP.Entities
{   
    public class Company {
        public int id { get; set; }
        public string? comcode { get; set; }
        public string? location { get; set; }
        public  string? gl_db { get; set; }
        public  string? cash_book_acc { get; set; }
        public string? trade_deb { get; set; }
        public string? accyear { get; set; }
    }
}