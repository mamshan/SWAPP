using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SWAPP.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; } // Added primary key

        [StringLength(255)]
        public string Slot { get; set; }

        [StringLength(255)]
        public string CName { get; set; }

        [StringLength(255)]
        public string Contno { get; set; }

        [StringLength(255)]
        public string Sdate { get; set; }

        [StringLength(255)]
        public string StkNo { get; set; }

        [StringLength(255)]
        public string Descript { get; set; }

        [StringLength(255)]
        public string Qty { get; set; }

        [StringLength(255)]
        public string Vehno { get; set; }

        [StringLength(255)]
        public string Aptype { get; set; }


        public string UniqueAppointmentCombination => $"{Slot}-{Sdate}-{Aptype}";
    }
}