using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.Transaction
{
    public class TransactionListItem
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}