﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideokeRental.Models
{
    public class tblCalendarReservation
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 CustomersIdReserved { get; set; }
        public Int32 ProductId { get; set; }
        public String Product { get; set; }
        public String CustomersReserved { get; set; }
        public String ReservedDate { get; set; }
        public Decimal Price { get; set; }
        public String VideokeDescription { get; set; }

    }
}