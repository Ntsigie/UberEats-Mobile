using System.Collections.Specialized;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Linq;
using System.Net.Http;
using System.Text;
using Org.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ntsebeng.Models;
using Newtonsoft.Json;

namespace ntsebeng
{
    [Activity(Label = "LogInActivity")]
    public class LogInActivity : Activity
    {

        //TextView text;
        HttpClient client;
        EditText txtemail,txtpassword;
        Button btnlogin;
        //isLoggedIn = false;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogIn);


           


            //text = FindViewById<TextView>(Resource.Id.txtreg);
            btnlogin= FindViewById<Button>(Resource.Id.button2);

            txtemail = FindViewById<EditText>(Resource.Id.txtemail);
            txtpassword= FindViewById<EditText>(Resource.Id.txtpassword);

            btnlogin.Click += btnlogin_Click;

        }

        private void btnlogin_Click(Object sender,EventArgs e)
        {
            try
            {
                client = new HttpClient();
                DataService objsrv = new DataService();
               


                Customer cust = objsrv.GetCust(txtemail.Text, txtpassword.Text);


                if (String.IsNullOrEmpty(txtemail.Text) && String.IsNullOrEmpty(txtpassword.Text))
                {
                    Toast.MakeText(this, "Email and password can't be empty, please provide correct information", ToastLength.Short).Show();
                }
                else if (txtemail.Text == cust.Email && txtpassword.Text == cust.Password)
                {
                    Toast.MakeText(this, "Successfully logged in " + cust.Firstname, ToastLength.Short).Show();
                    Intent ti = new Intent(this, typeof(WelcomeActivity)); //added a welcome page
                    ti.PutExtra("Email",cust.Email);
                    ti.PutExtra("Password",cust.Password);
                    StartActivity(ti);
                }
                else
                {
                    Toast.MakeText(this, "Incorrect login details. Register if you havent registered.", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}