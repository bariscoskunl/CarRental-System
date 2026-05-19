using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }

        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? TransactionId { get; set; }
    }
}
