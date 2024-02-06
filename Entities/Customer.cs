namespace SWAPP.Entities
{   
public class Customer {
        public int Id { get; set; }

        public required string code { get; set; }

        public required string name { get; set; }
 
        public string  town { get; set; } = string.Empty;


    }
}