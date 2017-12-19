
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using ntsebeng.Models;

namespace ntsebeng
{
    [Activity(Label = "RestaurantActivity", MainLauncher = false)]
    public class RestaurantActivity : Activity
    {
        // private SearchView search;
        static string uri = "http://10.0.2.2:8080/api/Restaurants";
        static List<Restaurant> rest = new List<Restaurant>();
        static ListView listView;
        static public Context contextt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource 
            // SetContentView(Resource.Layout.Search);
            SetContentView(Resource.Layout.ResItems);

            listView = FindViewById<ListView>(Resource.Id.listView1);
            GettRestu restau = new GettRestu();
            restau.Execute();

            // search = FindViewById<SearchView>(Resource.Id.searchView4);

            listView.ItemClick += ListView_ItemClick;
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent ti = new Intent(this, typeof(ProductActivity));
            StartActivity(ti);
        }

        private void Search_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //adtp.Filter.InvokeFilter(e.NewText);
            //listView1.TextFilter(e.NewText);
        }




        public class GettRestu : AsyncTask
        {
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                HttpClient client = new HttpClient();

                System.Uri url = new System.Uri(uri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var restaurant = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<Restaurant>>(restaurant);

                foreach (var g in result)
                {
                    rest.Add(g);
                }
                return true;
            }
            protected override void OnPreExecute()
            {
                base.OnPreExecute();
            }
            protected override void OnPostExecute(Java.Lang.Object result)
            {
                base.OnPostExecute(result);
                listView.Adapter = new ProImageAdapter(contextt, rest);
            }
        }

        public class ProImageAdapter : BaseAdapter<Restaurant>
        {
            private List<Restaurant> prope = new List<Restaurant>();
            static Context context;

            public ProImageAdapter(Context con, List<Restaurant> lstP)
            {
                prope.Clear();
                context = con;
                prope = lstP;
                this.NotifyDataSetChanged();
            }

            public override Restaurant this[int position]
            {
                get
                {
                    return prope[position];
                }
            }

            public override int Count
            {
                get
                {
                    return prope.Count;
                }
            }
            public Context Mcontext
            {
                get;
                private set;
            }
            public override long GetItemId(int position)
            {
                return position;
            }

            public Bitmap getBitmap(byte[] getByte)
            {
                if (getByte.Length != 0)
                {
                    return BitmapFactory.DecodeByteArray(getByte, 0, getByte.Length);
                }
                else
                {
                    return null;
                }
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View restuarants = convertView;
                if (restuarants == null)
                {
                    restuarants = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Search, parent, false);
                }
                TextView txtResname= restuarants.FindViewById<TextView>(Resource.Id.txtresname);
                TextView txtaddrs = restuarants.FindViewById<TextView>(Resource.Id.txtaddress);
                TextView txtCty = restuarants.FindViewById<TextView>(Resource.Id.txtcity);
                TextView txtResemail = restuarants.FindViewById<TextView>(Resource.Id.txtresemail);
                TextView txttens= restuarants.FindViewById<TextView>(Resource.Id.txtphone);
                ImageView Image = restuarants.FindViewById<ImageView>(Resource.Id.imageView1);

                if (prope[position].Image != null)
                {
                    Image.SetImageBitmap(BitmapFactory.DecodeByteArray(prope[position].Image, 0, prope[position].Image.Length));
                }

                txtResname.Text = prope[position].Resname;
                txtaddrs.Text = prope[position].Address;
                txtCty.Text = prope[position].City;
                txtResemail.Text = prope[position].EmailAddress;
                txttens.Text = prope[position].Phonenumber;
                Image.Tag = prope[position].Image;
                return restuarants;
            }
        }
    }
}
