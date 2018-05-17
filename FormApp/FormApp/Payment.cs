using System;
using System.Collections.Generic;
using System.Text;

namespace FormApp
{
    public class Payment
    {
        public int Amount { get; set; }
        public PaymentType Type { get; set; }
        public string Currency { get; set; }
    }
    public enum PaymentType
    {
        Cash = 0,
        CreditCard = 1,
        DebitCard = 2,
        Check = 3
    }
}
