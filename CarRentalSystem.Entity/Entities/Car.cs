using CarRentalSystem.Entity.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRentalSystem.Entity.Entities
{
    public class Car
    {
        public int Id { get; set; }
        //------------------------------//

        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Kilometers { get; set; }
        public string PlateNumber { get; set; }
        //------------------------------//

        public GearType GearType { get; set; }
        public CarCategory Category { get; set; }
        public FuelType FuelType { get; set; }
        public int EngineCC { get; set; }
        public int SeatCount { get; set; }
        //------------------------------//

        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? NextAvailableDate { get; set; }
        public CarStatus Status { get; set; }

        // İlişkiler
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<CarImage> Images { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
