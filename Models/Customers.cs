﻿using System;
using System.Collections.Generic;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Buildings = new HashSet<Buildings>();
        }

        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string NameOfContact { get; set; }
        public string CompanyContactPhone { get; set; }
        public string EmailOfTheCompany { get; set; }
        public string CompanyDescription { get; set; }
        public string NameOfServiceTechAuthority { get; set; }
        public string TechAuhtorityPhone { get; set; }
        public string TechManagerServiceEmail { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
    }
}
