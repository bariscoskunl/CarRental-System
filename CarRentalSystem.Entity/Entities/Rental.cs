using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class Rental
    {
        public int Id { get; set; }

        // Kim kiraladı? 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Hangi araç? 
        public int CarId { get; set; }
        public Car Car { get; set; }

        // Nereden → nereye teslim
        public int PickupBranchId { get; set; }
        public Branch PickupBranch { get; set; }
        public int ReturnBranchId { get; set; }
        public Branch ReturnBranch { get; set; }

        // Tarihler 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        // Fiyat 
        public decimal TotalPrice { get; set; }
        public decimal? ExtraCharges { get; set; }

        public RentalStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // İlişkiler
        public Payment Payment { get; set; }
    }
}
