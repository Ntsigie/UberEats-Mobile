using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Data;
using MyAppServices.Models;
using System.Web.Http;

namespace MyAppServices.Controllers
{
    public class ResController : System.Web.Http.ApiController
    {
        static DataAccess objdata = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Restaurants")]
        public IEnumerable<Restaurant> GetRes()
        {
            return objdata.GetRestaurant();
        }
    }
}