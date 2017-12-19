
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
    [Activity(Label = "PaymentActivity", MainLauncher = false)]
    public class PaymentActivity : Activity
    {


        static string url = "http://10.0.2.2:8080/api/Payments";
        EditText BankName, CardNumber, CVV, CustId,DeliveryAddress;
        HttpClient client;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Payment);

            //FirstName = FindViewById<EditText>(Resource.Id.txt);
            BankName = FindViewById<EditText>(Resource.Id.txtbnkname);
            CardNumber = FindViewById<EditText>(Resource.Id.txtcardno);
            CVV = FindViewById<EditText>(Resource.Id.txtcvv);
            CustId = FindViewById<EditText>(Resource.Id.txtcustid);
            DeliveryAddress = FindViewById<EditText>(Resource.Id.txtdlvryadd);

            Button paym = FindViewById<Button>(Resource.Id.btnpay);
            paym.Click += button_Clicked;


        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            try
            {
                client = new HttpClient();
                var user = new Payment()
                {
                    BankName = BankName.Text,
                    CardNumber = CardNumber.Text,
                    CVV = CVV.Text,
                    CustId = CustId.Text,
                    DeliveryAddress=DeliveryAddress.Text
                };

                BankName.Text = "";
                CardNumber.Text = "";
                CVV.Text = "";
                CustId.Text = "";
                DeliveryAddress.Text = "";



                var uri = new System.Uri(string.Format(url));
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Payment objpay = JsonConvert.DeserializeObject<Payment>(data);
                    //Toast.MakeText(this, "Payment successful", ToastLength.Long).Show();
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("THANK YOU ");
                    alertDialog.SetMessage("Your order has been successfully placed,and it wil be dispatched in +-45 minutes");
                    alertDialog.SetNeutralButton("OK", delegate {
                       alertDialog.Dispose();
                      
                    });
                    alertDialog.Show();
                    Intent ip = new Intent(this, typeof(LogoutActivity));
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



