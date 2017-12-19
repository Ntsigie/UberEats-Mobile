using System;
namespace MyAppServices.Models
{
    public class Product
    {
        public int ProId { get; set; }
        public string ProdName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] ProdImage { get; set; }

        public Product(int prodid, string prodname, string desc, string price, byte[] propic)
        {
            ProId = prodid;
            ProdName = prodname;
            Description = desc;
            Price = price;
            ProdImage = propic;

        }




        public Product()
        {
        }
    }
}