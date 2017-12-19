
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Text;
using System;
using System.Collections;
using System.Linq;
using ntsebeng.Models;
using Java.Util;
using Android.Net;

namespace ntsebeng
{
    [Activity(Label = "ntsebeng", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
  
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Button btnRegister;
            Button btnlogin;
           

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //SetContentView(Resource.Layout.Search);
               

            //search.QueryTextSubmit += (sender e) =>
            //{
            //    Toast.MakText(this, "Searched for:" + e.Query, ToastLength.Short).Show();
            //    e.Handled = true;
            //};

            // Get our button from the layout resource,
            // and attach an event to it


            btnRegister = FindViewById<Button>(ntsebeng.Resource.Id.btnreg);
            btnRegister.Click += btnRegister_Click;

            btnlogin = FindViewById<Button>(ntsebeng.Resource.Id.btnlog);
            btnlogin.Click += btnlogin_Click;



            // Get our button from the layout resource,
            // and attach an event to it
         
        }



        private void btnlogin_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LogInActivity));
              StartActivity(intent);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegistrationActivity));
             StartActivity(intent);
        }


        //void btnRegister_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(RegistrationActivity));
        //    StartActivity(intent);
        //}

        //void btnlogin_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(LogInActivity));
        //    StartActivity(intent);
        //}

        //void btnupto_Click(object sender, EventArgs e)
        //{
        //    var intent = new Intent(this, typeof(UpdateActivity));
        //    StartActivity(intent);
        //}

    }
}

