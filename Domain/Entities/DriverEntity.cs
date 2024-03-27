using Domain.Common;

namespace Domain.Entities
{
    public class DriverEntity : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
    }
}
