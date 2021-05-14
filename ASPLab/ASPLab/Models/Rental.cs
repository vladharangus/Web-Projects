using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPLab.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int BookID { get; set; }
        public string Customer { get; set; }
    }
}