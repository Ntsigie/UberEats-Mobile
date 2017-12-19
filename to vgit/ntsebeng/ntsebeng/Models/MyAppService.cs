using System;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace ntsebeng.Models
{
    public class MyAppService
    {

            //HttpClient client = new HttpClient();
            //Customer customer = null;

            //public async Task<Customer> GetCustomers(string email, string password)
            //{
            //    string url = @"http://10.0.2.2:8080/api/CustomerLogginIn?Email=" + email + "&Password=" + password + "";
            //    var response = await client.GetAsync(url);
            //    if (response.IsSuccessStatusCode)
            //    {
                   
            //    }
            //    return customer;
            //}


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

        public MyAppService()
        {
            
        }
    }
}
