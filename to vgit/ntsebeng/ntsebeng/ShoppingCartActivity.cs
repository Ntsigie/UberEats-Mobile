
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
    [Activity(Label = "ShoppingCartActivity", MainLauncher = false)]
    public class ShoppingCartActivity: Activity
    {
        static Intent intent = new Intent();
        static ListView thelist;
        Button checkout;
        List<string> Mylist = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemsInCart);
            thelist= FindViewById<ListView>(Resource.Id.listViewItems);
            checkout = FindViewById<Button>(Resource.Id.btnCheckOut); 
            string Prodname = Intent.GetStringExtra("ProdName");
            string ProdPrice = Intent.GetStringExtra("Price");
            string total = Intent.GetStringExtra("tot");
            string quantity = Intent.GetStringExtra("quan");

            Mylist.Add( Prodname);
            Mylist.Add("R " + ProdPrice);
            Mylist.Add("Quantity " + quantity);
            Mylist.Add("R " + total);
      

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Mylist);
            thelist.Adapter = adapter;
            checkout.Click += Checkout_Click;
        }

        void Checkout_Click(object sender, EventArgs e)
        {
            Intent intents = new Intent(this, typeof(PaymentActivity));
            StartActivity(intents);
        }
    }

}
