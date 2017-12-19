
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ntsebeng.Models;

namespace ntsebeng
{
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        

            static string url = "http://10.0.2.2:8080/api/Regist";
            EditText Firstname, Lastname, Email, Password;
            HttpClient client;
        


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            //FirstName = FindViewById<EditText>(Resource.Id.txt);
            Firstname = FindViewById<EditText>(Resource.Id.txtname);
            Lastname = FindViewById<EditText>(Resource.Id.txtlast);
            Email = FindViewById<EditText>(Resource.Id.txtemail);
            Password = FindViewById<EditText>(Resource.Id.txtpassword);

            Button Regist = FindViewById<Button>(Resource.Id.button1);
            Regist.Click += button_Clicked;


        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            try
            {
                client = new HttpClient();
                var user = new Customer()
                {
                    Firstname = Firstname.Text,
                    Lastname = Lastname.Text,
                    Email = Email.Text,
                    Password = Password.Text
                };

                Firstname.Text = "";
                Lastname.Text = "";
                Email.Text = "";
                Password.Text = "";



                var uri = new System.Uri(string.Format(url));
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

               
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Customer custs = JsonConvert.DeserializeObject<Customer>(data);
                    Toast.MakeText(this, "You are successfully registered with UberEats", ToastLength.Long).Show();
                    Intent ip = new Intent(this, typeof(MainActivity));
                    StartActivity(ip);
                }
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }

        }

    }
}



