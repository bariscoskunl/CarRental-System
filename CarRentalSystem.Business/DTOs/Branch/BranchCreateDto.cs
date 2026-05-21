namespace CarRentalSystem.Business.DTOs.Branch
{
    public class BranchCreateDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int CompanyId { get; set; }
    }
}
