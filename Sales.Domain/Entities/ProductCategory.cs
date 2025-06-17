namespace Sales.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public List<DiscountTier> DiscountTier { get; private set; } = new();
    }
}
