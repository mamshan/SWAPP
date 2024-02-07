using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SWAPP.Entities
{
    public class Appointment
    {
        
        [Key]
        public int id { get; set; } // Added primary key

        [StringLength(255)]
        public string? slot { get; set; } = string.Empty;

        [StringLength(255)]
        public string? c_name { get; set; }= string.Empty;

        public DateOnly? sdate { get; set; }


        [StringLength(255)]
        public string? contno { get; set; }= string.Empty;


        [StringLength(255)]
        public string? stk_no { get; set; } = string.Empty;

        [StringLength(255)]
        public string? descript { get; set; }= string.Empty;

        public double? qty { get; set; }= 0;

        [StringLength(255)]
        public string? vehno { get; set; }= string.Empty;

        [StringLength(255)]
        public string? aptype { get; set; }= string.Empty;


    }



    public class Appointmentt
    {
        
        [Key]
        public int id { get; set; } // Added primary key

        [StringLength(255)]
        public string? slot { get; set; } = string.Empty;

        [StringLength(255)]
        public string? c_name { get; set; }= string.Empty;

        [StringLength(255)]
        public string? contno { get; set; }= string.Empty;


        [StringLength(255)]
        public string? stk_no { get; set; } = string.Empty;

        [StringLength(255)]
        public string? descript { get; set; }= string.Empty;

        public double? qty { get; set; }= 0;

        [StringLength(255)]
        public string? vehno { get; set; }= string.Empty;

        [StringLength(255)]
        public string? aptype { get; set; }= string.Empty;

    }


}