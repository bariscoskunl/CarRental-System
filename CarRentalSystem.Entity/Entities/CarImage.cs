using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCoverImage { get; set; }
        public DateTime UploadedAt { get; set; }

        // Yabancı Anahtar
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
