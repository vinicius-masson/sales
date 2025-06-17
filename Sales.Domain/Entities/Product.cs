using Sales.Common.Validation;
using Sales.Domain.Validation;

namespace Sales.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public decimal BasePrice { get; private set; }
        public bool IsActive { get; private set; }
        public ProductCategory Category { get; private set; } = new();
        public int CurrentStock { get; private set; }
        public string ImageUrl { get; private set; } = string.Empty;
    }
}
