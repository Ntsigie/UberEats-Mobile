using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class CustomerController : System.Web.Http.ApiController
    {
        static DataAccess obj = new DataAccess();

        //Retrive customer information from database
        //Registering customers on the mobile application
        [System.Web.Http.HttpPost]
        //[Route("api/Register")]
        [System.Web.Http.Route("api/Regist")]
        public string PostCust(Customer cust)
        {
            if (cust != null)
            {
                return obj.AddCust(cust);
            }
            return "Unable to add";
        }


        //Get all Customers information stored in the database
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return obj.GetCust();
        }


        //Login into the system
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/CustomersLogin")]
        public Customer GetCust(string email, string password)
        {
            return obj.CustomerLogin(email, password);
        }

        //Update
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/UpdateCustomerDetails")]
        public Customer UpdateCustomer(Customer cust, int id)
        {
            return obj.CustUpdate(cust, id);
        }



    }

}