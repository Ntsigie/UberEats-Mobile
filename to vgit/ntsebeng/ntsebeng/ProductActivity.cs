
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
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
    [Activity(Label = "ProductActivity", MainLauncher = false)]
    public class ProductActivity : Activity
    {
        static string uri = "http://10.0.2.2:8080/api/Products";
        static List<Product> objprod = new List<Product>();
        static ListView listViewprod;
        static public Context contextt;
        Customer objcust = new Customer();
        DataService data = new DataService();
        static double interim = 0;
        static int quantity = 0;
        static Intent intenti = new Intent();
        static List<Product> prody = new List<Product>();

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Products);

            listViewprod = FindViewById<ListView>(Resource.Id.listView2);
            GetProd prod = new GetProd();
            prod.Execute();
            //intenti = new Intent(this, typeof(ShoppingCartActivity));

            intenti =  new Intent(this, typeof(ShoppingCartActivity));
           


           
            // search = FindViewById<SearchView>(Resource.Id.searchView4);

            //listViewprod.ItemClick += ListView_ItemClick;

                     
        }

        // void btnNext_Clicked(object sender, EventArgs e)
        //{
        //    var intenti= new Intent(this, typeof(ShoppingCartActivity));
        //    StartActivity(intenti);
        //}


        //void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        //{
        //    Intent intenti = new Intent(this, typeof(ShoppingCartActivity));
        //    StartActivity(intenti);
        //}

        static void addedToCart(double total, int quanti)
        {
            double tot = total;
            int qty = quanti;;
            intenti.PutExtra("quantity",qty);
            intenti.PutExtra("total", tot);
        }   



        public class GetProd : AsyncTask
        {
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                HttpClient client = new HttpClient();

                System.Uri url = new System.Uri(uri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                var product = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<Product>>(product);

                foreach (var g in result)
                {
                    objprod.Add(g);
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
                listViewprod.Adapter = new ProImageAdapter(contextt, objprod);
            }
        }

        public class ProImageAdapter : BaseAdapter<Product>
        {
            private List<Product> prope = new List<Product>();
            static Context context;

            public ProImageAdapter(Context con, List<Product> lstP)
            {
                prope.Clear();
                context = con;
                prope = lstP;
                this.NotifyDataSetChanged();
            }

            public override Product this[int position]
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
                View products = convertView;
                if (products == null)
                {
                    products = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.SearchProducts, parent, false);
                }
                TextView txtnaam = products.FindViewById<TextView>(Resource.Id.txtprodname);
                TextView txtdescri = products.FindViewById<TextView>(Resource.Id.txtdesc);
                TextView txtpric = products.FindViewById<TextView>(Resource.Id.txtprice);
                ImageView Image = products.FindViewById<ImageView>(Resource.Id.imageView2);
                EventHandler btnaddcart_Clicked = ShoppingCartEvent;
                //EventHandler btnNext_Clicked = HandleEventHandler;
                Button btnaddcart;
                //Button btnNext;

                btnaddcart= products.FindViewById<Button>(Resource.Id.btnaddcart);
                btnaddcart.Click += btnaddcart_Clicked;


                void ShoppingCartEvent(object sender,EventArgs e)
                {
                    double Total = 0;
                    prody = objprod;
                    Total = Convert.ToDouble(prody[position].Price);
                    interim += Total;

                    intenti.PutExtra("ProdName",prody[position].ProdName);
                    intenti.PutExtra("Price",prody[position].Price);
                    intenti.PutExtra("tot",interim.ToString());

                    quantity++;
                    intenti.PutExtra("quan", quantity.ToString());
                   // addedToCart(interim, quantity);
                   
                }


               

                 if (prope[position].ProdImage != null)
                {
                    Image.SetImageBitmap(BitmapFactory.DecodeByteArray(prope[position].ProdImage, 0, prope[position].ProdImage.Length));
                }

                txtnaam.Text = prope[position].ProdName;
                txtdescri.Text = prope[position].Description;
                txtpric.Text = "R"+prope[position].Price;
                Image.Tag = prope[position].ProdImage;
                return products;
            }

        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MyMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.item1:
                  
                    StartActivity(intenti);
                    return true;

                default:
                    return false;
            }
        }
    }
}


        