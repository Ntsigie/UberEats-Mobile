using System;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ntsebeng.Models
{
    public class DataService
    {
    
      public static async Task<dynamic> GetCustdetails(string query)
      {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(query);

        dynamic cust = null;

        if (response != null)

        {
            string json = response.Content.ReadAsStringAsync().Result;
            cust = JsonConvert.DeserializeObject(json);


        }
        return cust;
    }

  
        HttpClient client = new HttpClient();
        public Customer  GetCust(string Email, string Password)
        {
            string url = @"http://10.0.2.2:8080/api/CustomersLogin?email=" + Email + "&Password=" + Password + "";
            HttpResponseMessage  response= client.GetAsync(url).Result;
            Customer cust = new Customer();
            cust = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);

            return cust;
           
        }

        public static async Task<dynamic> GetCust(string quer)
        {
            HttpClient client = new HttpClient();
            Customer customer = new Customer();

            //ISharedPreferences pref = Application.Context.GetSharedPreferences("CustomerList", FileCreationMode.Private);
            //var customers = pref.GetString("Customers", null);  

            var data = JsonConvert.SerializeObject(customer);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(quer, content);

            dynamic cust = null;

            if (response != null)
            {

                string json = response.Content.ReadAsStringAsync().Result;
                cust = JsonConvert.DeserializeObject(json);
                //ISharedPreferencesEditor editor = pref.Edit();
                //editor.PutString("Customers", data);
                //editor.Commit();
            }
            return cust;
        }


        public static async Task<dynamic> GetCustomer(string query)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(query);

            dynamic cust = null;

            if (response != null)

            {
                string json = response.Content.ReadAsStringAsync().Result;
                cust = JsonConvert.DeserializeObject(json);
            }
            return cust;
        }



        //Updating Customer Details
        public static async Task<Customer> UpdateCustomer(Customer cust)
        {
            HttpClient client = new HttpClient();
            string urlu = @"http://10.0.2.2:8080/api/UpdateCustomerDetails?CustId=" + cust.CustId + ";";

            dynamic results = await DataService.GetCustomer(urlu).ConfigureAwait(false);
            var json = JsonConvert.SerializeObject(cust);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(urlu, content);

            //if (response.IsSuccessStatusCode)
            //{
            //    GetCust(cust.Email, cust.Password);
            //}



            if (results["Customer"] != null)
            {
                //await GetCusts(custs.Email, custs.Password);
                Customer objcust = new Customer();
                objcust.CustId= (Int32)results["CustId"];
                objcust.Firstname= (string)results["Firstname"];
                objcust.Lastname = (string)results["Lastname"];
                objcust.Email = (string)results["Email"];
                objcust.Password = (string)results["Password"];
               
                return cust;
            }
            return null;
        }


























        public DataService()
        {
        }
    }
}
