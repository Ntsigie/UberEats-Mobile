
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
    [Activity(Label = "LogoutActivity", MainLauncher =false)]
    public class LogoutActivity : Activity
    {
        Button btnlogOUT;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Logout);

            btnlogOUT = FindViewById<Button>(ntsebeng.Resource.Id.btnLogOut);
            btnlogOUT.Click += BTNlogout_Click;

        }

        private  void BTNlogout_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle("THANK YOU ");
            alertDialog.SetMessage("Thank you for shopping with UberEats");
            alertDialog.SetNeutralButton("OK",delegate {
               alertDialog.Dispose();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            });
            alertDialog.Show();
        }
    }
}
