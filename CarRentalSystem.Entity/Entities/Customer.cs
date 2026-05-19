using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRentalSystem.Entity.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        //------------------------------//

        public string LicenseNumber { get; set; }
        public DateTime LicenseExpireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }

        // İlişkiler
        public ICollection<Comment> PostedComments { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
