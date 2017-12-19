using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class CustPaymentController : System.Web.Http.ApiController
    {
        static DataAccess obj = new DataAccess();

        //Retrive customer information from database
        //Registering customers on the mobile application
        [System.Web.Http.HttpPost]
        //[Route("api/Register")]
        [System.Web.Http.Route("api/Payments")]
        public string PostPayment(Payment pay)
        {
            if (pay != null)
            {
                return obj.AddPayment(pay);
            }
            return "Unable to add";
        }

        //Get all Customers information stored in the database
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Getpayments")]
        public IEnumerable<Payment> GetPayments()
        {
            return obj.GetPayments();
        }

    }

}
