using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Data;
using MySql.Data.MySqlClient;
using MyAppServices.Models;
using MyAppServices.Controllers;

namespace MyAppServices.Models
{
    public class DataAccess
    {
        static string connectString = "SERVER=localhost;UID=root;Password=root;DATABASE=MyAppDataFaith;";
        static MySqlDataReader read;

        //Register
        public string AddCust(Customer cust)
        {
            string x = "";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                string query = "INSERT INTO MyAppDataFaith.Customer(Firstname,Lastname,Email,Password) " +
                    "VALUES('" + cust.Firstname + "','" + cust.Lastname + "','" + cust.Email + "','" + cust.Password + "');";
                using (MySqlCommand comma = new MySqlCommand(query, connect))
                {
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.AddWithValue("@Firstname", cust.Firstname);
                        comma.Parameters.AddWithValue("@Lastname", cust.Lastname);
                        comma.Parameters.AddWithValue("@Email", cust.Email);
                        comma.Parameters.AddWithValue("@Password", cust.Password);
                        int y = comma.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException exception)
                    {
                        comma.Connection.Close();
                        exception.ToString();

                    }
                }
                return null;
            }
        }

        //internal string AddPayment(Controllers.Payment pay)
        //{
        //    throw new NotImplementedException();
        //}


        //Login
        public Customer CustomerLogin(string email, string password)
        {
            string sql = "SELECT CustId,Firstname,Lastname,Email,Password FROM MyAppDataFaith.Customer WHERE Email='" + email + "'AND Password='" + password + "';";

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;

                try
                {
                    comma.Connection.Open();
                    comma.Parameters.Add(new MySqlParameter("@Email", email));
                    comma.Parameters.Add(new MySqlParameter("@Password", password));

                    read = comma.ExecuteReader();


                    while (read.Read())
                    {
                        return new Customer(Convert.ToInt32(read[("CustId")]),
                                            Convert.ToString(read[("Firstname")]),
                                            Convert.ToString(read[("Lastname")]),
                                            Convert.ToString(read["Email"]),
                                            Convert.ToString(read["Password"]));
                    }
                    read.Close();
                }
                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }
                return null;
            }
        }

        //GettingAllCustomersIn TheDatabase
        public Customer[] GetCust()
        {
            string sql = "Select * from MyAppDataFaith.Customer;";
            List<Customer> custi = new List<Customer>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;


                try
                {
                    comma.Connection.Open();
                    Customer objcus = new Customer();
                    read = comma.ExecuteReader();
                    while (read.Read())
                    {
                        objcus = new Customer(Convert.ToInt32(read[("CustId")]),
                                            Convert.ToString(read[("Firstname")]),
                                            Convert.ToString(read[("Lastname")]),
                                            Convert.ToString(read["Email"]),
                                            Convert.ToString(read["Password"]));
                        custi.Add(objcus);
                    }

                    read.Close();

                    MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    reader.Read();
                    reader.Close();
                }

                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }

                return custi.ToArray();
            }

        }

        //CustUpdate

        public Customer CustUpdate(Customer cust, int id)
        {
            string sql = "UPDATE MyAppDataFaith.Customer SET Firstname='" + cust.Firstname + "',Lastname='" + cust.Lastname + "' WHERE CustId=" + id + ";";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                using (MySqlCommand comma = new MySqlCommand(sql, connect))
                {

                    comma.Connection = connect;
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.Add(new MySqlParameter("@_Firstname", cust.Firstname));
                        comma.Parameters.Add(new MySqlParameter("@_Lastname", cust.Lastname));
                        comma.Parameters.Add(new MySqlParameter("@_Email", cust.Email));
                        comma.Parameters.Add(new MySqlParameter("@_Password", cust.Password));


                        read = comma.ExecuteReader();
                        while (read.Read())
                        {
                            cust = new Customer(Convert.ToString(read["Firstname"]),
                                                Convert.ToString(read["Lastname"]),
                                                Convert.ToString(read["Email"]),
                                                Convert.ToString(read["Password"])

                                           );
                        }
                        read.Close();

                    }
                    catch (MySqlException exception)
                    {
                        exception.ToString();

                    }
                    finally
                    {
                        comma.Connection.Close();
                    }
                }
                return cust;
            }
        }

        //GettingAllRestaurants In TheDatabase
        public Restaurant[] GetRestaurant()
        {
            string sql = "Select * from MyAppDataFaith.Restaurant;";
            List<Restaurant> restu = new List<Restaurant>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;


                try
                {
                    comma.Connection.Open();
                    Restaurant objres = new Restaurant();
                    read = comma.ExecuteReader();
                    while (read.Read())
                    {
                        objres = new Restaurant(Convert.ToInt32(read[("ResId")]),
                                            Convert.ToString(read[("Address")]),
                                            Convert.ToString(read[("City")]),
                                            Convert.ToString(read["Resname"]),
                                            Convert.ToString(read["EmailAddress"]),
                                                Convert.ToString(read["Phonenumber"]),
                                                (byte[])(read["Image"])
                                               );
                        restu.Add(objres);
                    }

                    read.Close();

                    MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    reader.Read();
                    reader.Close();
                }

                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }

                return restu.ToArray();
            }

        }


        //GettingAllRestaurants In TheDatabase
        public Product[] GetProduct()
        {
            string sql = "Select * from MyAppDataFaith.Product;";
            List<Product> prod = new List<Product>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;


                try
                {
                    comma.Connection.Open();
                    Product objp = new Product();
                    read = comma.ExecuteReader();
                    while (read.Read())
                    {
                        objp = new Product(Convert.ToInt32(read[("ProId")]),
                                            Convert.ToString(read[("ProdName")]),
                                            Convert.ToString(read[("Description")]),
                                            Convert.ToString(read["Price"]),
                                                (byte[])(read["ProdImage"])
                                               );
                        prod.Add(objp);
                    }

                    read.Close();

                    MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    reader.Read();
                    reader.Close();
                }

                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }

                return prod.ToArray();
            }

        }


        //Payment
        public string AddPayment(Payment pay)
        {
            string x = "";
            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                string query = "INSERT INTO MyAppDataFaith.Payment(BankName,CardNumber,CVV,CustId,DeliveryAddress) " +
                    "VALUES('" + pay.BankName + "','" + pay.CardNumber + "','" + pay.CVV + "','" + pay.CustId + "','" + pay.DeliveryAddress + "');";
                using (MySqlCommand comma = new MySqlCommand(query, connect))
                {
                    try
                    {
                        comma.Connection.Open();

                        comma.Parameters.AddWithValue("@BankName", pay.BankName);
                        comma.Parameters.AddWithValue("@CardNumber", pay.CardNumber);
                        comma.Parameters.AddWithValue("@CVV", pay.CVV);
                        comma.Parameters.AddWithValue("@CustId", pay.CustId);
                        comma.Parameters.AddWithValue("@DeliveryAddress", pay.DeliveryAddress);
                        int y = comma.ExecuteNonQuery();

                        x = y.ToString();

                    }
                    catch (MySqlException exception)
                    {
                        comma.Connection.Close();
                        exception.ToString();

                    }
                }
                return null;
            }
        }



        //GettingAllPaymentsIn TheDatabase
        public Payment[] GetPayments()
        {
            string sql = "Select * from MyAppDataFaith.Payment;";
            List<Payment> pay = new List<Payment>();

            using (MySqlConnection connect = new MySqlConnection())
            {
                connect.ConnectionString = connectString;
                MySqlCommand comma = new MySqlCommand(sql, connect);
                comma.Connection = connect;


                try
                {
                    comma.Connection.Open();
                    Payment objpay = new Payment();
                    read = comma.ExecuteReader();
                    while (read.Read())
                    {
                        objpay = new Payment(Convert.ToInt32(read[("PayId")]),
                                            Convert.ToString(read[("BankName")]),
                                             Convert.ToInt32(read[("CardNumber")]),
                                             Convert.ToInt32(read["CVV"]),
                                             Convert.ToInt32(read["CustId"]),
                                            Convert.ToString(read["DeliveryAddress"]));
                        pay.Add(objpay);
                    }

                    read.Close();

                    MySqlDataReader reader = comma.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    reader.Read();
                    reader.Close();
                }

                catch (MySqlException exception)
                {
                    comma.Connection.Close();
                    exception.ToString();
                }

                return pay.ToArray();
            }

        }



    }
}