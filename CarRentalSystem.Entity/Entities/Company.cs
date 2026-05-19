using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRentalSystem.Entity.Entities
{
    public class Company
    {
        public int Id { get; set; }
        //------------------------------//
        // Şirket Sahibi bilgileri
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonelEmail { get; set; }
        public string PersonelPhone { get; set; }
        public string ProfileImageUrl { get; set; }

        //------------------------------//
        // Şirket bilgileri
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }
        public string CompanyImageUrl { get; set; }

        //------------------------------//
        public string Address { get; set; }
        public string Quarter { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //------------------------------//
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string? Website { get; set; }

        //------------------------------//
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // İlişkiler
        public ICollection<Car> Cars { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
