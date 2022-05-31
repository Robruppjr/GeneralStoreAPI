using System;
using System.Collections.Generic;

namespace GenrealStoreAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
