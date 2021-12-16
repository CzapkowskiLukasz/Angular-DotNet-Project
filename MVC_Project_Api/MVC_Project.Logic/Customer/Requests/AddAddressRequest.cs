﻿namespace MVC_Project.Logic.Customer.Requests
{
    public class AddAddressRequest
    {
        public int UserId { get; set; }
        
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string HouseNumber { get; set; }
        
        public string ApartmentNumber { get; set; }
        
        public string Code { get; set; }
        
        public string Country { get; set; }
    }
}
