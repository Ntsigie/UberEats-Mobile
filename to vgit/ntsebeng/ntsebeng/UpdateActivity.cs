
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ntsebeng.Models;

namespace ntsebeng
{
    [Activity(Label = "UpdateActivity", MainLauncher = false)]
    public class UpdateActivity : Activity
    {
        EditText txtid, txtname, txtlast, txtemail, txtpassword;
        Button btnup;
        DataService objupd = new DataService();

        HttpClient client;
        DataService objup = new DataService();
        Customer objcust = new Customer();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Update);
            string email = Intent.GetStringExtra("email");
            string password = Intent.GetStringExtra("password");

            //Customer cust = objupd.GetCust(txtemail.Text, txtpassword.Text);
            //var loggedOn = Application.Context.GetSharedPreferences("CustomerList", FileCreationMode.Private);

            //objcust = objupd.GetCust(email, password);

            txtid = FindViewById<EditText>(Resource.Id.editcustid);
            txtname = FindViewById<EditText>(Resource.Id.editname);
            txtlast = FindViewById<EditText>(Resource.Id.editlast);
            //txtemail = FindViewById<EditText>(Resource.Id.editemail);


            btnup = FindViewById<Button>(Resource.Id.btnupdate);
            btnup.Click += btnUpdate_ClickAsync;

            //txtId.SetText(loggedOn.GetInt("Customer_Id", 0), TextView.BufferType.Editable);
            //txtname.SetText(loggedOn.GetString("Firstname", null), TextView.BufferType.Editable);
            //txtlast.SetText(loggedOn.GetString("Lastname", null), TextView.BufferType.Editable);
            //txtemail.SetText(loggedOn.GetString("Email", null), TextView.BufferType.Editable);
            //txtPass.SetText(loggedOn.GetString("Password", null), TextView.BufferType.Editable);


        }

        private  void btnUpdate_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                
                client = new HttpClient();

                objcust.Firstname = txtname.Text;
                objcust.Lastname = txtlast.Text;

                //objcust.UpdateCustomer(objcust,objcust.CustId);

             
                Toast.MakeText(this, "Successfully updated" +objcust.Firstname, ToastLength.Short).Show();
                txtid.Text = "";
                txtname.Text = "";
                txtlast.Text = "";
             

                Intent inter = new Intent(this, typeof(MainActivity));
                StartActivity(inter);
            }
            catch (Exception error)
            {
                Toast.MakeText(this, error.ToString(), ToastLength.Short).Show();
                Intent inters = new Intent(this, typeof(LogInActivity));
                StartActivity(inters);

            }

        }
    }
}
