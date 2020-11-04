using AutoMapper.Configuration.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADV.Orders.Model
{
    public class Product
    {
        public Product()
        {
            //Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public int Price { get; set; }
        
        
        //public virtual ICollection<Order> Order { get; set; }
    }
}