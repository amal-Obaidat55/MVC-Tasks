namespace CodeFirstTask.Models
{
    public class PurchaseOrders
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public string Status { get; set; }
        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }
    }
}
