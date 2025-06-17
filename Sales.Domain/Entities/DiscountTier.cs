
namespace Sales.Domain.Entities
{
    public class DiscountTier : BaseEntity
    {
        public int Quantity { get; private set; }
        public decimal Percent { get; private set; }
        public Guid ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
    }
}
