using Domain.Common;

namespace Domain.Entities
{
    public class CarEntity : BaseEntity
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
        
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

        public ICollection<DriverEntity> Drivers { get; set; }
    }
}
