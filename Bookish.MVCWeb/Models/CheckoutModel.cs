using Bookish.DataAccess;
using System.Collections.Generic;

namespace Bookish.MVCWeb.Models
{
    public class CheckoutModel
    {
        public List<Checkout> Checkouts { get; set; }

        public CheckoutModel(List<Checkout> checkouts)
        {
            Checkouts = checkouts;
        }
    }
}
