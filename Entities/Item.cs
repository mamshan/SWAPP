namespace SWAPP.Entities
{   
    public class Item {
        public int id { get; set; }

        public string? stk_no { get; set; }

        public string? part_no { get; set; }
        public  string? brand_name { get; set; } = string.Empty;
 
        public string? substitute { get; set; }= string.Empty;
     
       
    }
}