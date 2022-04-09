using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStoreWpfAndSqlLite.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string TypeOfProduct { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string FullName { get { return string.Format("{0} {1} {2} {3}", Producer, Model, " - ", TypeOfProduct); } }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
