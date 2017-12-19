using System;
namespace ntsebeng.Models
{
    public class Restaurant
    {
        public int ResId{ get; set; }
        public string Address{ get; set; }
        public string City { get; set; }
        public string Resname { get; set; }
        public string EmailAddress{ get; set; }
        public string Phonenumber { get; set; }
        public int ImageId { get; set; }
        public byte[] Image { get; set; }


        public Restaurant (string address,string city,string resname,string emailaddr,string number,int imagid,byte[] img)
        {
            Address =address;
            City =city;
            Resname =resname;
            EmailAddress = emailaddr;
            Phonenumber = number;
            ImageId = imagid;
            Image = img;

        }


        public Restaurant(int id,string address, string city, string resname, string emailaddr, string number, int imagid, byte[] img)
        {
            ResId=id;
            Address = address;
            City = city;
            Resname = resname;
            EmailAddress = emailaddr;
            Phonenumber = number;
            ImageId = imagid;
            Image = img;

        }

        public Restaurant()
        {
        }
    }
}
