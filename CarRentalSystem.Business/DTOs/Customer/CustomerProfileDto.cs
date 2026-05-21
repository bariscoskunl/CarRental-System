namespace CarRentalSystem.Business.DTOs.Customer
{
    public class CustomerProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }

        public string LicenseNumber { get; set; } = null!;
        public DateTime LicenseExpireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
    }
}
