namespace CodeFirstTask.Models
{
    public class PurchaseOrderItems
    {
        public int Id { get; set; }
        public PurchaseOrders PurchaseOrders { get; set; }
        public int PurchaseOrdersID { get; set; }
        public Products Products { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
