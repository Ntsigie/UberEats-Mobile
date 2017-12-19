using System;





namespace ntsebeng.Models
{
    public class Payment
    {

        public int PayId { get; set; }
        public string BankName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string CustId { get; set; }
        public string DeliveryAddress { get; set; }




        public Payment(string bnkname, string cardno, string cvv, string custid,string delvryadd)
        {
            BankName = bnkname;
            CardNumber = cardno;
            CVV = cvv;
            CustId = custid;
            DeliveryAddress = delvryadd;


        }


        public Payment(int ID, string bnkname, string cardno,string cvv, string custid,string delvryadd)
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

