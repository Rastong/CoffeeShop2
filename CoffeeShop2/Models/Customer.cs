using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeShop2
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Promos { get; set; }
    }
}
