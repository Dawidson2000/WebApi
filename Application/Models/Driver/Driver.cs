using Domain.Entities;

namespace Application.Models.Driver
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
