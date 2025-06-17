using Sales.Domain.Enums;

namespace Sales.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public Adress Address { get; private set; } = new();
        public long Document { get; private set; }
        public PersonType PersonType { get; private set; }
    }
}
