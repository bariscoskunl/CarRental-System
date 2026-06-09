using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DTOs.CarImage
{
    public class CreateCarImageDto
    {
        public string ImageUrl { get; set; } = null!;
        public bool IsCoverImage { get; set; }
        public int CarId { get; set; }
    }
}
