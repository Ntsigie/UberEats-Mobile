using System;
namespace MyAppServices.Models
{
    public class Payment
    {

        public int PayId { get; set; }
        public string BankName { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public int CustId { get; set; }
        public string DeliveryAddress { get; set; }




        public Payment(string bnkname, int cardno, int cvv, int custid, string delvryadd)
        {
            BankName = bnkname;
            CardNumber = cardno;
            CVV = cvv;
            CustId = custid;
            DeliveryAddress = delvryadd;


        }


        public Payment(int ID, string bnkname, int cardno, int cvv, int custid, string delvryadd)
        {
            PayId = ID;
            BankName = bnkname;
            CardNumber = cardno;
            CVV = cvv;
            CustId = custid;
            DeliveryAddress = delvryadd;

        }


        public Payment()
        {

        }

    }
}

