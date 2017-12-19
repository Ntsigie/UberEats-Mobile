using System;
namespace MyAppServices.Models
{
    public class Restaurant
    {
        public int ResId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Resname { get; set; }
        public string EmailAddress { get; set; }
        public string Phonenumber { get; set; }
        public byte[] Image { get; set; }


        public Restaurant(string address, string city, string resname, string emailaddr, string number,  byte[] img)
        {
            Address = address;
            City = city;
            Resname = resname;
            EmailAddress = emailaddr;
            Phonenumber = number;
            Image = img;

        }


        public Restaurant(int id, string address, string city, string resname, string emailaddr, string number,  byte[] img)
        {
            ResId = id;
            Address = address;
            City = city;
            Resname = resname;
            EmailAddress = emailaddr;
            Phonenumber = number;
            Image = img;

        }

        public Restaurant()
        {
        }
    }
}
