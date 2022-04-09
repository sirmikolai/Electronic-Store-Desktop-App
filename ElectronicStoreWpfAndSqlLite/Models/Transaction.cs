using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStoreWpfAndSqlLite.Models
{
    public class Transaction
    {
        public int IdTransaction { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int QuantityOfTransaction { get; set; }
        public decimal PriceOfTransaction { get; set; }
        public System.DateTime DateOfTransaction { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
    }
}
