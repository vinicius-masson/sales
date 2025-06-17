using Sales.Common.Validation;
using Sales.Domain.Enums;
using Sales.Domain.Exceptions;
using Sales.Domain.Validation;

namespace Sales.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale(Customer customer, BranchOffice branchOffice)
        {
            Customer = customer;
            BranchOffice = branchOffice;

            Number = new Random().Next();
            Status = SaleStatus.NotCancelled;
            SaleDate = DateTime.UtcNow;
            SaleItens = new List<SaleItem>();
        }

        public long Number { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Customer Customer { get; private set; }
        public decimal TotalSaleAmount { get; private set; }
        public BranchOffice BranchOffice { get; private set; }
        public List<SaleItem> SaleItens { get; private set; }
        public SaleStatus Status { get; private set; }

        public void SetCustomer(Customer customer) => Customer = customer;

        public void SetBranch(BranchOffice brancOfficeh) => BranchOffice = brancOfficeh;

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
        public void CancelSale() => Status = SaleStatus.Cancelled;

        public void AddItem(SaleItem saleItem)
        {
            SaleItens.Add(saleItem);
            saleItem.Sale = this;
            CalculateTotalSale();
        }

        public void CancelSaleItem(Guid saleItemId)
        {
            var saleItem = SaleItens.FirstOrDefault(p => p.Id == saleItemId);
            if (saleItem == null || saleItem.Status == SaleItemStatus.Cancelled)
                throw new DomainException("Sale Item not found or already cancelled");

            saleItem.CancelSaleItem();
            CalculateTotalSale();
        }

        public void ClearItens() => SaleItens.Clear();

        private void CalculateTotalSale() => TotalSaleAmount = SaleItens.Where(x => x.Status == SaleItemStatus.NotCancelled).Sum(x => x.TotalPrice);
    }
}
