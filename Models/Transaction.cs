using System;
using System.Collections.Generic;

namespace GenrealStoreAPI.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Qauntity { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
