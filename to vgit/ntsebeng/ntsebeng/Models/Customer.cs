using System;
namespace ntsebeng.Models
{
    public class Customer
    {
        //private string text;

        public int CustId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Customer(int id, string firstname, string lastname, string email, string password)
        {
            CustId = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        public Customer(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Customer()
        {

        }


        //public Customer(string firstname, string lastname, string email, string password, string text) : this(firstname, lastname, email, password)
        //{
        //    this.text = text;
        //}
    }
}
