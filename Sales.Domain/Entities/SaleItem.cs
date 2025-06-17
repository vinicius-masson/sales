using Sales.Common.Validation;
using Sales.Domain.Enums;
using Sales.Domain.Validation;

namespace Sales.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public SaleItem(int quantity, decimal unitPrice, Product product)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            Product = product;
            Status = SaleItemStatus.NotCancelled;

            ValidateAsync();
            ApplyBusinessRules();
        }

        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public SaleItemStatus Status { get; private set; }
        public Guid SaleId { get; private set; }
        public Sale? Sale { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; private set; }

        private void ApplyBusinessRules()
        {
            CalculateDiscount();
            CalculateTotalPrice();
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            ValidateAsync();
            ApplyBusinessRules();
        }

        public void UpdatePrice(decimal price)
        {
            UnitPrice = price;
            ValidateAsync();
            ApplyBusinessRules();
        }

        private void CalculateDiscount()
        {
            if (Product?.Category?.DiscountTier == null || !Product.Category.DiscountTier.Any())
            {
                Discount = 0;
                return;
            }

            var applicableDiscount = GetApplicableDiscountTier(Product.Category.DiscountTier, Quantity);

            Discount = applicableDiscount != null
                ? UnitPrice * Quantity * applicableDiscount.Percent
                : 0;
        }

        private static DiscountTier? GetApplicableDiscountTier(List<DiscountTier> discountTiers, int quantity)
        {
            return discountTiers
                .Where(x => x.Quantity <= quantity)
                .MaxBy(x => x.Quantity);
        }

        public void CancelSaleItem() => Status = SaleItemStatus.Cancelled;

        private void CalculateTotalPrice() => TotalPrice = (UnitPrice * Quantity) - Discount;
    }
}
