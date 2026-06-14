using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        
        // Email, PhoneNumber, UserName, PasswordHash, EmailConfirmed gibi alanlar zaten ıdentityUser dan geliyor

        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImageUrl { get; set; }

        // 1-1 navigasyonlar: bir kullanıcı ya Customer ya da Company'dir
        public Customer? Customer { get; set; }
        public Company? Company { get; set; }

    }
}
