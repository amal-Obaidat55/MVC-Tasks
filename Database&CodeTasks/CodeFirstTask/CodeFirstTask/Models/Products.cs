namespace CodeFirstTask.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesId { get; set; }
        public Suppliers Suppliers { get; set; }
        public int SuppliersId { get; set; }

    }
}
