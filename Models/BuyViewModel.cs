using Microsoft.AspNetCore.Mvc;

namespace BookApplication2.Models
{
    public class BuyViewModel
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
    }


}

