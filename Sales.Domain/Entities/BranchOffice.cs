namespace Sales.Domain.Entities
{
    public class BranchOffice : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public Adress Adress { get; private set; } = new();
    }
}
