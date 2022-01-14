namespace TestLinqEFCore3._1.Db.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int TypeId { get; set; }
        //public Type Type { get; set; }
    }
}
