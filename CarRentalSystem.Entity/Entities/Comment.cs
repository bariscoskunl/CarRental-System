using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }

        // Yabancı Anahtarlar
        public int CustomerId { get; set; }
        public int? CarId { get; set; }
        public int? CompanyId { get; set; }

        // İlişkiler
        public Car? Car { get; set; }
        public Customer Customer { get; set; }
        public Company? Company { get; set; }
    }
}
