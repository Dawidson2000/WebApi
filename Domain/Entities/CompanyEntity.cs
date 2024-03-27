using Domain.Common;

namespace Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<DriverEntity> Drivers { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
    }
}
