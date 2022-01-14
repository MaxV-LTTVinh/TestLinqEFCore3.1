using System.Collections;
using System.Collections.Generic;
using TestLinqEFCore3._1.Db.Models;

namespace TestLinqEFCore3._1.Db.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
