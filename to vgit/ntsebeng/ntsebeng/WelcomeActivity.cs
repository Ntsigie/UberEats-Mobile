
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ntsebeng
{
    [Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : Activity
    {

        Button btnsearch1;
        Button btnsearch2;
        Button btnupto;
        Button btncustpay;
        Button btnloglast;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Welcomepage);

            btnsearch1 = FindViewById<Button>(ntsebeng.Resource.Id.btnSearchRes);
            btnsearch1.Click += btnsearch1_Click;

            btnsearch2 = FindViewById<Button>(ntsebeng.Resource.Id.btnSearchprod);
            btnsearch2.Click += btnsearch2_Click;

            btnupto = FindViewById<Button>(ntsebeng.Resource.Id.btnuppy);
            btnupto.Click += btnupto_Click;

            btncustpay = FindViewById<Button>(ntsebeng.Resource.Id.btnpayment2);
            btncustpay.Click += btncustpay_Click;

            btnloglast = FindViewById<Button>(ntsebeng.Resource.Id.btnLogOut);
            btnloglast.Click += btnloglast_Click;
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RestaurantActivity));
            StartActivity(intent);
        }



        private void btnsearch2_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProductActivity));
            StartActivity(intent);
        }


        private void btnupto_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(UpdateActivity));
            StartActivity(intent);
        }



        private void btncustpay_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PaymentActivity));
            StartActivity(intent);
        }

        private void btnloglast_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LogoutActivity));
            StartActivity(intent);
        }

    }
}
