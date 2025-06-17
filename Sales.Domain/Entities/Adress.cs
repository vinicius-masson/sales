namespace Sales.Domain.Entities
{
    public class Adress : BaseEntity
    {
        public string Street { get; private set; } = string.Empty;
        public int Number { get; private set; }
        public string Neighborhood { get; private set; } = string.Empty;
    }
}
