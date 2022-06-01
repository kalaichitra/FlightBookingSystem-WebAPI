using System;
using System.Collections.Generic;
using System.Text;

namespace ARSAPI.DAL.AdminDB.Models
{
   public class SearchInputs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int TripType { get; set; }
    }
}
